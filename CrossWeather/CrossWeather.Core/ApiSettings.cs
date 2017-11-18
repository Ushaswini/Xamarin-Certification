using Android.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core
{
    class ApiSettings
    {
        public static string GetUrl(string city)
        {
            string apiKey = "39ddbcd40540f840453eabee713e1da5";
            Log.Debug("demo", $"http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + apiKey);
            return $"http://api.openweathermap.org/data/2.5/forecast?q=" + city + "&appid=" + apiKey;
        }
    }
}
