using System;

namespace ArifWeather.Models
{
    public class ErrorPage
    {
        /// <summary>
        /// Current time when exception happened.
        /// </summary>
        public string CurrentExceptionDateTime { get; set; }
        
        /// <summary>
        /// Exception objects
        /// </summary>
        public Exception CurrentException { get; set; }
    }
}