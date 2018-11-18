using System;
using System.Collections;
using System.Collections.Generic;

namespace ObserverPatternEvent.Implemantation.Observable
{
    public delegate void WeatherDataChangedEventHandler(WeatherData sender, WeatherInfoEventArgs e);
    public class WeatherData
    {     
        public event WeatherDataChangedEventHandler WeatherDataChandged;

        public void NewWeatherDataAvailable(WeatherInfoEventArgs weatherInfoEventArgs)
        {
            if (WeatherDataChandged != null)
            {
                int tempC = weatherInfoEventArgs.Temperature;
                int press = weatherInfoEventArgs.Pressure;
                int hum = weatherInfoEventArgs.Humidity;
                WeatherDataChandged(this, new WeatherInfoEventArgs(tempC, press, hum));
            }
        }
    }
}