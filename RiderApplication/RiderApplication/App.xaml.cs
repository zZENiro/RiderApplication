﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RiderApplication.scenarios.LoginScenario;

namespace RiderApplication
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
