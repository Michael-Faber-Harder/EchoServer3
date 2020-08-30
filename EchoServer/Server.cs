using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace EchoServer
{
	class Server
	{

		public void Start()
		{
			TcpListener server = new TcpListener(IPAddress.Loopback, 7);
			server.Start();
			using TcpClient socket = server.AcceptTcpClient();
			{
				Stream ns = socket.GetStream();
				StreamReader sr = new StreamReader(ns);
				StreamWriter sw = new StreamWriter(ns);
				String line = sr.ReadLine();
				sw.WriteLine(line);
				sw.Flush();
			}
		}
	}
}