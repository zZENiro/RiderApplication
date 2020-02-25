using RiderApplication.RiderClient;
using RiderApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace RiderApplication.LocationSender
{
    public class LocationSenderClient<T> : 
        ILocationSenderClient<IRiderClient>
        where T : IRiderClient
    {
        IRiderClient _locationSender;
        GeolocationModelView _glocation;

        public IRiderClient Sender
        {
            get { return _locationSender; }
            set { _locationSender = value; }
        }

        public GeolocationModelView Geolocation 
        {
            get { return _glocation; }
        }

        public LocationSenderClient(IRiderClient riderClient)
        {
            _locationSender = riderClient;
            _glocation = new GeolocationModelView();

            _glocation.LocationUpdated += async (s, e) =>
            {
                await _locationSender.SendMessageAsync(
                    $"{e.Longitude};" +
                    $"{e.Longitude}" +
                    $"-{_locationSender.HashCode}");
            };
        }

        public async Task StartSendingLocation()
        {
            await _glocation.Start();
        }
    }
}
