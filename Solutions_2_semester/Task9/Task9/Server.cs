using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace p2pReader
{
    class Server
    {
        public Server(EventHandler<Socket> newSocketSubscriber)
        {
            ipHost = Dns.GetHostEntry("localhost");
            ipAddress = ipHost.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddress, 8080);
            socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            socket.Listen(16);
            Listen();
        }

        public IPHostEntry ipHost { get; private set; }
        public IPAddress ipAddress { get; private set; }
        public IPEndPoint ipEndPoint { get; private set; }
        public Socket socket { get; private set; }

        public event EventHandler<Socket> newSocket;

        async void Listen()
        {
            await Task.Run(() =>
            {
                for (; ; )
                {
                    try
                    {
                        Socket user = socket.Accept();
                        newSocket(this, user);
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }
            });
        }
    }
}
