using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RiderApplication.RiderUdpClient
{
    public class RiderUdp
    {
        IPEndPoint _serverAddress;
        IPAddress _IPaddress;
        string _ipString;
        int _remotePort;

        Socket sock;

        UdpClient _client;

        public RiderUdp(string IPString, int Port)
        {
            _remotePort = Port;
            _ipString = IPString;

            //sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            _IPaddress = IPAddress.Parse(_ipString);
            _serverAddress = new IPEndPoint(_IPaddress, _remotePort);
            _client = new UdpClient();
            
        }

        public async Task SendMessage(string message)
        {
            await Task.Factory.StartNew(() =>
            {
                var data = Encoding.ASCII.GetBytes(message);
                var count = _client.Send(data, data.Length, _serverAddress);

                //var count = sock.SendTo(data, _serverAddress);

                Console.WriteLine($"{count}");
            });
        }
    }
}
