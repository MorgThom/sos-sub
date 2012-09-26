using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.Exceptions;

namespace RoboSub.RSMath
{
    static class TemperatureMath
    {
        /// <summary>
        /// Calculates the dew point based on relative humidity and temperature;
        /// Only accurate while temperature between 0 and 60 Celsius, and while RH is between 1 and 100 percent.
        /// </summary>
        /// <param name="temp">The current temperature</param>
        /// <param name="RH">The current relative humidity</param>
        /// <returns>The dew point, the temperature at which water vapor will condense.</returns>
        public static double getDewPoint(double temp, double RH)
        {
            //necessary constants
            const double a = 17.271;
            const double b = 237.7;
            double gamma;
            gamma = (a * RH) / (b + temp) + Math.Log(RH/100);
            return (b * gamma) / (a - gamma);
        }
    }
}
