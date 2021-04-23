using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace p2pReader
{
    class Program
    {
        static void Main(string[] args)
        {
            SocketManager socketM = new SocketManager();

            for (; ; )
            {
                Thread.Sleep(1000);
            };
        }
    }
}
