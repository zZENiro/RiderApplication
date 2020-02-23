using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiderApplication.scenarios.ScenariosViewModels;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using RiderApplication.scenarios.ScenariosModels;
using RestSharp;

namespace RiderApplication.scenarios.LoginScenario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        static string settingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string accSettingPath = Path.Combine(settingPath, "accountSetting");

        public Action<object, ModalPoppingEventArgs> PagePopping;

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = RiderViewModel;

            File.Delete(accSettingPath);
            LoadLocalSettings();
        }

        private async Task LoadLocalSettings()
        {
            if (File.Exists(accSettingPath))
            {
                try
                {
                    var readSettingsTask = await ReadSettingsAsync();

                    var rider = JsonConvert.DeserializeObject<RiderAccount>(readSettingsTask);

                    entry_Login.Text = rider.Login; entry_Password.Text = rider.Password;

                    var loadTask = await LoadRiderDataFromAPI(rider.Login, rider.Password);

                    await Navigation.PushAsync(new MainPage()
                    {
                        BindingContext = new RiderAccountViewModel()
                        {
                            Name = rider.Name,
                            CarModel = rider.CarModel,
                            CarNumber = rider.CarNumber,
                            HashCode = rider.HashCode
                        }
                    });
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception in ctor");
                }
            }
        }

        private async Task LoadRemoteSetting()
        {
            try
            {
                if (entry_Login.Text.Length != 0 && entry_Password.Text.Length != 0)
                {
                    // take data from Entry's and call webAPI method

                    RiderAccount _rider = /*await LoadRiderDataFromAPI(entry_Login.Text, entry_Password.Text);*/
                        new RiderAccount()
                        {
                            Password = "1231"
                        };

                    if (_rider != null) // !=
                    {
                        //var jsonData = JsonConvert.SerializeObject(_rider); // saving to JSON

                        //File.Delete(accSettingPath);
                        //File.Create(accSettingPath);
                        //await WriteSettingsAsync(jsonData);

                        //Console.WriteLine("Opened");

                        UpdateBindingContext(_rider);

                        PagePopping?.Invoke(this, new ModalPoppingEventArgs(this));

                        await OpenMainPage();
                    }
                    else
                    {
                        // drop bad inits label
                    }
                }
                else
                {
                    // to do
                    // we can drop warning label somewhere
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void UpdateBindingContext(RiderAccount rider)
        {
            var riderMVType = typeof(RiderAccountViewModel);
            var riderModel = typeof(RiderAccount);

            var riderMVTypeProps = riderMVType.GetProperties();
            var riderModelProps = riderModel.GetProperties();

            foreach (var riderMVprop in riderMVTypeProps)
            {
                foreach (var riderModelProp in riderModelProps)
                {
                    if (riderMVprop.Name == riderModelProp.Name)
                    {
                        riderMVprop.SetValue(this.RiderViewModel, riderModelProp.GetValue(rider));
                    }
                }
            }

            Console.WriteLine($"{this.RiderViewModel.Password}");
        }

        private async void btn_Enter_ButtonClicked(object sender, Controls.MyButtonEventArgs args)
        {
            await LoadRemoteSetting();
        }

        // loading Data from API
        private async Task<RiderAccount> LoadRiderDataFromAPI(string login, string password)
        {
            try
            {
                var client = new RestClient($"https://localhost:5001/api/Riders/{login}:{password}");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader($"Content-Type", "application/json");
                request.AddParameter("application/json", "", ParameterType.RequestBody);
                IRestResponse response = await client.ExecuteAsync(request);

                if (response.StatusCode == (System.Net.HttpStatusCode.OK |
                                            System.Net.HttpStatusCode.Accepted |
                                            System.Net.HttpStatusCode.Found))
                {
                    return JsonConvert.DeserializeObject<RiderAccount>(response.Content);
                }
                return null;
            }
            catch (Exception ex) // some Exclusive Exception
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private async Task OpenMainPage()
        {
            await this.Navigation.PopModalAsync();
        }

        static async Task WriteSettingsAsync(string settings)
        {
            using (FileStream fs = new FileStream(accSettingPath, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    await writer.WriteAsync(settings);
                }
            }
        }

        static async Task<string> ReadSettingsAsync()
        {
            string _accountInfo = string.Empty;

            using (FileStream fs = new FileStream(accSettingPath, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    _accountInfo = await reader.ReadToEndAsync();
                }
            }
            return _accountInfo;
        }

        RiderAccount _rider;
        public RiderAccountViewModel RiderViewModel = new RiderAccountViewModel();
        string accountInfo = string.Empty;
    }
}