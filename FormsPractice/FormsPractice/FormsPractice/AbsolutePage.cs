using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FormsPractice
{
    public class AbsolutePage : ContentPage
    {
        public AbsolutePage()
        {
            Title = "Checking Absolute Layout";

            var absLayout = new AbsoluteLayout();

            var btnStart = new Button
            {
                Text ="Start exam",
                BackgroundColor=Color.FromHex("#0892d0"),
                TextColor=Color.White,
                Font=Font.SystemFontOfSize(NamedSize.Medium)
            };

            btnStart.Clicked += OnStartClicked;

            absLayout.Children.Add(btnStart, new Rectangle(0.5, 0.5, 200, 60),AbsoluteLayoutFlags.PositionProportional);


            Content = absLayout;
        }

        private void OnStartClicked(object sender, EventArgs e)
        {
            
        }
    }
}