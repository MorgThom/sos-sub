using System;
using Phidgets;
using Phidgets.Events;
using System.IO.Ports;

namespace RoboSub
{
	public class IMU
	{
		Spatial imu = new Spatial();
		public IMU ()
		{			
			imu.open(145989);
			imu.SpatialData += new Phidgets.Events.SpatialDataEventHandler(OnDataRecieved);
       
		}

		private void OnDataRecieved(Object sender, Phidgets.Events.SpatialDataEventArgs e)
		{
			Console.WriteLine();
		}

		public static void Main()
		{
            SerialPort port = new SerialPort("COM57", 9600, Parity.None, 8, StopBits.One);
            port.Open();
            port.Write("Starting IMU");
			IMU myImu = new IMU();
            while (true)
            {
                Console.WriteLine("Waiting");
                System.Threading.Thread.Sleep(1000);
            }
		}
	}
}

