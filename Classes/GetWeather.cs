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
    }
}
