using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace RoboSub.Internal_Model
{
    class ConditionsLogger
    {

        public static String[] WEATHER_BOARD_FIELDS = { "humidity", "temperature 1", "temperature 2",
                                                        "temperature 3", "pressure", "light", "battery", "record number" };
        public static bool KEEP_GATHERING_DATA = true;
        static System.IO.Ports.SerialPort port;
        static string comPort = "Com20";//change this to reflect current connected port

        public void GatherDataAndOutputToFile()
        {
            //access weatherboard serial port, com number must be set manually
            port = new System.IO.Ports.SerialPort(comPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            //port.Close();
            //while (port.IsOpen) { }//loop until port is actually closed
            port.Open();

            //set up output file
            StreamWriter writer = new StreamWriter("C:/RoboSub/WeatherData.csv", true);
            writer.WriteLine("Data Start at " + System.DateTime.Now);
            foreach (string s in WEATHER_BOARD_FIELDS)
            {
                writer.Write(s + ",");
            }
            writer.WriteLine();

            //output data to screen and file
            string input;
            double[] data;
            while (!KEEP_GATHERING_DATA)//exit loop if any key is pressed
            {
                input = port.ReadLine();
                data = ConvertWeatherInput(input);

                //output comma separated values
                foreach (double d in data)
                {
                    writer.Write(d + ",");
                }
                //add dew point and newline
                writer.WriteLine(RSMath.TemperatureMath.getDewPoint(input[2], input[0]));

                //flush writer to ensure data is written in case of crash
                writer.Flush();

                //write output to console window
                //OutputWeather(data);

                //wait a half second between logged events
                System.Threading.Thread.Sleep(500);
            }

            //clean up output file
            writer.WriteLine("End of data - file closed normally at " + System.DateTime.Now);
            writer.WriteLine();
            writer.Close();
        }

        public static void Main()
        {
            //access weatherboard serial port, com number must be set manually
            port = new System.IO.Ports.SerialPort(comPort, 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            //port.Close();
            //while (port.IsOpen) { }//loop until port is actually closed
            port.Open();

            //set up output file
            StreamWriter writer = new StreamWriter("C:\\WeatherData.csv", true);
            writer.WriteLine("Data Start at " + System.DateTime.Now);
            foreach (string s in WEATHER_BOARD_FIELDS)
            {
                writer.Write(s + ",");
            }
            writer.WriteLine();

            //output data to screen and file
            string input;
            string output;
            double[] data;
            while (!System.Console.KeyAvailable)//exit loop if any key is pressed
            {
                input = port.ReadLine();
                data = ConvertWeatherInput(input);

                //output comma separated values
                //foreach (double d in data)
                //{
                //    writer.Write(d + ",");
                //}
                ////add dew point and newline
                //writer.WriteLine(RSMath.TemperatureMath.getDewPoint(input[2], input[0]));

                ////flush writer to ensure data is written in case of crash
                //writer.Flush();

                //write output to console window
                //OutputWeather(data);

                //wait a half second between logged events
                System.Threading.Thread.Sleep(2000);
            }

            //clean up output file
            //writer.WriteLine("End of data - file closed normally");
            //writer.Close();

            //indicate normal close
            System.Console.WriteLine("Process ended succesfully. Press Return to exit.");

            System.Console.ReadLine();//empty console input
        }

        /// <summary>
        /// Takes an input string from the weather board and returns an array
        /// of doubles.
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static double[] ConvertWeatherInput(String input)
        {
            double[] values = new double[8];
            StringBuilder working = new StringBuilder();
            int position = -1;
            foreach (char c in input.ToCharArray())
            {
                if (position < 0)
                {
                    if (c == '#')
                    {
                        position = 0;
                    }
                }
                else
                {
                    if (c == '$')
                    {
                        break;
                    }
                    else if (c == ',')
                    {
                        values[position] = Double.Parse(working.ToString());
                        position++;
                        working.Clear();
                    }
                    else
                    {
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
        public static void OutputWeather(double[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                System.Console.WriteLine("" + WEATHER_BOARD_FIELDS[i] + ": " + input[i]);
            }
            System.Console.WriteLine("Dew point: " + RSMath.TemperatureMath.getDewPoint(input[2], input[0]));
            System.Console.WriteLine();
        }
    }
}
