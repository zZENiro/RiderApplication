using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Runtime.CompilerServices;
using Xamarin.Essentials;
using System.Threading.Tasks;

namespace RiderApplication.ViewModels
{ 
    public class GeolocationModelViewEventArgs
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class GeolocationModelView : ModelView
    {
        public Action<object, GeolocationModelViewEventArgs> LocationUpdated { get; set; }

        public async Task Start()
        {
            while (true)
            {
                var location = await Geolocation.GetLocationAsync();

                Latitude = location.Latitude;
                Longitude = location.Longitude;

                LocationUpdated?.Invoke(this, new GeolocationModelViewEventArgs()
                {
                    Latitude = this.Latitude,
                    Longitude = this.Longitude
                });
            }
        }

        public double Latitude
        {
            get => _latitude;
            set => SetValue(ref _latitude, value);
        }

        public double Longitude
        {
            get => _longitude;
            set => SetValue(ref _longitude, value);
        }

        private double _latitude;
        private double _longitude;
    }
}
