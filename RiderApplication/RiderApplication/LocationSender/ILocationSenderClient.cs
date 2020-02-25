using RiderApplication.RiderClient;
using RiderApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RiderApplication
{
    public interface ILocationSenderClient<T> where T : IRiderClient
    {
        T Sender { get; set; }

        GeolocationModelView Geolocation { get; }

        Task StartSendingLocation();
    }
}
