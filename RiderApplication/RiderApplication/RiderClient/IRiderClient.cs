using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RiderApplication.RiderClient
{
    public interface IRiderClient 
    {
        IPEndPoint RemoteClient { get; set; }

        IPAddress RemoteIPAddress { get; set; }

        Socket Client { get; set; }

        string HashCode { get; set; }

        void SendMessage(string message);

        Task SendMessageAsync(string message);
    }
}
