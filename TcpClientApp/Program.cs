using System;
using System.Net;
using System.Text;
using System.Net.Sockets;

namespace TcpClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                Console.WriteLine("Connecting to the TCP Server .......");

                client.Connect("54.175.103.105", 30001);
                // use the ip address and port number as in the server program to echo the TCP request info

                while (true)
                {
                    NetworkStream serverStream = client.GetStream();
                    byte[] outStream = Encoding.ASCII.GetBytes(Console.ReadLine());
                    serverStream.Write(outStream, 0, outStream.Length);
                    serverStream.Flush();
                }

                Console.WriteLine("Connected....");

                client.Close();

            } catch (Exception e)
            {
                Console.WriteLine("Error ....." + e.StackTrace);
            }
            
        }
    }
}
