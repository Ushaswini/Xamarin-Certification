using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace NetStatus
{
    public class NetwokViewPage : ContentPage
    {
        Label ConnectionDetails;

        public NetwokViewPage()
        {
            ConnectionDetails = new Label { Text = "Hello Page" };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,

                Children = {
                   ConnectionDetails
                }
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if(CrossConnectivity.Current == null)
            {
                return;
            }
            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();
            CrossConnectivity.Current.ConnectivityTypeChanged += Current_ConnectivityTypeChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if(CrossConnectivity.Current != null)
            {
                CrossConnectivity.Current.ConnectivityTypeChanged -= Current_ConnectivityTypeChanged;
            }
        }

        private void Current_ConnectivityTypeChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityTypeChangedEventArgs e)
        {
            if(CrossConnectivity.Current!= null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }
    }
}