using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FormsPractice
{
    public class StackPage : ContentPage
    {
        public StackPage()
        {
            int clickCount = 0;
            var btnCount = new Button {
                Text = "Click me!",
                BackgroundColor=Color.Accent,
                TextColor=Color.Wheat
            };

            btnCount.Clicked += (sender, e) => {
                clickCount++;
                btnCount.Text = $"Clicked {clickCount} times!";
            };
            Title = "Testing Content Pages!!";
            Content = new StackLayout
            {
                VerticalOptions=LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment=TextAlignment.Center, 
                        Text = "Hello Content Page" }
                }
            };
        }
    }
}