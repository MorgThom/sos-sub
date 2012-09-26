using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.Internal_Model {
    class WeatherBoard {


        public static String[] WEATHER_BOARD_FIELDS = { "humidity", "temperature 1", "temperature 2",
                                                        "temperature 3", "pressure", "light", "battery", "record number" };
        static System.IO.Ports.SerialPort port;

        public static void Main() {
            port = new System.IO.Ports.SerialPort("Com3", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            port.Close();
            port.Open();
            while (true) {
                OutputWeather(ConvertWeatherInput(port.ReadLine()));
            }
        }

        /// <summary>
        /// Takes an input string from the weather board and returns an array
        /// of doubles.
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] ConvertWeatherInput(String input) {
            double[] values = new double[8];
            StringBuilder working = new StringBuilder();
            int position = -1;
            foreach (char c in input.ToCharArray()) {
                if (position < 0) {
                    if (c == '#') {
                        position = 0;
                    }
                } else {
                    if (c == '$') {
                        break;
                    } else if (c == ',') {
                        values[position] = Double.Parse(working.ToString());
                        position++;
                        working.Clear();
                    } else {
                        working.Append(c);
                    }
                }
            }
            return values;
        }


        /// <summary>
        /// Displays a verbose version of the weather information to the console.
        /// </summary>
        /// <param name="input"></param>
        public static void OutputWeather(double[] input) {
            for (int i = 0; i < input.Length; i++) {
                System.Console.WriteLine("" + WEATHER_BOARD_FIELDS[i] + ": " + input[i]);
            }
            System.Console.WriteLine("Dew point: " + RSMath.TemperatureMath.getDewPoint(input[2], input[0]));
            System.Console.WriteLine();
        }
    }


}
