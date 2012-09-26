using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Emgu.CV.UI;
using Emgu.CV;
using System.Windows.Forms;
using Emgu.CV.Structure;
using System.Drawing;
using System.Threading;

namespace RoboSub.Vision
{
    class LineDetectionFromFileTesting
    {
        static ImageViewer viewer;
        static int threshold = 35;
        static int thresholdLinking = 50;
        static int redThreshold = 65;
        static Image<Bgr, Byte> fileImage;
        static Image<Gray, Byte> gray;
        static Gray cannyThreshold;
        static Gray cannyThresholdLinking;
        static Image<Bgr, Byte> img;
        static String fileName = "C:/RoboSub/line.png";

        public static void Main()
        {
            new LineDetectionFromFileTesting();
        }

        public LineDetectionFromFileTesting()
        {
            viewer = new ImageViewer(); //create an image viewer

            //Convert the image to grayscale and filter out the noise
            // gray = new Image<Gray, Byte>("C:/RoboSub/RoboImagesTest2/92c.png");
            fileImage = new Image<Bgr, Byte>(fileName);
            fileImage = fileImage.Resize(300, 200, Emgu.CV.CvEnum.INTER.CV_INTER_AREA, true);
            img = fileImage.Clone();
            gray = img.Convert<Gray, Byte>();
            // img = new Image<Bgr, Byte>("C:/RoboSub/RoboImagesTest2/92c.png");

            viewer.Size = new Size(fileImage.Width * 3, fileImage.Height * 3);

            Thread input = new Thread(getKeyboardInput);
            input.Start();
            Thread test = new Thread(testShapeDetection);
            test.Start();
            Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
            {
                //testShapeDetection();
            });
            viewer.ShowDialog();
            test.Abort();
            input.Abort();
        }

        void getKeyboardInput()
        {
            char inKey;
            int series = 92;

            img = fileImage.Clone();
            gray = img.Convert<Gray, Byte>();
            gray = gray.PyrDown().PyrUp();
            Image<Gray, Byte> splitImage = img.Split()[2];

            //find optimal redThreshold
            bool found1 = false;
            while (!found1)
            {
                splitImage = img.Split()[2].ThresholdToZero(new Gray(redThreshold));
                if (splitImage.GetSum().Intensity > 255 * 800)
                {
                    redThreshold += 1;
                }
                else if (splitImage.GetSum().Intensity < 255 * 500)
                {
                    redThreshold -= 1;
                }
                else
                {
                    found1 = true;
                }
                System.Console.WriteLine("Setting red to " + redThreshold);
            }
            splitImage = splitImage.ThresholdBinary(new Gray(150), new Gray(255));
            gray = splitImage;

            //gray = gray.ThresholdBinary(new Gray(grayThreshold), new Gray(grayMax));
            System.Console.WriteLine("Threshold: " + threshold + "  Threshold Linking: " + thresholdLinking + "  Gray Threshold: " + redThreshold + "  Image: " + fileName);
            do
            {
                if (!Console.KeyAvailable)
                    continue;
                inKey = Console.ReadKey().KeyChar;
                switch (inKey)
                {
                    case '8':
                        threshold += 5;
                        break;
                    case '2':
                        threshold -= 5;
                        break;
                    case '4':
                        thresholdLinking -= 5;
                        break;
                    case '6':
                        thresholdLinking += 5;
                        break;
                    case '1':
                        redThreshold -= 5;
                        break;
                    case '3':
                        redThreshold += 5;
                        break;
                    case '9':
                        series++;
                        break;
                    case '7':
                        series--;
                        break;
                }
                //gray = new Image<Gray, Byte>("C:/RoboSub/RoboImagesTest2/" + series + "c.png");
                // gray = gray.PyrDown().PyrUp();

                //img = new Image<Bgr, Byte>("C:/RoboSub/RoboImagesTest2/" + series + "c.png");


                img = fileImage.Clone();
                gray = img.Convert<Gray, Byte>();
                gray = gray.PyrDown().PyrUp();
                splitImage = img.Split()[2];

                //find optimal redThreshold
               bool found = false;
                while (!found)
                {
                    splitImage = img.Split()[2];

                    splitImage = splitImage.ThresholdToZero(new Gray(redThreshold));
                    if (splitImage.GetSum().Intensity > 255 * 100)
                    {
                        redThreshold += 1;
                    }
                    else if (splitImage.GetSum().Intensity < 255 * 10)
                    {
                        redThreshold -= 1;
                    }
                    else
                    {
                        found = true;
                    }
                    System.Console.WriteLine("Setting red to " + redThreshold);
                }
                gray = splitImage;

                //gray = gray.ThresholdBinary(new Gray(grayThreshold), new Gray(grayMax));
                System.Console.WriteLine("Threshold: " + threshold + "  Threshold Linking: " + thresholdLinking + "  Gray Threshold: " + redThreshold + "  Image: " + fileName);
            }
            while (true);
        }

        public void testShapeDetection()
        {
            while (true)
            {
                cannyThreshold = new Gray(threshold);
                cannyThresholdLinking = new Gray(thresholdLinking);
                Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
                LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                    1, //Distance resolution in pixel-related units
                    Math.PI / 45.0, //Angle resolution measured in radians.
                    20, //threshold - default 20
                    10, //min Line width - default 10
                    10 //gap between lines - default 10
                    )[0]; //Get the lines from the first channel


                Image<Bgr, Byte> lineImage = img.CopyBlank();
                foreach (LineSegment2D line in lines)
                    lineImage.Draw(line, new Bgr(Color.BlanchedAlmond), 2);

                viewer.Image = lineImage.ConcateHorizontal(img).ConcateVertical(cannyEdges.ConcateHorizontal(gray).Convert<Bgr, Byte>());

            }
        }
    }
}
