using RiderApplication.RiderUdpClient;
using RiderApplication.scenarios.LoginScenario;
using RiderApplication.scenarios.ScenariosModels;
using RiderApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RiderApplication
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //this.Navigation.PushModalAsync(new LoginPage());

            //GeolocationModelView _locationBC = new GeolocationModelView();

            //// Set IP address of receiving server
            //RiderUdp client = new RiderUdp("127.0.0.1", 11000);

            //// get KEY from webAPI 
            //// API gets Hash code of driver 
            //// and then we send key to the server
            //// server give to client full info about driver in json-format
            //string key = ((RiderAccount)BindingContext).HashCode;

            //_locationBC.LocationUpdated += (s, e) =>
            //{
            //    var _task = client.SendMessage($"{e.Longitude};{e.Longitude}-{key}");
            //};

            //var task = _locationBC.Start();
        }
    }
}
