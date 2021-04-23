using System;
using System.Text;

namespace p2pReader
{
    class Message
    {
        public byte type { get; private set; }
        public string message { get; private set; }
        public bool full { get; private set; } = false;

        bool started = false;
        int size;
        int sizeNow = 0;
        byte[] messageBuffer;

        public bool AddArray(byte[] buffer, int packageSize)        //show packet exchange rules at Message.GetMessage
        {
            if (full)
                return false;

            int startIndex = 0;

            if (!started)
            {
                size = BitConverter.ToInt32(buffer, 0);
                type = buffer[4];
                messageBuffer = new byte[packageSize * size - 5];
                startIndex = 5;
                started = true;
            }

            Array.Copy(buffer, startIndex, messageBuffer, packageSize * sizeNow - 5 + startIndex, packageSize - startIndex);

            sizeNow++;

            if (sizeNow >= size)
            {
                message = Encoding.UTF8.GetString(messageBuffer);
                full = true;
            }

            return true;
        }

        public static byte[] GetMessage(byte type, string message, int packageSize)
        {
            //the number of bytes sent is a multiple of packageSize (32 preferred)
            //struct of bytes: [size : Int32][type : byte][message : string][0.. to multiple of packageSize]
            //where size = count of packages

            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);
            int size = (messageBuffer.Length + 5) / packageSize + ((messageBuffer.Length + 5) % packageSize == 0 ? 0 : 1);

            byte[] output = new byte[packageSize * size];

            Array.Copy(BitConverter.GetBytes(size), output, 4);
            output[4] = type;

            Array.Copy(messageBuffer, 0, output, 5, messageBuffer.Length);

            return output;
        }
    }
}