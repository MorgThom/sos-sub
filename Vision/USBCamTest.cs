using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace RoboSub.Vision
{
   public class USBCamTest
    {
        static ImageViewer viewer;
        static Capture capture;
        static bool real = true;
       static  int frame = 0;
        static int series =0;

       public USBCamTest()
        {
            testCam();
            //viewer = new ImageViewer(); //create an image viewer
            //capture = new Capture();
            //Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
            //{
            //    testShapeDetection();
            //    frame++;
            //    if (frame > 50)
            //    {
            //        frame = 0;
            //        series++;
            //    }
            //});
            //viewer.ShowDialog();
        }

       public static void ThreadStarter(){
           new USBCamTest();}

        public static void Main()
        {
            new USBCamTest();
        }

        public void testCam()
        {

            ImageViewer viewer = new ImageViewer(); //create an image viewer
            Capture capture = new Capture(); //create a camera captue
            Application.Idle += new EventHandler(delegate(object sender, EventArgs e)
            {  //run this until application closed (close button click on image viewer)
                viewer.Image = capture.QueryFrame(); //draw the image obtained from camera
            });
            viewer.ShowDialog(); //show the image viewer
        }

        public void testShapeDetection()
        {
            Image<Bgr, Byte> img = capture.QueryFrame();

            if (frame == 0)
            {
                img.Save("c:/RoboSub/RoboImages/" + series + "c.png");
            }

            //Convert the image to grayscale and filter out the noise
            Image<Gray, Byte> gray = img.Convert<Gray, Byte>().PyrDown().PyrUp();
            //viewer.Image = gray;
            if (frame == 0)
            {
                gray.Save("c:/RoboSub/RoboImages/" + series + "g.png");
            }

            Gray cannyThreshold = new Gray(110);
            Gray cannyThresholdLinking = new Gray(120);
            
            Image<Gray, Byte> cannyEdges = gray.Canny(cannyThreshold, cannyThresholdLinking);
            LineSegment2D[] lines = cannyEdges.HoughLinesBinary(
                1, //Distance resolution in pixel-related units
                Math.PI / 45.0, //Angle resolution measured in radians.
                20, //threshold
                10, //min Line width
                10 //gap between lines
                )[0]; //Get the lines from the first channel


            #region draw lines
            Image<Bgr, Byte> lineImage = img.CopyBlank();
            foreach (LineSegment2D line in lines)
                lineImage.Draw(line, new Bgr(Color.Green), 2);

            //if (!real)
                viewer.Image = lineImage;
            if (frame == 0)
            {
                lineImage.Save("c:/RoboSub/RoboImages/" + series + "l.png");
            }
            #endregion

            real = !real;

        }
    }
}