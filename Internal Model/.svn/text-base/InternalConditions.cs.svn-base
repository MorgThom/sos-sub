using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace RoboSub.Internal_Model
{

    /// <summary>
    /// Currently just attempting to pull live data from weather board. Accessing the board through PuTTY gives the
    /// expected output stream, while following code does not receive any output. Is there an init step missing?
    /// </summary>
    class InternalConditions
    {
        private SerialPort weatherPort;

        InternalConditions()
        {
            //verify available ports through printout
            string[] ports = SerialPort.GetPortNames();
            foreach (string s in ports)
            {
                System.Console.WriteLine(s);
            }

            weatherPort = new SerialPort("COM7", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
            weatherPort.ReadTimeout = 500;
            weatherPort.Close();
            weatherPort.Open();
            if (weatherPort.IsOpen)
            {
                System.Console.WriteLine("Port open!");
                char[] readStream = new char[255];
                byte commaCount = 0;
                int availableBytes;

                while (true)
                {
                    /* System.Threading.Thread.Sleep(500);//give the board long enough to poll data
                     availableBytes = Math.Min(255,weatherPort.BytesToRead);
                     weatherPort.Read(readStream, 0, availableBytes);
                     for (int i = 0; i < availableBytes; i++)
                     {
                         System.Console.Write(readStream[i]);
                     }
                     System.Console.WriteLine();*/

                    try
                    {
                        System.Console.Write(weatherPort.ReadChar());
                    }
                    catch (TimeoutException)
                    {
                        System.Console.WriteLine("Timed out.");
                    }

                    //System.Console.WriteLine("Data: " + weatherPort.ReadExisting());
                }

            }
            else
            {
                System.Console.WriteLine("Port not open.");
            }
            System.Console.ReadLine();
        }

        static void Main()
        {
            new InternalConditions();
        }
    }

}
