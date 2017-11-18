using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossWeather.Core
{
    public class WeatherRepository
    {
        private string url;
        //ctor and tab twice to insert constructor
        public WeatherRepository(string city)
        {

            url = ApiSettings.GetUrl(city);
            
        }

        public async Task<WeatherRoot> GetWeather()
        {
            WeatherRoot weather = null;

            //add nuget pacakages - httpclient and json

            using(var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);

                await Task.Run(() => {
                    weather = JsonConvert.DeserializeObject<WeatherRoot>(json);
                });

            }

            return weather;
        }

    }
}
