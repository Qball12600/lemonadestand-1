using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace LemonadeStand
{
    //single responsibility principle SOLID
    internal class Weather
    {
       
        //Member Variables
        public string Forecast { get; set; }
        public int ForecastTemperature { get; set; }
        public List<string> WeatherConditions { get; set; }
        public string PredictedForecast { get; set; }

        //Constructor
       
        
    }
}
