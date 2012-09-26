using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using RoboSub.Internal_Model;
using RoboSub.Movement;
using RoboSub.Vision;
using System.Drawing;
using Emgu.CV;
using System.Windows.Forms;

namespace RoboSub.AI
{
    class Brain
    {
        static List<Thread> processes = new List<Thread>();
        int targetAngle = 90;//this will need to be hand coded to starting angle towards the gate //actually it's not used... right now it assumes it can see the gate well enough to blob detect it
        int currentAngle, currentDirection;
        static int FORWARD = 0, RIGHT = 1, LEFT = 2, UP = 3, DOWN = 4, BACKWARD = 5, STOPPED = 6;
        double upMotionValue = 5;//this should be set to an appropriate value based on the IMU's output... or the surfacing should just be cancelled and let it float up when it's done

        public static void Main()
        {
            new Brain();
            //Eyes.GetCenterMass("C:/RoboSub/line.png");
           // Eyes.AUTO_ADJUST_THRESHOLD = false;
            //Eyes.GetCenterMass(true);
            //System.Console.ReadLine();
        }

        Brain()
        {
            InitializeComponents();


            // test vision coding.
            //Thread.Sleep(15000);
            //FollowLine();

          // // Thread.Sleep(45000);//wait five seconds before doing anything

          //  DirectMotorLink.Surface();
          //  DirectMotorLink.KillAllMotors();
          // // DirectMotorLink.Dive();
          ////  Thread.Sleep(7000);
          // // DirectMotorLink.KillAllMotors();

          //  for (int i = 0; i < 3; i++)
          //  {
          //      DirectMotorLink.DriveBackwards();
          //      DirectMotorLink.KillAllMotors();
          //      DirectMotorLink.DriveForward();
          //      Thread.Sleep(10000);
          //      DirectMotorLink.KillAllMotors();

          //     // DirectMotorLink.Dive();
          //      DirectMotorLink.KillAllMotors();
          //     // DirectMotorLink.Surface();
          //      Thread.Sleep(2200);
          //      DirectMotorLink.KillAllMotors();

          //      DirectMotorLink.YawRight();
          //      DirectMotorLink.KillAllMotors();
          //      DirectMotorLink.YawLeft();
          //      Thread.Sleep(1900);
          //      DirectMotorLink.KillAllMotors();
          //      Console.WriteLine("Cycle Finished " + (i+1));
          //  }
          //  Console.WriteLine("Run Finished.");
            
          //  //DirectMotorLink.KillAllMotors();
          //  //GoThroughArch();
          //  //FollowLine();
          //  //Bump();
          //  //FollowLine();
          //  //Surface();//since the IMU isn't working, can't tell when the surface is hit so just rely on bouancy
          //  //KillEverything();
        }

        /// <summary>
        /// Currently just runs straight forward attempting to go between the poles seen
        /// </summary>
        void GoThroughArch()
        {
            Point blobCenter = new Point(0, 0);
            currentDirection = STOPPED;
            DirectMotorLink.KillAllMotors();
            while (blobCenter.X > Int16.MinValue)//min value is returned when nothing can be seen
            {
                blobCenter = Eyes.GetCenterMass(true);
                if (blobCenter.X < -10)
                {
                    if (currentDirection != LEFT)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.YawLeft();
                        DirectMotorLink.DriveLeft();
                        currentDirection = LEFT;
                    }
                }
                else if (blobCenter.X > 10)
                {
                    if (currentDirection != RIGHT)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.YawRight();
                        DirectMotorLink.DriveRight();
                        currentDirection = RIGHT;
                    }
                }
                else if (blobCenter.Y > -100)
                {
                    if (currentDirection != DOWN)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.Dive();
                        currentDirection = DOWN;
                    }
                }
                else
                {
                    if (currentDirection != FORWARD)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.DriveForward();
                        currentDirection = FORWARD;
                    }
                }
                Thread.Sleep(50);//only do something new every half second
            }
            DirectMotorLink.KillAllMotors();
        }

        void FollowLine()
        {
            Point blobCenter = new Point(0, 0);
            currentDirection = STOPPED;
            //DirectMotorLink.KillAllMotors();
            //DirectMotorLink.DriveForward();



           // DirectMotorLink.Surface();
            //DirectMotorLink.KillAllMotors();
            Console.WriteLine("Diving: 2.25 seconds.\n");
            DirectMotorLink.Dive();
            Thread.Sleep(9000);
            Console.WriteLine("Killing motors.\n");
            DirectMotorLink.KillAllMotors();

            for (int i = 0; i < 10; i++)
            {
                DirectMotorLink.DriveBackwards();
                DirectMotorLink.KillAllMotors();
                Console.WriteLine("Forward: 10 seconds.\n");
                DirectMotorLink.DriveForward();
                Thread.Sleep(10000);
                Console.WriteLine("Killing motors.\n");
                DirectMotorLink.KillAllMotors();

                //if (i == 3)
                //{
                //    Console.WriteLine("Surfacing: 1.75 seconds.\n");
                //    DirectMotorLink.Surface();
                //    Thread.Sleep(500);
                //}


                // DirectMotorLink.Dive();
                //DirectMotorLink.KillAllMotors();
                // DirectMotorLink.Surface();
                //Thread.Sleep(2200);
                //DirectMotorLink.KillAllMotors();

                //Console.WriteLine("Rotating Right");
                //DirectMotorLink.YawRight();
                //Console.WriteLine("Killing");
                //DirectMotorLink.KillAllMotors();
                    //Console.WriteLine("Diving: 1 second.\n");
                    //DirectMotorLink.Dive();
                    //Thread.Sleep(2000);
                DirectMotorLink.Surface();
                Thread.Sleep(500);
                    Console.WriteLine("Turning left: 2.4 seconds.\n");
                    DirectMotorLink.YawRight();
                    DirectMotorLink.KillAllMotors();
                DirectMotorLink.YawLeft();
                Thread.Sleep(3500);
                Console.WriteLine("Killing motors.\n");
                DirectMotorLink.KillAllMotors();
                Console.WriteLine("Finished cycle" + (i + 1) + ". Starting cycle " + (i + 2) + ".\n");
            }
            Console.WriteLine("\nRun Finished, switching to downward vision.\n");

            //DirectMotorLink.KillAllMotors();
            //KillEverything();




            do//move until a blob is seen
            {
                blobCenter = Eyes.GetCenterMass(false);
            } while (blobCenter.X == Int32.MinValue);
            DirectMotorLink.KillAllMotors();
                Console.WriteLine("Killing motors.\n");

            while (blobCenter.X > Int16.MinValue)//min value is returned when nothing can be seen
            {
                blobCenter = Eyes.GetCenterMass(false);
                if (blobCenter.X < -10)
                {
                    if (currentDirection != LEFT)
                    {
                        Console.WriteLine("Killing motors.\n");
                        DirectMotorLink.KillAllMotors();
                        //DirectMotorLink.YawLeft();
                        Console.WriteLine("Turning left for .95 seconds.\n");
                        DirectMotorLink.DriveLeft();
                        Thread.Sleep(950);
                        Console.WriteLine("Driving forward for 5 seconds.\n");
                        DirectMotorLink.DriveForward();
                        Thread.Sleep(5000);
                        currentDirection = LEFT;
                    }
                }
                else if (blobCenter.X > 10)
                {
                    if (currentDirection != RIGHT)
                    {
                        Console.WriteLine("Killing motors.\n");
                        DirectMotorLink.KillAllMotors();
                        //DirectMotorLink.YawRight();
                        Console.WriteLine("Driving right for .95 seconds.\n");
                        DirectMotorLink.DriveRight();
                        Thread.Sleep(950);
                        Console.WriteLine("Driving for 5 seconds.\n");
                        DirectMotorLink.DriveForward();
                        Thread.Sleep(5000);
                        currentDirection = RIGHT;
                    }
                }
                else
                {
                    if (currentDirection != FORWARD)
                    {
                        Console.WriteLine("Killing motors.\n");
                        DirectMotorLink.KillAllMotors();
                        Console.WriteLine("Driving forward for 5 seconds.\n");
                        DirectMotorLink.DriveForward();
                        Thread.Sleep(5000);
                        currentDirection = FORWARD;
                    }
                }
                Thread.Sleep(50);//only do something new every half second
            }
            Console.WriteLine("Killing motors.\n");
            DirectMotorLink.KillAllMotors();
        }

        void Bump()
        {
            Point blobCenter = new Point(0, 0);
            currentDirection = STOPPED;
            DirectMotorLink.KillAllMotors();
            while (blobCenter.X > Int16.MinValue)//min value is returned when nothing can be seen
            {
                blobCenter = Eyes.GetCenterMass(true);
                if (blobCenter.X < -10)
                {
                    if (currentDirection != LEFT)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.YawLeft();
                        DirectMotorLink.DriveLeft();
                        currentDirection = LEFT;
                    }
                }
                else if (blobCenter.X > 10)
                {
                    if (currentDirection != RIGHT)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.YawRight();
                        DirectMotorLink.DriveRight();
                        currentDirection = RIGHT;
                    }
                }
                else if (blobCenter.Y < -10)
                {
                    if (currentDirection != UP)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.Surface();
                        currentDirection = UP;
                    }
                }
                else if (blobCenter.Y > 10)
                {
                    if (currentDirection != DOWN)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.Dive();
                        currentDirection = DOWN;
                    }
                }
                else
                {
                    if (currentDirection != FORWARD)
                    {
                        DirectMotorLink.KillAllMotors();
                        DirectMotorLink.DriveForward();
                        currentDirection = FORWARD;
                    }
                }
                Thread.Sleep(50);//only do something new every half second
            }
            DirectMotorLink.KillAllMotors();
        }

        void Surface()
        //turned this off, but really it could just be set to run for thirty seconds or something and then cut out...
        {
            DirectMotorLink.KillAllMotors();
            DirectMotorLink.Surface();
           // while (IMU.zAccel > upMotionValue) { }
            DirectMotorLink.KillAllMotors();
        }

        void InitializeComponents()
        {
            //processes.Add(new Thread(new IMU().ContinuousValueUpdate));
            //processes.Add(new Thread(new ConditionsLogger().GatherDataAndOutputToFile));
            processes.Add(new Thread(new DirectMotorLink(this).ContinuousCheckForKillSwitch));
            DirectMotorLink.InitializeMotors();

            foreach (Thread t in processes)
            {
                t.Start();
            }
        }

        public void KillEverything()
        {
            DirectMotorLink.KillAllMotors();
            DirectMotorLink.killed = true;
            foreach (Thread t in processes)
            {
                t.Abort();
            }
        }
    }
}
