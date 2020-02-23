using RiderApplication.scenarios.LoginScenario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RiderApplication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainShell : Shell
    {
        public MainShell()
        {
            InitializeComponent();
            RegisterRoutes();

            var loginPage = new LoginPage();

            loginPage.PagePopping += (s, e) =>
            {
                this.BindingContext = (((ModalPoppingEventArgs)e).Modal as LoginPage).RiderViewModel;
                Console.WriteLine("Popped");
            };

            this.Navigation.PushModalAsync(loginPage);
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("mainPage", typeof(MainPage));
        }
    }
}