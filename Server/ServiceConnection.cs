using System;
using System.Linq;
using Microsoft.AspNet.SignalR;

namespace Server
{
	public class ServiceConnection : PersistentConnection
	{
		protected override System.Threading.Tasks.Task OnReceived(IRequest request, string connectionId, string data)
		{
			return Connection.Send(connectionId, data);
		}
	}
}