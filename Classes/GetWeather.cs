using Api_Yandex_True.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api_Yandex_True.Classes
{
    public class GetWeather
    {
        public static string Url = "https://api.weather.yandex.ru/v2/forecast";
        public static string Key = "demo_yandex_weather_api_key_ca6d09349ba0";

        public static async Task<DataResponce> Get(float lat, float lon)
        {
            DataResponce dataResponse = null;
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage Request = new HttpRequestMessage(
                    HttpMethod.Get,
                    $"{Url}?lat={lat}&lon={lon}".Replace(",", ".")))
                {
                    Request.Headers.Add("X-Yandex-Weather-Key", Key);

                    using (var Response = await Client.SendAsync(Request))
                    {
                        string ContentResponse = await Response.Content.ReadAsStringAsync();
                        dataResponse = JsonConvert.DeserializeObject<DataResponce>(ContentResponse);
                    }
                }
            }
            return dataResponse;
        }

        public static async Task<DataResponce> City(string city)
        {
            float lat = 0, lon = 0;
            string url = $"https://geocode-maps.yandex.ru/v1/?apikey=8e9e7022-52e6-4811-a6a0-950075beb89e&geocode={city}&lang=ru_RU&format=json";
            using (HttpClient Client = new HttpClient())
            {
                using (HttpRequestMessage Request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    using (var Response = await Client.SendAsync(Request))
                    {
                        string ContentResponse = await Response.Content.ReadAsStringAsync();
                        var geocodeResponse = JsonConvert.DeserializeObject<GeocodingResponse>(ContentResponse);
                        var pointStr = geocodeResponse.Response.GeoObjectCollection.FeatureMember?.FirstOrDefault()?.GeoObject?.Point?.Pos;
                        if (pointStr != null)
                        {
                            var coords = pointStr.Split(' ');
                            if (coords.Length == 2)
                            {
                                float.TryParse(coords[1], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lon);
                                float.TryParse(coords[0], System.Globalization.NumberStyles.Float, System.Globalization.CultureInfo.InvariantCulture, out lat);
                            }
                        }
                    }
                }
            }

            return await Get(lat, lon);
        }
    }
}
