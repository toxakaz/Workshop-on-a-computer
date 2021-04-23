using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace p2pReader
{
    class TCPListener
    {
        public TCPListener(EventHandler<Socket> newSocketSubscriber) : this(49152, 65535, newSocketSubscriber) { }
        public TCPListener(int portMin, int portMax, EventHandler<Socket> newSocketSubscriber)
        {
            ipAddress = IPAddress.Any;
            Random random = new Random();

            for (;;)
            {
                try
                {
                    ipEndPoint = new IPEndPoint(ipAddress, 12241);
                    socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    socket.Bind(ipEndPoint);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            NewSocket += newSocketSubscriber;
            socket.Listen(16);

            Task.Run(() =>
            {
                for (;;)
                {
                    try
                    {
                        Socket newSocket = socket.Accept();
                        newSocket.Send(Message.GetMessage(0, "listener", 32));
                        NewSocket(this, newSocket);
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }
            });
        }

        public IPAddress ipAddress { get; private set; }
        public IPEndPoint ipEndPoint { get; private set; }
        public Socket socket { get; private set; }

        public event EventHandler<Socket> NewSocket;
    }
}
