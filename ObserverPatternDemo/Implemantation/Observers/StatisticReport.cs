using System;
using System.Collections.Generic;
using System.Linq;
using ObserverPatternEvent.Implemantation.Observable;

namespace ObserverPatternEvent.Implemantation.Observers
{
    /// <summary>
    /// Stat report from sender value from sensors
    /// </summary>
    public class StatisticReport
    {
        private WeatherData weatherData;
        private List<int> temperature;
        private List<int> pressure;
        private List<int> humidity;

        /// <summary>
        /// Constructor 
        /// </summary>
        public StatisticReport()
        {
            temperature = new List<int>();
            pressure = new List<int>();
            humidity = new List<int>();
        }

        /// <summary>
        /// This method call by sender, when information from sensors is updated
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        /// <param name="infoEventArgs sensors</param>
        public void Update(WeatherData sender, WeatherInfoEventArgs infoEventArgs)
        {
            weatherData = sender;
            temperature.Add(infoEventArgs.Temperature);
            pressure.Add(infoEventArgs.Pressure);
            humidity.Add(infoEventArgs.Humidity);            
        }

        /// <summary>
        /// Get staticitic of minimum temperature
        /// </summary>
        /// <returns>minimum temperature value</returns>
        public int GetTemperatureMin()
        {
            CheckRules();
            return temperature.Min();
        }

        /// <summary>
        /// Get staticitic of minimum pressure
        /// </summary>
        /// <returns>minimum pressure value</returns>
        public int GetPressureMin()
        {
            CheckRules();
            return pressure.Min();
        }

        /// <summary>
        /// Get staticitic of minimum humidity
        /// </summary>
        /// <returns>minimum humidity value</returns>
        public int GetHumidityMin()
        {
            CheckRules();
            return humidity.Min();
        }

        /// <summary>
        /// Get staticitic of maximum temperature
        /// </summary>
        /// <returns>minimum maximum value</returns>
        public int GetTemperatureMax()
        {
            CheckRules();
            return temperature.Max();
        }

        /// <summary>
        /// Get staticitic of maximum pressure
        /// </summary>
        /// <returns>minimum pressure value</returns>
        public int GetPresureMax()
        {
            CheckRules();
            return pressure.Max();
        }

        /// <summary>
        /// Get staticitic of maximum humidity
        /// </summary>
        /// <returns>maximum humidity value</returns>
        public int GetHumidityMax()
        {
            CheckRules();
            return humidity.Max();
        }

        /// <summary>
        /// Get staticitic of average temperature
        /// </summary>
        /// <returns>average temperature value</returns>
        public int GetTemperatureAverage()
        {
            CheckRules();
            int tempC = 0;
            foreach (var t in temperature)
            {
                tempC += t;
            }

            return tempC / (temperature.Count);
        }

        /// <summary>
        /// Get staticitic of average pressure
        /// </summary>
        /// <returns>average pressure value</returns>
        public int GetPressureAverage()
        {
            CheckRules();
            int press = 0;
            foreach (var p in pressure)
            {
                press += p;
            }

            return press / (pressure.Count);
        }

        /// <summary>
        /// Get staticitic of average humidity
        /// </summary>
        /// <returns>average humidity value</returns>
        public int GetHumidityAverage()
        {
            CheckRules();
            int hum = 0;
            foreach (var h in humidity)
            {
                hum += h;
            }

            return hum / (humidity.Count);
        }

        private void CheckRules()
        {
            if (weatherData == null)
            {
                throw new ArgumentNullException("Information from sensors is absent");
            }
        }
    }
}
