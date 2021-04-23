using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace p2pReader
{
    class SocketManager
    {
        public SocketManager()
        {
            listener = new TCPListener(PortReader);
            Console.WriteLine("server started at port: " + listener.ipEndPoint.Port);
        }

        TCPListener listener;

        void PortReader(object sender, Socket socket)
        {
            Console.WriteLine(socket.RemoteEndPoint.ToString() + " connected");
            Task.Run(() =>
            {
                try
                {
                    byte[] buffer;
                    while (true)
                    {
                        Message message = new Message();
                        while (!message.full)
                        {
                            buffer = new byte[32];
                            socket.Receive(buffer);
                            message.AddArray(buffer, 32);
                        }
                        Console.WriteLine(socket.RemoteEndPoint.ToString() + " " + (message.type == 0 ? "name" : (message.type == 1 ? "msg" : "socket")) + " > " + message.message);
                    }
                }
                catch (ObjectDisposedException)
                {
                    return;
                }
                catch (SocketException)
                {
                    Console.WriteLine(socket.RemoteEndPoint.ToString() + " disconnected");
                    return;
                }
            });
        }
    }
}