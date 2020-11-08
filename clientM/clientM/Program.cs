using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;

namespace clientM
{
    class Program
    {
        private static Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            Loopconnect();
            Console.ReadLine();
            Sendloop();

        }
        private static void Sendloop()
        {
            Console.WriteLine("enter request");
            string req = Console.ReadLine();
            byte [] buffer = Encoding.ASCII.GetBytes(req);
            client.Send(buffer);
            byte[] recievebuffer = new byte[1024];
            int rec = client.Receive(recievebuffer);
            byte[] data = new byte[rec];
            Array.Copy(recievebuffer, data, rec);
            Console.WriteLine("Recieved " + Encoding.ASCII.GetString(data));



        }
        
        private static void Loopconnect()
        {
            int attempts = 0;
            while(!client.Connected)
            {
                try
                {
                    client.Connect(IPAddress.Loopback, 100);

                }
                catch (SocketException)
                {
                    Console.Clear();
                    Console.WriteLine("connection attempts=" + attempts);

                }

            }
            Console.Clear();
            Console.WriteLine("connected");


          
        }
    }
}
