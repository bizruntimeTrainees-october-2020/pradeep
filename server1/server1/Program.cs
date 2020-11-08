using System;
using System.Net;
using System.Net.Sockets;

namespace server1
{
    class Program
    {
        publicstatic void Main(string[] args)

        {
            Console.WriteLine("hello this is server");
            Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iPEnd = new IPEndPoint((IPAddress.Parse("127.0.0.1")), 8888);
            listenerSocket.Bind(iPEnd);
            listenerSocket.Listen(2);
            Console.WriteLine("waiting for client to connect");
            Socket clientSocket = listenerSocket.Accept();
            byte[] Buffer = new byte[clientSocket.SendBufferSize];
            int readByte;
            do
            {
                readByte = clientSocket.Receive(Buffer);
                byte[] rData = new byte[readByte];
                Array.Copy(Buffer, rData, readByte);
                Console.WriteLine("the message: " + System.Text.Encoding.UTF8.GetString(rData));

            }
            while (readByte > 0);


            Console.WriteLine("Client Disconnected");
            Console.ReadKey();
        }
    }
}
