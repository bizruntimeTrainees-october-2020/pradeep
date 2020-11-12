using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class socks
{
	public static void Main(string[] args)
	{
		try
		{
			while (true)
			{
				IPAddress ipAd = IPAddress.Parse("127.0.0.1");
				TcpListener myList = new TcpListener(ipAd, 8001);
				myList.Start();
				Console.WriteLine("The server is running at port 8001...");
				Console.WriteLine("The local End point is  :" +
				myList.LocalEndpoint);
				Console.WriteLine("Waiting for a connection.....");
				Socket s = myList.AcceptSocket();
				Console.WriteLine("Connection accepted from " + s.RemoteEndPoint);
				byte[] b = new byte[100];
				int k = s.Receive(b);
				Console.WriteLine("Recieved...");
				string Command = string.Empty;
				for (int i = 0; i < k; i++)
				{
					Command = Command + Convert.ToChar(b[i]);
				}
				Console.WriteLine(Command); 
				ASCIIEncoding asen = new ASCIIEncoding();
				s.Send(asen.GetBytes("The string was recieved by the server."));
				Console.WriteLine("\nSent Acknowledgement");
				s.Close();
				myList.Stop();
			}
		}
		catch (Exception e)
		{
			Console.WriteLine("Error..... " + e.StackTrace);
		}
	}
}