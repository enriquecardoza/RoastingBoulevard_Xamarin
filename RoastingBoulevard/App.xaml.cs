﻿using System;
using RoastingBoulevard.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoastingBoulevard
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainTabbedPage();
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
