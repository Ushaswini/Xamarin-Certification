using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using CrossWeather.Core;
using System.Linq;

namespace CrossWeather.Droid
{
    [Activity(Label = "CrossWeather.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        EditText etCity;
        TextView tvLatitude;
        TextView tvLongitude;
        TextView tvCurrentTemperature;
        Button btnGetWeather;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            etCity = FindViewById<EditText>(Resource.Id.et_city);
            tvLatitude = FindViewById<TextView>(Resource.Id.tv_latitude);
            tvLongitude = FindViewById<TextView>(Resource.Id.tv_longitude);
            tvCurrentTemperature = FindViewById<TextView>(Resource.Id.tv_temperature);
            btnGetWeather = FindViewById<Button>(Resource.Id.btn_getWeather);

            btnGetWeather.Click += async (sender, e) => {
                var repository = new WeatherRepository(etCity.Text);
                var weather = await repository.GetWeather();
                tvLongitude.Text = $"Longitude: {weather?.city?.coord?.lon.ToString()}";
                tvLatitude.Text = $"Latitude : {weather?.city?.coord?.lat.ToString()}";
                tvCurrentTemperature.Text = $"Current Temp : {weather?.list?.FirstOrDefault()?.main?.temp.ToString()}";

            };

            
        }

        private void BtnGetWeather_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}

