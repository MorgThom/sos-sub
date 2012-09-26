using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RoboSub.RemoteControl;
using Pololu.UsbWrapper;
using Pololu.Jrk;
using RoboSub.Internal_Model;

namespace RoboSub.Movement
{
    class DirectMotorLinkTest
    {

        List<Motor> motors = new List<Motor>();
        List<Motor> xMotors = new List<Motor>();
        List<Motor> yMotors = new List<Motor>();
        List<Motor> zMotors = new List<Motor>();
        List<Motor> pitchMotors = new List<Motor>();
        List<Motor> rollMotors = new List<Motor>();
        List<Motor> yawMotors = new List<Motor>();

        public static void Main()
        {
            //new Thread(new DirectMotorLinkTest().runTests).Start();
            new Thread(new DirectMotorLinkTest().boxTest).Start();
            //new Thread(ConditionsLogger.Main).Start();
        }

        public void boxTest()
        {
            //get all the connected motors and instantiate them
            List<DeviceListItem> devices = Jrk.getConnectedDevices();
            Motor current;
            foreach (DeviceListItem d in devices)
            {
                System.Console.WriteLine("Checking device " + d.serialNumber);
                //if the found device matches the expected serial number, proceed with initialization
                foreach (MotorInfo info in HandCodeMotorConstants.handCodedMotors)
                {
                    if (info.serial.Equals(d.serialNumber))
                    {
                        System.Console.WriteLine("Found motor " + info.serial);
                        current = new Motor(info, new Jrk(d));
                        motors.Add(current);
                        if (info.horzTheta < 0.1 && info.horzTheta > -0.1 && info.vertTheta < 0.1 && info.vertTheta > -0.1)
                        {
                            xMotors.Add(current);
                        }
                        if (info.horzTheta < 1.1 && info.horzTheta > 0.9 && info.vertTheta < 0.1 && info.vertTheta > -0.1)
                        {
                            yMotors.Add(current);
                        }
                        if (info.horzTheta < 0.1 && info.horzTheta > -0.1 && info.vertTheta < 1.1 && info.vertTheta > 0.9)
                        {
                            zMotors.Add(current);
                        }
                    }
                }
            }

            int time = 2000;//how many milliseconds to run for

            //wait before starting tests
            //System.Threading.Thread.Sleep(time);


            //System.Console.WriteLine("Starting box drive test");
            //System.Console.WriteLine("Diving.");
            //dive();
            //System.Threading.Thread.Sleep(time);

            //foreach (Motor m in motors)
            //{
            //    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //    m.KillMotors();
            //}
            //System.Console.WriteLine("Forward.");
            //driveForward();
            //System.Threading.Thread.Sleep(time);


            //foreach (Motor m in motors)
            //{
            //    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //    m.KillMotors();
            //}
            //System.Console.WriteLine("Backward.");
            //driveBackwards();
            //System.Threading.Thread.Sleep(time);


            //foreach (Motor m in motors)
            //{
            //    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //    m.KillMotors();
            //}

            ConsoleKey key = ConsoleKey.P;
            System.Console.WriteLine("Ready for input");
            while (key != ConsoleKey.Q)
            {
                key = Console.ReadKey().Key;
                time = 2000;//in milliseconds
                switch (key)
                {
                    case ConsoleKey.W:
                        System.Console.WriteLine("\nDriving Forward");
                        driveForward();
                        break;
                    case ConsoleKey.S:
                        System.Console.WriteLine("\nDriving Backwards");
                        driveBackwards();
                        break;
                    case ConsoleKey.R:
                        System.Console.WriteLine("\nSurfacing");
                        surface();
                        break;
                    case ConsoleKey.F:
                        System.Console.WriteLine("\nDiving");
                        dive();
                        break;
                    case ConsoleKey.P:
                        System.Console.WriteLine("\nKilling Peasants");
                        foreach (Motor m in motors)
                        {
                            System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                            m.KillMotors();
                        }
                        break;
                }
            }


            //System.Console.WriteLine("Surface.");
            //surface();
            //System.Threading.Thread.Sleep(time);

            //foreach (Motor m in motors)
            //{
            //    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //    m.KillMotors();
            //}

            //System.Console.WriteLine("Press Enter to quit.");
            //System.Console.ReadLine();
        }

        public void driveBackwards()
        {
            backwards = true;
            foreach (Motor m in xMotors)
            {
                // System.Console.WriteLine("Testing motor " + m.info.serial + ".");

                testing = m;
                //TestMotor(m);
                new Thread(new DirectMotorLinkTest().TestMotor).Start();
                System.Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                if (System.Console.KeyAvailable)
                {
                    break;
                }
            }
        }

        public void dive()
        {
            backwards = false;
            foreach (Motor m in zMotors)
            {
                // System.Console.WriteLine("Testing motor " + m.info.serial + ".");

                testing = m;
                //TestMotor(m);
                new Thread(new DirectMotorLinkTest().TestMotor).Start();
                System.Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                if (System.Console.KeyAvailable)
                {
                    break;
                }
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void surface()
        {
            backwards = true;
            foreach (Motor m in zMotors)
            {
                //  System.Console.WriteLine("Testing motor " + m.info.serial + ".");

                testing = m;
                //TestMotor(m);
                new Thread(new DirectMotorLinkTest().TestMotor).Start();
                System.Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                if (System.Console.KeyAvailable)
                {
                    break;
                }
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void driveForward()
        {
            backwards = false;
            foreach (Motor m in xMotors)
            {
                //  System.Console.WriteLine("Testing motor " + m.info.serial + ".");

                testing = m;
                //TestMotor(m);
                new Thread(new DirectMotorLinkTest().TestMotor).Start();
                System.Console.WriteLine();
                System.Threading.Thread.Sleep(500);
                if (System.Console.KeyAvailable)
                {
                    break;
                }
            }
            System.Threading.Thread.Sleep(1000);
        }

        public void runTests()
        {

            //get all the connected motors and instantiate them
            List<DeviceListItem> devices = Jrk.getConnectedDevices();
            foreach (DeviceListItem d in devices)
            {
                System.Console.WriteLine("Checking device " + d.serialNumber);
                //if the found device matches the expected serial number, proceed with initialization
                foreach (MotorInfo info in HandCodeMotorConstants.handCodedMotors)
                {
                    if (info.serial.Equals(d.serialNumber))
                    {
                        System.Console.WriteLine("Found motor " + info.serial);
                        motors.Add(new Motor(info, new Jrk(d)));
                    }
                }
            }



            //run random tests
            // do
            {
                foreach (Motor m in motors)
                {
                    System.Console.WriteLine("Testing motor " + m.info.serial + ".");

                    testing = m;
                    //TestMotor(m);
                    new Thread(new DirectMotorLinkTest().TestMotor).Start();
                    System.Console.WriteLine();
                    System.Threading.Thread.Sleep(500);
                    if (System.Console.KeyAvailable)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(10000);
            }// while (!System.Console.KeyAvailable);
            System.Console.WriteLine("Press Enter to quit.");
            System.Console.ReadLine();
        }

        static Motor testing;
        static bool backwards = false;

        private void TestMotor()
        {
            TestMotor(testing);
        }

        public DirectMotorLinkTest()
        {
        }

        /// <summary>
        /// Runs the given motor several random different speeds.
        /// </summary>
        /// <param name="m"></param>
        private void TestMotor(Motor m)
        {
            m.info.controller.setJrkParameter(jrkParameter.PARAMETER_FEEDBACK_MODE, 0);
            m.info.controller.reinitialize();
            System.Console.WriteLine("Status:");
            foreach (String s in m.GetStatus())
            {
                System.Console.WriteLine(s);
            }

            Random rng = new Random();
            sbyte speed;
            //for (int i = 0; i < 5; i++)
            {
                //speed = (sbyte)(rng.Next(101));//only test half speed max
                speed = -100;
                if (backwards)
                {
                    speed *= -1;
                }
                m.RequestSpeed(speed);
                System.Console.WriteLine("Target speed: " + (2047 + speed * 20) + "   ");
                //System.Threading.Thread.Sleep(10000000);
                List<String> output = m.GetStatus();
                System.Console.WriteLine("Motor target: " + output.ElementAt(0) + "  current: " + output.ElementAt(1)
                    + " duty cycle: " + output.ElementAt(2));
                System.Console.WriteLine();
            }
            //m.RequestSpeed(0);//set motor to stop

            //stop the motor when done testing
            // m.KillMotors();
        }
    }
}
