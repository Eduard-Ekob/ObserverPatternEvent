using System;
using ObserverPatternEvent.Implemantation.Observable;

namespace ObserverPatternEvent.Implemantation.Observers
{
    /// <summary>
    /// The obsercer which subscribe on weatherdata
    /// </summary>
    public class CurrentConditionsReport
    {        
        private WeatherInfoEventArgs wthrInfo;

        /// <summary>
        /// property contains current value for indication
        /// </summary>
        /// <exception cref="ArgumentNullException">If indicator not connected to sender
        /// throw ArgumentNullException</exception>
        public WeatherInfoEventArgs WthrInfo
        {
            get
            {
                if (wthrInfo == null)
                {
                    throw new ArgumentNullException("Not connected to sender");
                }
                
                return wthrInfo;
            }
        }           

        /// <summary>
        /// This method call by sender, when information from sensors is updated
        /// </summary>
        /// <param name="sender">sender value from sensors</param>
        /// <param name="infoEventArgs>
        public void Update(WeatherData sender, WeatherInfoEventArgs infoEventArgs)
        {
            wthrInfo = infoEventArgs;
        }
    }
}