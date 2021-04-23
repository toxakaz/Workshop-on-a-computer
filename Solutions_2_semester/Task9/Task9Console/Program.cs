using System;
using System.Diagnostics;
using System.IO;

namespace Task9Console
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamWriter writer;
            StreamReader reader;

            try
            {
                ProcessStartInfo info = new ProcessStartInfo("Task9.exe")
                {
                    RedirectStandardError = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = false,
                    WindowStyle = ProcessWindowStyle.Normal
                };

                Process process = Process.Start(info);

                writer = process.StandardInput;
                reader = process.StandardOutput;

                writer.Write("Hello world!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

    }
}
