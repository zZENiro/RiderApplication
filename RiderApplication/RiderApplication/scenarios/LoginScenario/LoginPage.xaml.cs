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
        public Action<object, ModalPoppingEventArgs> PagePopping { get; set; }
        public RiderAccountViewModel RiderViewModel { get; set; } = new RiderAccountViewModel();

        static string settingPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        static string accSettingPath = Path.Combine(settingPath, "accountSetting");

        public LoginPage()
        {
            InitializeComponent();

            BindingContext = RiderViewModel;

            File.Delete(accSettingPath); //
            LoadLocalSettings();
        }

        private async Task LoadLocalSettings()
        {
            if (File.Exists(accSettingPath))
            {
                try
                {
                    var settingsStr = await ReadSettingsAsync();

                    var rider = JsonConvert.DeserializeObject<RiderAccount>(settingsStr);

                    entry_Login.Text = rider.Login; entry_Password.Text = rider.Password;

                    //var loadTask = await LoadRiderDataFromAPI(rider.Login, rider.Password);

                    await UpdateBindingContext(rider);

                    PagePopping?.Invoke(this, new ModalPoppingEventArgs(this));
                    await OpenMainPage();
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception in ctor");
                }
            }
        }

        private async Task LoadRemoteSetting()
        {

            if (entry_Login.Text.Length != 0 && entry_Password.Text.Length != 0)
            {
                // take data from Entry's and call webAPI method
                _rider = await LoadRiderDataFromAPI(entry_Login.Text, entry_Password.Text);
                

                if (_rider != null)
                {
                    var jsonData = JsonConvert.SerializeObject(_rider);

                    WriteSettingsAsync(jsonData);

                    await UpdateBindingContext(_rider);

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

        private async Task UpdateBindingContext(RiderAccount rider)
        {
            await Task.Factory.StartNew(() =>
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
            });
        }

        private async void btn_Enter_ButtonClicked(object sender, Controls.MyButtonEventArgs args) => await LoadRemoteSetting();

        // loading Data from API
        private async Task<RiderAccount> LoadRiderDataFromAPI(string login, string password)
        {
            try
            {
                var client = new RestClient($"https://185.39.17.11:5001/api/Riders/{login}:{password}");
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

        private async Task OpenMainPage() => await this.Navigation.PopModalAsync();
        
        static void WriteSettingsAsync(string settings)
        {
            File.Delete(accSettingPath);
            var _fs = new FileStream(accSettingPath, FileMode.Create);
            _fs.Close();

            using (FileStream fs = new FileStream(accSettingPath, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.Write(settings);
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

        string accountInfo = string.Empty;
        RiderAccount _rider;
    }
}