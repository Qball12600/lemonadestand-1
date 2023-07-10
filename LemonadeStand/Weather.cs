using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    internal class Weather
    {
        string condition;
        int temperature;
        List<string> weatherconditions;
        string predictedForecast;
        
        this.weatherconditions { "sunny", "cloudy", "rainy", "overcast", "clear" };

    Random rnd = new Random();
        int randomIndex = rnd.Next(weatherconditions.Count);
        Day = weather[randomIndex];
    }
}
