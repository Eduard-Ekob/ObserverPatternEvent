namespace ObserverPatternEvent.Implemantation.Observable
{
    public class WeatherInfoEventArgs : EventInfo
    {
        public WeatherInfoEventArgs(int temperature, int pressure, int humidity)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
        }

        public int Temperature { get; set; }
        public int Humidity { get; set; }
        public int Pressure { get; set; }
    }
}