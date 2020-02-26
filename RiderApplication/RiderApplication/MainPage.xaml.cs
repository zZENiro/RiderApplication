using RiderApplication.RiderClient;
using RiderApplication.scenarios.LoginScenario;
using RiderApplication.scenarios.ScenariosModels;
using RiderApplication.scenarios.ScenariosViewModels;
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
using RiderApplication.LocationSender;

namespace RiderApplication
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //RiderClientUDP riderClient = new RiderClientUDP("192.168.0.100:", 5000, "4402831ADQW");

            //ILocationSenderClient<IRiderClient> locationSender = new LocationSenderClient<RiderClientUDP>(riderClient);

            //locationSender.StartSendingLocation();
        }
    }
}
