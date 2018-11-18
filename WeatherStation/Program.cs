using System;
using System.Threading;
using ObserverPatternEvent.Implemantation.Observable;
using ObserverPatternEvent.Implemantation.Observers;

namespace WeatherStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var sender = new WeatherData();
            var currentConditionsReport = new CurrentConditionsReport();
            var statisticReport = new StatisticReport();

            //Subscribe
            sender.WeatherDataChandged += currentConditionsReport.Update;
            sender.WeatherDataChandged += statisticReport.Update;
            

            var weatherInfoEventArgs = new WeatherInfoEventArgs(20, 740, 75);
            sender.NewWeatherDataAvailable(weatherInfoEventArgs);
            Console.WriteLine("Temperature {0}, Pressure {1}, Humidity {2}",
                currentConditionsReport.WthrInfo.Temperature,
                currentConditionsReport.WthrInfo.Pressure,
                currentConditionsReport.WthrInfo.Humidity);
            sender.NewWeatherDataAvailable(weatherInfoEventArgs);
            
            // WeatherStation emulation            
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(10);
                weatherInfoEventArgs = new WeatherInfoEventArgs(
                    rnd.Next(-3, 20), 
                    rnd.Next(730, 780), 
                    rnd.Next(60, 95));                                 
                sender.NewWeatherDataAvailable(weatherInfoEventArgs);
                Console.WriteLine("Temperature {0}, Pressure {1}, Humidity {2}", 
                    currentConditionsReport.WthrInfo.Temperature,
                    currentConditionsReport.WthrInfo.Pressure,
                    currentConditionsReport.WthrInfo.Humidity);
            }

            Console.WriteLine();
            Console.WriteLine("Stat report:");
            Console.WriteLine("MinTemperature: {0}", statisticReport.GetTemperatureMin());
            Console.WriteLine("MaxTemperature: {0}", statisticReport.GetTemperatureMax());
            Console.WriteLine("MinPressure: {0}", statisticReport.GetPressureMin());
            Console.WriteLine("MaxPressure: {0}", statisticReport.GetPresureMax());
            Console.WriteLine("MinHumidity: {0}", statisticReport.GetHumidityMin());
            Console.WriteLine("MinHumidity: {0}", statisticReport.GetHumidityMax());
            Console.WriteLine("AverageTemperature: {0}", statisticReport.GetTemperatureAverage());
            Console.WriteLine("AveragePressure: {0}", statisticReport.GetPressureAverage());
            Console.WriteLine("AverageHumidity: {0}", statisticReport.GetHumidityAverage());

            //Unsubscribe
            Console.WriteLine("Unsubscribe");
            sender.WeatherDataChandged -= currentConditionsReport.Update;
            weatherInfoEventArgs = new WeatherInfoEventArgs(20, 740, 75);
            sender.NewWeatherDataAvailable(weatherInfoEventArgs);
            Console.WriteLine("Temperature: {0}", currentConditionsReport.WthrInfo.Temperature);

            //Subscribe
            Console.WriteLine("Subscribe");
            Thread.Sleep(1000);
            sender.WeatherDataChandged += currentConditionsReport.Update;
            weatherInfoEventArgs = new WeatherInfoEventArgs(20, 740, 75);
            sender.NewWeatherDataAvailable(weatherInfoEventArgs);
                       
            Console.WriteLine("Temperature: {0}", currentConditionsReport.WthrInfo.Temperature);

            Console.ReadLine();
        }
    }
}
