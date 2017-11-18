using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = CrossConnectivity.Current.IsConnected ? (Page) new NetwokViewPage() : new NoNetworkPage();
        }

        protected override void OnStart()
        {
            base.OnStart();
            // Handle when your app starts
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            Type currentPageType = MainPage.GetType();

            if(e.IsConnected && currentPageType != typeof(NetwokViewPage))
            {
                this.MainPage = new NetwokViewPage();
            }
            if(!e.IsConnected && currentPageType != typeof(NoNetworkPage))
            {
                this.MainPage = new NoNetworkPage();
            }

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
