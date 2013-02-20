using System;
using System.Linq;
using System.Threading;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			var connection = new Connection("http://localhost/echo");

			connection.Start(new LongPollingTransport()).Wait();

			connection.Received += incomingData => Console.WriteLine("Received: " + incomingData);
			connection.Reconnected += () => Console.WriteLine("Reconnected");

			var response = 0;
			while (true)
			{
				Thread.Sleep(1000);
				try
				{
					connection.Send(response++).Wait();
				}
				catch (Exception e)
				{
					Console.WriteLine("Send Failed");
				}
			}
		}
	}
}
