using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace serverM
{
    class Program
    {
        private static byte[] buffer = new byte[1024];
        private static List<Socket> clientsocket = new List<Socket>();
        private static Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static void Main(string[] args)
        {
            SetupServer();
            Console.ReadLine();

            
        }
        private static void SetupServer()
        {
            Console.WriteLine("waiting for connection ");
            listener.Bind(new IPEndPoint(IPAddress.Any, 100));
            listener.Listen(1);
            listener.BeginAccept(new AsyncCallback(AcceptCallback), null);

        }

        private static void AcceptCallback(IAsyncResult ar)
        {
            Socket socket = listener.EndAccept(ar);
            clientsocket.Add(socket);
            Console.WriteLine("client connected");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback),socket);
            listener.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
        private static void RecieveCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            int recieved = socket.EndReceive(ar);
            byte[] databuf = new byte[recieved];
            Array.Copy(buffer, databuf, recieved);
            string text = Encoding.ASCII.GetString(databuf);
            Console.WriteLine("text recieved" + text);
            string response = string.Empty;
            if(text.ToLower()!="get time")
            {
                response = "invalid";
            }
            else
            {
                response = DateTime.Now.ToLongTimeString();
            }
            
            byte[] data = Encoding.ASCII.GetBytes(text);
            socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(sendCallback),socket);
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(RecieveCallback), socket);
            listener.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }
    
        private static void sendCallback(IAsyncResult ar)
        {
            Socket socket = (Socket)ar.AsyncState;
            socket.EndSend(ar);
        }
    }
}
