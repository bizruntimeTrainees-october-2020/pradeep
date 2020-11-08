using System;
using System.Net;
using System.Net.Sockets;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("This is Client");
                Socket cilentside = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Establishing Connection
                IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888); // spcifies a port to initilize
                cilentside.Connect(iPEnd); //accpets  new connections


                string sendData = "";
                do
                {
                    Console.Write("message :");
                    sendData = Console.ReadLine();
                    cilentside.Send(System.Text.Encoding.UTF8.GetBytes(sendData)); //decodes

                }
                while (sendData.Length > 0);
                {
                    cilentside.Close();
                }

             
        }
    }
}
