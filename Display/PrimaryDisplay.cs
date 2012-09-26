using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RoboSub.RemoteControl;

namespace RoboSub
{
    public partial class PrimaryDisplay : Form, IInputListener
    {
        public PrimaryDisplay()
        {
            InitializeComponent();
        }

        private void PrimaryDisplay_Load(object sender, EventArgs e)
        {

        }

        public void batt1PercentLabel_Set(double percent)
        {
            batt1PercentLabel.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void batt2PercentLabel_Set(double percent)
        {
            batt2PercentLabel.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void batteryTimeRemainingBox_Set(double percent)
        {
            batteryTimeRemainingBox.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void xInputPercentLabel_Set(double percent)
        {
            xInputPercentLabel.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void yInputPercentLabel_Set(double percent)
        {
            yInputPercentLabel.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void zInputPercentLabel_Set(double percent)
        {
            zInputPercentLabel.Text = String.Format("{0:0.###}", percent) + "%";
        }
        public void pitchRadiansBox_Set(double radians)
        {
            pitchRadiansBox.Text = String.Format("{0:0.###}", radians) + " radians";
        }
        public void rollRadiansBox_Set(double radians)
        {
            rollRadiansBox.Text = String.Format("{0:0.###}", radians) + " radians";
        }
        public void yawRadiansBox_Set(double radians)
        {
            yawRadiansBox.Text = String.Format("{0:0.###}", radians) + " radians";
        }
        public void killSwitchBox_Set(string status)
        {
            killSwitchBox.Text = status;
        }
        public void grasperBox_Set(string status)
        {
            grasperBox.Text = status;
        }
        public void releaseBox_Set(string status)
        {
            releaseBox.Text = status;
        }
        public void marker1Box_Set(string status)
        {
            marker1Box.Text = status;
        }
        public void marker2Box_Set(string status)
        {
            marker2Box.Text = status;
        }
        public void torpedo1Box_Set(string status)
        {
            torpedo1Box.Text = status;
        }
        public void torpedo2Box_Set(string status)
        {
            torpedo2Box.Text = status;
        }
        public void depthBox_Set(double value)
        {
            depthBox.Text = String.Format("{0:0.###}", value);
        }
        public void altitudeBox_Set(double value)
        {
            altitudeBox.Text = String.Format("{0:0.###}", value);
        }
        public void temperatureBox_Set(double value)
        {
            temperatureBox.Text = String.Format("{0:0.###}", value);
        }
        public void motor1Box_Set(double value)
        {
            motor1Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor2Box_Set(double value)
        {
            motor2Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor3Box_Set(double value)
        {
            motor3Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor4Box_Set(double value)
        {
            motor4Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor5Box_Set(double value)
        {
            motor5Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor6Box_Set(double value)
        {
            motor6Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor7Box_Set(double value)
        {
            motor7Box.Text = String.Format("{0:0.###}", value);
        }
        public void motor8Box_Set(double value)
        {
            motor8Box.Text = String.Format("{0:0.###}", value);
        }
        public void edgesDetectedPanel_Set(Image image)
        {
            edgesDetectedPanel.BackgroundImage = image;
        }
        public void camera1Panel_Set(Image image)
        {
            camera1Panel.BackgroundImage = image;
        }
        public void camera2Panel_Set(Image image)
        {
            camera2Panel.BackgroundImage = image;
        }
        public void camera3Panel_Set(Image image)
        {
            camera3Panel.BackgroundImage = image;
        }
        public void camera4dPanel_Set(Image image)
        {
            camera4Panel.BackgroundImage = image;
        }
        public void histogramPanel_Set(Image image)
        {
            histogramPanel.BackgroundImage = image;
        }

        #region IInputListener Members

        public void InputNotify(sbyte[] input) {
            xInputPercentLabel_Set( input[(int) InputMessageValues.xMagnitude]);
            yInputPercentLabel_Set(input[(int) InputMessageValues.yMagnitude]);
            zInputPercentLabel_Set( input[(int) InputMessageValues.zMagnitude]);
            System.Console.Write("roll: " + input[(int) InputMessageValues.roll] + " ");
            System.Console.Write("pitch: " + input[(int) InputMessageValues.pitch] + " ");
            System.Console.Write("yaw: " + input[(int) InputMessageValues.yaw] + " ");
            System.Console.Write("torp: " + input[(int) InputMessageValues.torpedo] + " ");
            System.Console.Write("mark: " + input[(int) InputMessageValues.marker] + " ");
            System.Console.Write("grasp: " + input[(int) InputMessageValues.grasp] + " ");
            System.Console.Write("release: " + input[(int) InputMessageValues.release] + " ");
            System.Console.Write("kill: " + input[(int) InputMessageValues.kill]);

            this.Refresh();
        }

        #endregion
    }
}
