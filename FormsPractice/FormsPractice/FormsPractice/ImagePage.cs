using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FormsPractice
{
    public class ImagePage : ContentPage
    {
        public ImagePage()
        {
            Title = "Working with Images";

            var absLayout = new AbsoluteLayout();

            var btnStart = new Button
            {
                Text = "Start exam",
                BackgroundColor = Color.FromHex("#0892d0"),
                TextColor = Color.White,
                Font = Font.SystemFontOfSize(NamedSize.Medium)
            };

            btnStart.Clicked += OnStartClicked;


            var image = new Image
            {
                //Using embedded resource in PCL
                Source = ImageSource.FromResource("FormsPractice.Images.Background.jpg"),
               //Using platform specific resource
                //Source = ImageSource.FromFile("icon.png"),
                Aspect=Aspect.AspectFill

            };

            //image will be like background
            absLayout.Children.Add(image, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);


            absLayout.Children.Add(btnStart, new Rectangle(0.5, 0.5, 200, 60), AbsoluteLayoutFlags.PositionProportional);


            Content = absLayout;
        }

        private void OnStartClicked(object sender, EventArgs e)
        {

        }
    }
}