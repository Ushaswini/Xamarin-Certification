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
using Xamarin.Forms;
using XFDraw;
using XFDraw.Droid;
using Android.Text.Util;

[assembly: ExportRenderer(typeof(HyperLinkLabel),typeof(HyperLinkLabelRenderer))]
namespace XFDraw.Droid
{
    class HyperLinkLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            Linkify.AddLinks(Control, MatchOptions.All);
        }
    }
}