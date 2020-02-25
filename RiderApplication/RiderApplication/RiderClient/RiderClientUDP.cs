using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RiderApplication.RiderClient
{
    public class RiderClientUDP : IRiderClient
    {
        IPEndPoint _serverAddress;
        IPAddress _IPaddress;
        Socket _client;
        string _hs;

        public RiderClientUDP(string IPString, int Port, string HashCode)
        {
            _IPaddress = IPAddress.Parse(IPString);
            _serverAddress = new IPEndPoint(_IPaddress, Port);
            _client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            _hs = HashCode;
        }

        public IPEndPoint RemoteClient
        {
            get { return _serverAddress; }
            set { _serverAddress = value; }
        }

        public IPAddress RemoteIPAddress
        {
            get { return _IPaddress; }
            set { _IPaddress = value; }
        }

        public Socket Client
        {
            get { return _client; }
            set { _client = value; }
        }

        public string HashCode
        {
            get { return _hs; }
            set { _hs = value; }
        }

        public void SendMessage(string message)
        {
            var data = Encoding.ASCII.GetBytes(message);

            _client.SendTo(data, SocketFlags.None, _serverAddress);
        }

        public async Task SendMessageAsync(string message)
        {
            await Task.Factory.StartNew(() =>
            {
                var data = Encoding.ASCII.GetBytes(message);

                _client.SendTo(data, SocketFlags.None, _serverAddress);
            });
        }
    }
}
