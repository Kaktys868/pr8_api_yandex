using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Yandex_True.Models
{
    //это для геокодинга
    public class GeocodingResponse
    {
        public Response Response { get; set; }
    }

    public class Response
    {
        public GeoObjectCollection GeoObjectCollection { get; set; }
    }

    public class GeoObjectCollection
    {
        public FeatureMember[] FeatureMember { get; set; }
    }

    public class FeatureMember
    {
        public GeoObject GeoObject { get; set; }
    }

    public class GeoObject
    {
        public Point Point { get; set; }
    }

    public class Point
    {
        public string Pos { get; set; }
    }
    //это для погодыы
    public class DataResponce
    {
        public List<Forecast> forecasts { get; set; }
    }
    public class Forecast
    {
        public DateTime date { get; set; }
        public List<Hour> hours { get; set; }
    }
    public class City
    {
        public string name { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
    }
        public class Hour
    {
        public string hour { get; set; }
        public string condition { get; set; }
        public int humidity { get; set; }
        public int prec_type { get; set; }
        public int temp { get; set; }
        public string ToCondition()
        {
            string result = "";
            switch (this.condition)
            {
                case "clear":
                    result = "ясно";
                    break;
                case "partly-cloudy":
                    result = "малооблачно";
                    break;
                case "cloudy":
                    result = "облачно с прояснениями";
                    break;
                case "overcast":
                    result = "пасмурно";
                    break;
                case "light-rain":
                    result = "небольшой дождь";
                    break;
                case "rain":
                    result = "дождь";
                    break;
                case "heavy-rain":
                    result = "сильный дождь";
                    break;
                case "showers":
                    result = "ливень";
                    break;
                case "wet-snow":
                    result = "дождь со снегом";
                    break;
                case "light-snow":
                    result = "небольшой снег";
                    break;
                case "snow":
                    result = "снег";
                    break;
                case "snow-showers":
                    result = "снегопад";
                    break;
                case "hail":
                    result = "град";
                    break;
                case "thundershtorm":
                    result = "гроза";
                    break;
                case "thunderstorm-with-rain":
                    result = "дождь с грозой";
                    break;
                case "thunderstorm-with-hail":
                    result = "гроза с градом";
                    break;
            }
            return result;
        }
        public string ToPrecType()
        {
            string result = "";
            switch (this.prec_type)
            {
                case 0:
                    result = "без осадков";
                    break;
                case 1:
                    result = "дождь";
                    break;
                case 2:
                    result = "дождь со снегом";
                    break;
                case 3:
                    result = "снег";
                    break;
            }
            return result;
        }
    }
}