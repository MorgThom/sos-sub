using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Windows.Forms;
using System.Threading;

namespace RoboSub.Vision
{
    class Eyes
    {
        //need to put in the actual indexes for these cameras
        //these index values might change every time they are connected
        static int forwardLeftCamera = 1;
        static int forwardRightCamera = 3;
        static int downLeftCamera = 2;
        static int downRightCamera = 0;

        static long series = 0;

        //camera view variables
        public static bool AUTO_ADJUST_THRESHOLD = true;

        static int greenMin = 0;
        static int greenMax = 60;
        static int blueMin = 0;
        static int blueMax = 80;
        static int redMin = 50;
        static int redMax = 255;

        static int minRedPercent = 1;
        static int maxRedPercent = 50;

        static Image<Gray, Byte>[] splitImage;
        static Image<Gray, Byte> gray, red, blue, green;

        public static Point GetCenterMass(string fileName)
        {
            Capture cap;
            cap = GetCamera(forwardLeftCamera);
            cap.QueryFrame().Clone().Save("C:/RoboSub/RoboImages/forwardLeft" + series + ".png");
            cap.Dispose();

            cap = GetCamera(forwardRightCamera);
            cap.QueryFrame().Clone().Save("C:/RoboSub/RoboImages/forwardRight" + series + ".png");
            cap.Dispose();

            cap = GetCamera(downLeftCamera);
            cap.QueryFrame().Clone().Save("C:/RoboSub/RoboImages/downLeft" + series + ".png");
            cap.Dispose();

            cap = GetCamera(downRightCamera);
            cap.QueryFrame().Clone().Save("C:/RoboSub/RoboImages/downRight" + series + ".png");
            cap.Dispose();

            series++;
            return GetCenterMass(new Image<Bgr, Byte>(fileName));
        }

        /// <summary>
        /// Finds the center of mass in x, y coordinates. If nothing is seen, returns null.
        /// </summary>
        /// <returns></returns>
        public static Point GetCenterMass(bool forward)
        {
            Capture capture;

            if (forward)
            {
                capture = GetCamera(forwardRightCamera);
                //capture = new Capture(forwardRightCamera);
            }
            else //looking down
            {
                capture = GetCamera(downRightCamera);
                //capture = new Capture(downRightCamera);
            }
            Image<Bgr, Byte> img = capture.QueryFrame().Clone();
            capture.Dispose();

            return GetCenterMass(img);
        }

        private static Point GetCenterMass(Image<Bgr, Byte> img)
        {
            //ImageViewer viewer = new ImageViewer();
            //crunch down thresholds to find red-based blobs
            //viewer.Image = img;
            //viewer.ShowDialog();
            splitImage = img.Split();
            blue = splitImage[0].Copy();
            green = splitImage[1].Copy();
            red = splitImage[2].Copy();

            //make the lowest levels bright
            //blue._ThresholdBinary(new Gray(blueMin), new Gray(255));
            // green._ThresholdBinary(new Gray(greenMin), new Gray(255));

            //make the highest levels bright
            red = red.Sub(blue.ThresholdBinary(new Gray(blueMax), new Gray(255)));
            red = red.Sub(green.ThresholdBinary(new Gray(greenMax), new Gray(255)));
            red._ThresholdBinary(new Gray(redMin), new Gray(255));

            //build up mask
            // gray = red.And(blue).And(green);
            gray = red.Copy();

            //do auto threshold if active
            if (AUTO_ADJUST_THRESHOLD)
            {

                //find optimal redThreshold
                bool found = false;
                int currentRed = redMax;//start in middle to hopefully minimize search time
                while (!found)
                {
                    if (gray.GetSum().Intensity / (img.Width * img.Height) > maxRedPercent)
                    {
                        currentRed += 1;
                    }
                    else if (gray.GetSum().Intensity / (img.Width * img.Height) < minRedPercent)
                    {
                        currentRed -= 1;
                    }
                    else
                    {
                        found = true;
                        break;
                    }

                    if (currentRed > redMax || currentRed < redMin)//out of bounds, so no red found!
                    {
                        found = true;
                        System.Console.WriteLine("Current Red Percent out of bound: " + currentRed);
                        return new Point(Int32.MinValue, Int32.MinValue);
                    }

                    System.Console.WriteLine("Setting red to " + redMin);
                    red = splitImage[2].Copy();
                    red = red.Sub(blue.ThresholdBinary(new Gray(blueMax), new Gray(255)));
                    red = red.Sub(green.ThresholdBinary(new Gray(greenMax), new Gray(255)));
                    red._ThresholdBinary(new Gray(redMin), new Gray(255));

                    //build up mask
                    // gray = red.And(blue).And(green);
                    gray = red.Copy();

                   // viewer.Image = gray;
                }
            }

            MCvMoments moments = gray.GetMoments(true);
            MCvPoint2D64f momentGravity = moments.GravityCenter;

            Point center = new Point((int)momentGravity.x - img.Width / 2, (int)momentGravity.y - img.Height / 2);

            System.Console.WriteLine("Center at " + center.ToString());
            System.Console.WriteLine("Intesity: " + gray.GetSum().Intensity + ", " + (gray.GetSum().Intensity / (img.Height * img.Width)));

           // viewer.Image = gray;

            //viewer.ShowDialog();
            return center;
        }

        private static Capture GetCamera(int index)
        {
            Capture capture = null;
            while (capture == null)
            {
                try
                {
                    capture = new Capture(index);
                }
                catch (Exception e)
                {
                    capture = null;
                }
            }

            //give camera a chance to autofocus
            capture.QueryFrame();
            Thread.Sleep(500);
            return capture;
        }
    }
}
