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

namespace LocationService
{
    class LocationServiceConnection : Java.Lang.Object, IServiceConnection
    {
        public EventHandler<bool> ServiceConnectionChanged;

        public LocationService Service { get; private set; }
        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            LocationBinderService lsBinder = service as LocationBinderService;

            if (lsBinder == null)
                return;

            this.Service = lsBinder.Service;



            ServiceConnectionChanged?.Invoke(this, true);
        }

        public void OnServiceDisconnected(ComponentName name)
        {
            ServiceConnectionChanged?.Invoke(this, false);
        }
    }
}