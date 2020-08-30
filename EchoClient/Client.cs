using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace EchoClient
{
	class Client
	{
		public void Start()
		{
			TcpClient socket = new TcpClient("localhost", 7);

			StreamReader sr = new StreamReader(socket.GetStream());
			StreamWriter sw = new StreamWriter(socket.GetStream());


			String line = "Hallo Peter";
			Console.WriteLine("Sender fra Client");
			Console.WriteLine();
			
			sw.WriteLine(line);
			sw.Flush();

			String strRetur = sr.ReadLine();
			Console.WriteLine($"Tilbage fra Server : {strRetur} ord");

			socket.Close();
        }
	}
}
