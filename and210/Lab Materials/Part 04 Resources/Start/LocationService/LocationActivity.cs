using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace LocationService
{
    [Activity(Label = "LocationActivity")]
    public class LocationActivity : Activity
    {
        TextView latText, lngText, altText, speedText, startText;

        LocationServiceConnection lsConnection;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Location);

            latText = FindViewById<TextView>(Resource.Id.latText);
            lngText = FindViewById<TextView>(Resource.Id.lngText);
            altText = FindViewById<TextView>(Resource.Id.altText);
            speedText = FindViewById<TextView>(Resource.Id.speedText);
            startText = FindViewById<TextView>(Resource.Id.startText);

            lsConnection = new LocationServiceConnection();

            lsConnection.ServiceConnectionChanged += ServiceConnectionChanged;
            
            ClearScreen();
        }

        protected void ServiceConnectionChanged(object sender, bool isConnected)
        {
            if (isConnected)
            {
                lsConnection.Service.LocationChanged += Service_LocationChanged;
                startText.Text = lsConnection.Service.StartTime.ToLongTimeString();
            }
            else
            {
                lsConnection.Service.LocationChanged -= Service_LocationChanged;
            }
        }

        private void Service_LocationChanged(object sender, Android.Locations.LocationChangedEventArgs e)
        {
            var location = e.Location;

            latText.Text = location.Latitude.ToString();
            lngText.Text = location.Longitude.ToString();
            altText.Text = location.Altitude.ToString();
            speedText.Text = location.Speed.ToString();
        }

        protected override void OnResume()
        {
            base.OnResume();
            var intent = new Intent(this, typeof(LocationService));
            BindService(intent, lsConnection, Bind.AutoCreate);
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnbindService(lsConnection);
        }

        void ClearScreen ()
        {
            latText.Text = lngText.Text = altText.Text = speedText.Text = string.Empty;
        }
    }
}