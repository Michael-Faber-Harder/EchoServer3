using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EchoServer
{
	class Server
	{

		public async void Start()
		{
			TcpListener server = new TcpListener(IPAddress.Loopback, 7);
			server.Start();

			bool infinity = true;
			while (true)
			{
				using TcpClient socket = server.AcceptTcpClient();
				{
					await Task.Run(() =>
					{
						TcpClient tempSocket = socket;
						//infinity = DoClient(tempSocket);
						DoClient(tempSocket);
					});
				}
			}
		}

		public async Task DoClient(TcpClient socket)
		{
			Stream ns = socket.GetStream();
			StreamReader sr = new StreamReader(ns);
			StreamWriter sw = new StreamWriter(ns);
			String line = sr.ReadLine();
			//if (line.ToLower() == "close")
			//{
			//	return false;
			//}
			Thread.Sleep(3000);
			sw.WriteLine(CountWords(line));
			sw.Flush();
			//return true;
		}

		public int CountWords(string line)
		{

			int NumberOfWords = 0;
			NumberOfWords = line.Trim().Split(' ').Count();
			return NumberOfWords;
		}
	}
}
