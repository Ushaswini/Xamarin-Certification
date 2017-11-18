using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using ControlExplorer.Droid;

[assembly:ExportEffect(typeof(MyButtonGradientEffect),"ButtonGradientEffect")]

namespace ControlExplorer.Droid
{
    
    class MyButtonGradientEffect : PlatformEffect
    {
        Drawable oldDrawable;
        protected override void OnAttached()
        {
            if (Element is Xamarin.Forms.Button == false)
                return;
            oldDrawable = Control.Background;
            setGradient();

        }

        protected override void OnDetached()
        {
            if (oldDrawable != null)
                Control.SetBackground(oldDrawable);
        }

        void setGradient()
        {
            var xfButton = Element as Xamarin.Forms.Button;

            var colorTop = xfButton.BackgroundColor;
            var colorBottom = Xamarin.Forms.Color.Black;

            var gradient = Gradient.GetGradientDrawable(colorTop.ToAndroid(), colorBottom.ToAndroid());

            Control.SetBackground(gradient);

        }
  
    }
}