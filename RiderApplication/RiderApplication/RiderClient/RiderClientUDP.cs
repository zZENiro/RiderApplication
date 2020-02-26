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

        public RiderClientUDP(string IPString, int Port, string HashCode) =>
            (_IPaddress, _hs, _serverAddress, _client) =
            (IPAddress.Parse(IPString), HashCode, new IPEndPoint(_IPaddress, Port), new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp));

        public IPEndPoint RemoteClient
        {
            get => _serverAddress;
            set => _serverAddress = value;
        }

        public IPAddress RemoteIPAddress
        {
            get => _IPaddress;
            set => _IPaddress = value;
        }

        public Socket Client
        {
            get => _client;
            set => _client = value;
        }

        public string HashCode
        {
            get => _hs;
            set => _hs = value;
        }

        public void SendMessage(string message)
        {
            var data = Encoding.ASCII.GetBytes(message);

            _client.SendTo(data, SocketFlags.None, _serverAddress);
        }

        public async Task SendMessageAsync(string message) =>
            await Task.Factory.StartNew(() =>
            {
                var data = Encoding.ASCII.GetBytes(message);

                _client.SendTo(data, SocketFlags.None, _serverAddress);
            });
    }
}
