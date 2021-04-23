using System;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace p2pReader
{
    class SocketHandler
    {
        public SocketHandler(Socket socket, MessegeHandler messegeSubscriber)
        {
            this.socket = socket;
            messege += messegeSubscriber;
        }

        public Socket socket { get; private set; }
        public delegate void MessegeHandler(object sender, byte[] buffer, int size);
        public event MessegeHandler messege;
        public DateTimeOffset lastKeepAlive { get; private set; }


        public async void StartRecive()
        {
            await Task.Run(() =>
            {
                for (;;)
                {
                    try
                    {
                        byte[] buffer = new byte[1024];
                        int size = socket.Receive(buffer);

                        if (size == 1)
                            if (buffer[0] == 0)
                            {
                                lastKeepAlive = DateTimeOffset.UtcNow;
                                socket.Send(new byte[] { 0 });
                                continue;
                            }

                        messege(this, buffer, size);
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                }
            });
        }

        public void Send(byte[] buffer)
        {
            socket.Send(buffer);
        }

        public void Close()
        {
            socket.Close();
        }
    }
}
