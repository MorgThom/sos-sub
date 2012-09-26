using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RoboSub.RemoteControl;
using Pololu.UsbWrapper;
using Pololu.Jrk;
using RoboSub.Internal_Model;
using RoboSub.Vision;
using Emgu.CV.UI;
using Emgu.CV;
using System.Windows.Forms;
using System.Drawing;

namespace RoboSub.Movement
{
    class DirectMotorLink
    {
        /*The rotation methods all need to be adjusted to properly use x,y,z and theta to know which direction to turn, and then test them!
         * Probably also need to use negative thetas where appropriate in the hand code motors to do this properly
         * 
         * 
         */

        static List<Motor> motors = new List<Motor>();
        static List<Motor> xMotors = new List<Motor>();
        static List<Motor> yMotors = new List<Motor>();
        static List<Motor> zMotors = new List<Motor>();
        static List<Motor> pitchMotors = new List<Motor>();
        static List<Motor> rollMotors = new List<Motor>();
        static List<Motor> yawMotors = new List<Motor>();
        private AI.Brain brain;
        public static bool killed = false;
        private sbyte changingSpeed = 25;

        public DirectMotorLink(AI.Brain brain)
        {
            this.brain = brain;
        }

        public DirectMotorLink(sbyte inspeed)
        {
            changingSpeed = inspeed;
        }

        public static void Main()
        {
            //new Thread(new DirectMotorLinkTest().runTests).Start();

            //Thread eyes = new Thread(Vision.USBCamTest.Main);
            //eyes.Start();
            //Thread props = new Thread(new DirectMotorLinkTest().boxTest);
            //props.Start();
            //while (!System.Console.KeyAvailable)
            //{

            //}//spinlock until a key is hit
            //props.Abort();
            //eyes.Abort();
            //foreach (Motor m in motors)
            //{
            //    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //    m.KillMotors();
            //}

            //new Thread(ConditionsLogger.Main).Start();

            //new Thread(new DirectMotorLinkTest().singleMotorTest).Start();

            //new Thread(new DirectMotorLink().DriveAndRecordImageTest).Start();


            new Thread(new DirectMotorLink().MotorSetsTest).Start();
        }

        public void DriveAndRecordImageTest()
        {
            InitializeMotors();
            DriveForward();

            // testCam();
            ImageViewer viewer = new ImageViewer(); //create an image viewer
            Capture capture = new Capture(3);
            long frame = 0;
            long time = DateTime.Now.Second;
            Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
            {
                if (time + 1 < DateTime.Now.Second)
                {
                    capture = new Capture(3);
                    time = DateTime.Now.Second;
                    capture.QueryFrame().Save("C:/RoboSub/Images/movingTest/forwardFrame" + frame + ".png");
                    frame++;
                }
                viewer.Image = capture.QueryFrame();
            });
            viewer.ShowDialog();

            foreach (Motor m in motors)
            {
                //System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                m.KillMotors();
            }
        }

        public void singleMotorTest()
        {
            InitializeMotors();

            long time;
            int numberOfMotors = motors.Count;
            int selection;
            char key = 'P';
            System.Console.WriteLine();
            System.Console.WriteLine("Single Motor Control Test");
            System.Console.WriteLine("Type motor index to start that motor.");
            System.Console.WriteLine("Type 'q' to quit program.");
            System.Console.WriteLine("Type any other key to stop all motors.");
            while (key != 'q')
            {
                key = Console.ReadKey(true).KeyChar;
                time = 2000;//in milliseconds
                if (Int32.TryParse(key.ToString(), out selection))
                {
                    System.Console.WriteLine("Index selected: " + selection);
                    if (selection >= motors.Count)
                    {
                        continue;
                    }

                    //fire selected motor
                    changingMotor = motors[selection];
                    //TestMotor(m);
                    new Thread(new DirectMotorLink().TestMotor).Start();
                    System.Console.WriteLine();
                    System.Console.WriteLine("Serial: " + motors[selection].info.serial);
                    System.Threading.Thread.Sleep(500);
                    if (System.Console.KeyAvailable)
                    {
                        break;
                    }
                }
                else
                {
                    KillAllMotors();
                }
            }
            foreach (Motor m in motors)
            {
                System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                m.KillMotors();
            }
        }

        public static void InitializeMotors()
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
                        if (info.horzTheta == 0 && info.vertTheta == 0)
                        {
                            xMotors.Add(current);
                        }
                        if (info.horzTheta != 0 && info.vertTheta == 0)
                        {
                            yMotors.Add(current);
                        }
                        if (info.horzTheta == 0 && info.vertTheta != 0)
                        {
                            zMotors.Add(current);
                        }

                        //yaw if horizontal angle

                    }
                }
            }
        }

        public void MotorSetsTest()
        {
            InitializeMotors();

            char key = 'p';
            System.Console.WriteLine("Ready for input");
            System.Console.WriteLine("w - forward, s - backward");
            System.Console.WriteLine("a - left, d - right");
            System.Console.WriteLine("r - surface, f - dive");
            System.Console.WriteLine("q - rotate left, e - rotate right");
            System.Console.WriteLine("t - pitch down, g - pitch up");
            System.Console.WriteLine("Q - quit, p - stop all motors");
            while (key != 'Q')
            {
                key = Console.ReadKey(true).KeyChar;
                switch (key)
                {
                    case 'w':
                        System.Console.WriteLine("\nDriving Forward");
                        KillAllMotors();
                        DriveForward();
                        break;
                    case 's':
                        System.Console.WriteLine("\nDriving Backwards");
                        KillAllMotors();
                        DriveBackwards();
                        break;
                    case 'r':
                        System.Console.WriteLine("\nSurfacing");
                        KillAllMotors();
                        Surface();
                        break;
                    case 'f':
                        System.Console.WriteLine("\nDiving");
                        Surface();
                        KillAllMotors();
                        Dive();
                        break;
                    case 'a':
                        System.Console.WriteLine("\nStrafing Left");
                        DriveRight();
                        KillAllMotors();
                        DriveLeft();
                        break;
                    case 'd':
                        System.Console.WriteLine("\nStrafing Right");
                        DriveLeft();
                        KillAllMotors();
                        DriveRight();
                        break;
                    case 'q':
                        System.Console.WriteLine("\nRotating Left");
                        YawRight();
                        KillAllMotors();
                        YawLeft();
                        break;
                    case 'e':
                        System.Console.WriteLine("\nRotating Right");
                        YawLeft();
                        KillAllMotors();
                        YawRight();
                        break;
                    case 't':
                        System.Console.WriteLine("\nPitching Down");
                        PitchDown();
                        break;
                    case 'g':
                        System.Console.WriteLine("\nPitching Up");
                        PitchUp();
                        break;
                    case 'p':
                        System.Console.WriteLine("\nKilling Peasants");
                        KillAllMotors();
                        break;
                }
            }
            KillAllMotors();
            Environment.Exit(0);
        }

        public void BoxTest()
        {
            InitializeMotors();

            int time = 2000;//how many milliseconds to run for

            while (true)
            {
                //wait before starting tests
                System.Threading.Thread.Sleep(time);


                System.Console.WriteLine("Starting box drive test");
                System.Console.WriteLine("Diving.");
                Dive();
                System.Threading.Thread.Sleep(time);

                foreach (Motor m in motors)
                {
                    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                    m.KillMotors();
                }
                System.Console.WriteLine("Forward.");
                DriveForward();
                System.Threading.Thread.Sleep(time);


                foreach (Motor m in motors)
                {
                    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                    m.KillMotors();
                }
                System.Console.WriteLine("Backward.");
                DriveBackwards();
                System.Threading.Thread.Sleep(time);
               
                foreach (Motor m in motors)
                {
                    System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                    m.KillMotors();
                }
            }
            //ConsoleKey key = ConsoleKey.P;
            //System.Console.WriteLine("Ready for input");
            //while (key != ConsoleKey.Q)
            //{
            //    key = Console.ReadKey().Key;
            //    time = 2000;//in milliseconds
            //    switch (key)
            //    {
            //        case ConsoleKey.W:
            //            System.Console.WriteLine("\nDriving Forward");
            //            driveForward();
            //            break;
            //        case ConsoleKey.S:
            //            System.Console.WriteLine("\nDriving Backwards");
            //            driveBackwards();
            //            break;
            //        case ConsoleKey.R:
            //            System.Console.WriteLine("\nSurfacing");
            //            surface();
            //            break;
            //        case ConsoleKey.F:
            //            System.Console.WriteLine("\nDiving");
            //            dive();
            //            break;
            //        case ConsoleKey.P:
            //            System.Console.WriteLine("\nKilling Peasants");
            //            foreach (Motor m in motors)
            //            {
            //                System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
            //                m.KillMotors();
            //            }
            //            break;
            //    }
            // }


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

        public static void KillAllMotors()
        {
            foreach (Motor m in motors)
            {
                System.Console.WriteLine("Stopping motor " + m.info.serial + ".");
                m.KillMotors();
             
            }
        }

        public static void YawRight()
        {
            foreach (Motor m in yMotors)
            {
                changingMotor = m;
                backwards = false;
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void YawLeft()
        {
            foreach (Motor m in yawMotors)
            {
                changingMotor = m;
                backwards = true;
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void PitchUp()
        {
            foreach (Motor m in zMotors)
            {
                changingMotor = m;
                if (m.info.xPos > 0)
                {
                    backwards = false;
                }
                else
                {
                    backwards = true;
                }
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void PitchDown()
        {
            foreach (Motor m in pitchMotors)
            {
                changingMotor = m;
                if (m.info.xPos < 0)
                {
                    backwards = false;
                }
                else
                {
                    backwards = true;
                }
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void DriveLeft()
        {
            foreach (Motor m in yMotors)
            {
                changingMotor = m;
                if (m.info.xPos < 0)
                {
                    backwards = true;
                }
                else
                {
                    backwards = false;
                }
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void DriveRight()
        {
            foreach (Motor m in yMotors)
            {
                changingMotor = m;
                if (m.info.xPos > 0)
                {
                    backwards = false;
                }
                else
                {
                    backwards = true;
                }
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void DriveBackwards()
        {
            backwards = true;
            foreach (Motor m in xMotors)
            {
                changingMotor = m;
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void Dive()
        {
            backwards = true;
            foreach (Motor m in zMotors)
            {
                changingMotor = m;
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void Surface()
        {
            backwards = false;
            foreach (Motor m in zMotors)
            {
                changingMotor = m;
                new Thread(new DirectMotorLink().RunMotor).Start();
                System.Threading.Thread.Sleep(100);
            }
        }

        public static void DriveForward()
        {
            foreach (Motor m in xMotors)
            {
                changingMotor = m;
                backwards = false;
                new Thread(new DirectMotorLink().RunMotor).Start();
                
                System.Threading.Thread.Sleep(100);
            }
        }

        public void RunTests()
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

                    changingMotor = m;
                    //TestMotor(m);
                    new Thread(new DirectMotorLink().TestMotor).Start();
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

        static Motor changingMotor;
        static bool backwards = false;

        private void TestMotor()
        {
            TestMotor(changingMotor);
        }

        public DirectMotorLink()
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
                speed = -30;
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

        private void RunMotor()
        {
            RunMotor(changingMotor);
        }

        private void RunMotor2()
        {
            RunMotor(changingSpeed);
        }

        private void RunMotor(sbyte speed)
        {
            if (killed)
            {
                return;
            }
            changingMotor.info.controller.setJrkParameter(jrkParameter.PARAMETER_FEEDBACK_MODE, 0);
            changingMotor.info.controller.reinitialize();
            {
                if (backwards)
                {
                    speed *= -1;
                }
                changingMotor.RequestSpeed(speed);
            }
        }

        private void RunMotor(Motor m)
        {
            if (killed)
            {
                return;
            }
            m.info.controller.setJrkParameter(jrkParameter.PARAMETER_FEEDBACK_MODE, 0);
            m.info.controller.reinitialize();
            sbyte speed;
            {
                speed = -25;
                if (backwards)
                {
                    speed *= -1;
                }
                m.RequestSpeed(speed);
            }
        }

        private static bool LostPower(Motor m)
        {
            
                //return m.info.controller.getVariables().current <= 0;
                return (m.info.controller.getVariables().errorOccurredBits >> 1) % 2 == 1;//this will work if the error flag is the second bit of the errorOrcurredBits
            
            
        }

        public static bool LostPower()
        {
            foreach (Motor m in DirectMotorLink.motors)
            {
                if (LostPower(m))
                {
                    return true;
                }
            }
            return false;
        }

        public void ContinuousCheckForKillSwitch()
        {
            while (!killed)
            {
                if (DirectMotorLink.LostPower())
                {
                    brain.KillEverything();
                }
            }
        }
    }
}


