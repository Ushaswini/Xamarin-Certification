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
using System.ComponentModel;
using XFDraw;
using XFDraw.Droid;

[assembly:ExportRenderer(typeof(SketchView),typeof(SketchViewRenderer))]
namespace XFDraw.Droid
{
    class SketchViewRenderer :ViewRenderer<SketchView,PaintView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<SketchView> e)
        {
            base.OnElementChanged(e);
            if(base.Control == null)
            {
                var paintView = new PaintView(Forms.Context);
                paintView.SetInkColor(Xamarin.Forms.Color.Beige.ToAndroid());
                SetNativeControl(paintView);
                MessagingCenter.Subscribe<SketchView>(this, "Clear", OnMessageClear);
                paintView.LineDrawn += PaintViewLineDrawn;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if(e.PropertyName == SketchView.InkColorProperty.PropertyName)
            {
                Control.SetInkColor(Element.InkColor.ToAndroid());
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                MessagingCenter.Unsubscribe<SketchView>(this, "Clear");

            base.Dispose(disposing);
        }

        private void OnMessageClear(SketchView sender)
        {
            if (sender == Element)
                Control.Clear();
        }

        private void PaintViewLineDrawn(object sender, EventArgs e)
        {
            var sketchCon = (ISketchController)Element;
            if (sketchCon == null)
                return;
            sketchCon.SendSketchUpdated();
        }


    }
}