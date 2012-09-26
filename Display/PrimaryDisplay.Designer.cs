namespace RoboSub
{
    partial class PrimaryDisplay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edgesDetectedPanel = new System.Windows.Forms.Panel();
            this.detectEdgesBtn = new System.Windows.Forms.Button();
            this.battery1Label = new System.Windows.Forms.Label();
            this.battery2Label = new System.Windows.Forms.Label();
            this.timeRemainingLabel = new System.Windows.Forms.Label();
            this.batt1PercentLabel = new System.Windows.Forms.Label();
            this.batt2PercentLabel = new System.Windows.Forms.Label();
            this.batteryTimeRemainingBox = new System.Windows.Forms.TextBox();
            this.controlInputLabel = new System.Windows.Forms.Label();
            this.xInputLabel = new System.Windows.Forms.Label();
            this.yInputLabel = new System.Windows.Forms.Label();
            this.zInputLabel = new System.Windows.Forms.Label();
            this.xInputPercentLabel = new System.Windows.Forms.Label();
            this.yInputPercentLabel = new System.Windows.Forms.Label();
            this.zInputPercentLabel = new System.Windows.Forms.Label();
            this.pitchLabel = new System.Windows.Forms.Label();
            this.rollLabel = new System.Windows.Forms.Label();
            this.yawLabel = new System.Windows.Forms.Label();
            this.pitchRadiansBox = new System.Windows.Forms.TextBox();
            this.rollRadiansBox = new System.Windows.Forms.TextBox();
            this.yawRadiansBox = new System.Windows.Forms.TextBox();
            this.grasperLabel = new System.Windows.Forms.Label();
            this.marker1Label = new System.Windows.Forms.Label();
            this.marker2Label = new System.Windows.Forms.Label();
            this.torpedo2Label = new System.Windows.Forms.Label();
            this.torpedo1Label = new System.Windows.Forms.Label();
            this.releaseLabel = new System.Windows.Forms.Label();
            this.grasperBox = new System.Windows.Forms.TextBox();
            this.marker1Box = new System.Windows.Forms.TextBox();
            this.marker2Box = new System.Windows.Forms.TextBox();
            this.releaseBox = new System.Windows.Forms.TextBox();
            this.torpedo1Box = new System.Windows.Forms.TextBox();
            this.torpedo2Box = new System.Windows.Forms.TextBox();
            this.killSwitchBox = new System.Windows.Forms.TextBox();
            this.killSwitchLabel = new System.Windows.Forms.Label();
            this.depthLabel = new System.Windows.Forms.Label();
            this.altitudeLabel = new System.Windows.Forms.Label();
            this.temperatureLabel = new System.Windows.Forms.Label();
            this.depthBox = new System.Windows.Forms.TextBox();
            this.altitudeBox = new System.Windows.Forms.TextBox();
            this.temperatureBox = new System.Windows.Forms.TextBox();
            this.motor1Label = new System.Windows.Forms.Label();
            this.motor2Label = new System.Windows.Forms.Label();
            this.motor3Label = new System.Windows.Forms.Label();
            this.motor4Label = new System.Windows.Forms.Label();
            this.motor5Label = new System.Windows.Forms.Label();
            this.motor6Label = new System.Windows.Forms.Label();
            this.motor7Label = new System.Windows.Forms.Label();
            this.motor8Label = new System.Windows.Forms.Label();
            this.motor1Box = new System.Windows.Forms.TextBox();
            this.motor2Box = new System.Windows.Forms.TextBox();
            this.motor3Box = new System.Windows.Forms.TextBox();
            this.motor4Box = new System.Windows.Forms.TextBox();
            this.motor5Box = new System.Windows.Forms.TextBox();
            this.motor6Box = new System.Windows.Forms.TextBox();
            this.motor7Box = new System.Windows.Forms.TextBox();
            this.motor8Box = new System.Windows.Forms.TextBox();
            this.camera3Panel = new System.Windows.Forms.Panel();
            this.histogramPanel = new System.Windows.Forms.Panel();
            this.camera2Panel = new System.Windows.Forms.Panel();
            this.camera4Panel = new System.Windows.Forms.Panel();
            this.camera1Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // edgesDetectedPanel
            // 
            this.edgesDetectedPanel.Location = new System.Drawing.Point(13, 13);
            this.edgesDetectedPanel.Name = "edgesDetectedPanel";
            this.edgesDetectedPanel.Size = new System.Drawing.Size(258, 227);
            this.edgesDetectedPanel.TabIndex = 0;
            //TODO -- What is this line for? ---> this.edgesDetectedPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.edgesDetectedPanel);
            // 
            // detectEdgesBtn
            // 
            this.detectEdgesBtn.Location = new System.Drawing.Point(87, 246);
            this.detectEdgesBtn.Name = "detectEdgesBtn";
            this.detectEdgesBtn.Size = new System.Drawing.Size(111, 23);
            this.detectEdgesBtn.TabIndex = 2;
            this.detectEdgesBtn.Text = "Detect Edges";
            this.detectEdgesBtn.UseVisualStyleBackColor = true;
            // 
            // battery1Label
            // 
            this.battery1Label.AutoSize = true;
            this.battery1Label.Location = new System.Drawing.Point(381, 36);
            this.battery1Label.Name = "battery1Label";
            this.battery1Label.Size = new System.Drawing.Size(52, 13);
            this.battery1Label.TabIndex = 6;
            this.battery1Label.Text = "Battery 1:";
            // 
            // battery2Label
            // 
            this.battery2Label.AutoSize = true;
            this.battery2Label.Location = new System.Drawing.Point(381, 62);
            this.battery2Label.Name = "battery2Label";
            this.battery2Label.Size = new System.Drawing.Size(52, 13);
            this.battery2Label.TabIndex = 7;
            this.battery2Label.Text = "Battery 2:";
            // 
            // timeRemainingLabel
            // 
            this.timeRemainingLabel.AutoSize = true;
            this.timeRemainingLabel.Location = new System.Drawing.Point(381, 88);
            this.timeRemainingLabel.Name = "timeRemainingLabel";
            this.timeRemainingLabel.Size = new System.Drawing.Size(107, 13);
            this.timeRemainingLabel.TabIndex = 9;
            this.timeRemainingLabel.Text = "Est. Time Remaining:";
            // 
            // batt1PercentLabel
            // 
            this.batt1PercentLabel.AutoSize = true;
            this.batt1PercentLabel.Location = new System.Drawing.Point(439, 36);
            this.batt1PercentLabel.Name = "batt1PercentLabel";
            this.batt1PercentLabel.Size = new System.Drawing.Size(15, 13);
            this.batt1PercentLabel.TabIndex = 10;
            this.batt1PercentLabel.Text = "%";
            // 
            // batt2PercentLabel
            // 
            this.batt2PercentLabel.AutoSize = true;
            this.batt2PercentLabel.Location = new System.Drawing.Point(439, 62);
            this.batt2PercentLabel.Name = "batt2PercentLabel";
            this.batt2PercentLabel.Size = new System.Drawing.Size(15, 13);
            this.batt2PercentLabel.TabIndex = 11;
            this.batt2PercentLabel.Text = "%";
            // 
            // batteryTimeRemainingBox
            // 
            this.batteryTimeRemainingBox.Location = new System.Drawing.Point(381, 106);
            this.batteryTimeRemainingBox.Name = "batteryTimeRemainingBox";
            this.batteryTimeRemainingBox.Size = new System.Drawing.Size(100, 20);
            this.batteryTimeRemainingBox.TabIndex = 12;
            // 
            // controlInputLabel
            // 
            this.controlInputLabel.AutoSize = true;
            this.controlInputLabel.Location = new System.Drawing.Point(542, 36);
            this.controlInputLabel.Name = "controlInputLabel";
            this.controlInputLabel.Size = new System.Drawing.Size(70, 13);
            this.controlInputLabel.TabIndex = 13;
            this.controlInputLabel.Text = "Control Input:";
            // 
            // xInputLabel
            // 
            this.xInputLabel.AutoSize = true;
            this.xInputLabel.Location = new System.Drawing.Point(542, 59);
            this.xInputLabel.Name = "xInputLabel";
            this.xInputLabel.Size = new System.Drawing.Size(38, 13);
            this.xInputLabel.TabIndex = 14;
            this.xInputLabel.Text = "X-axis:";
            // 
            // yInputLabel
            // 
            this.yInputLabel.AutoSize = true;
            this.yInputLabel.Location = new System.Drawing.Point(542, 86);
            this.yInputLabel.Name = "yInputLabel";
            this.yInputLabel.Size = new System.Drawing.Size(38, 13);
            this.yInputLabel.TabIndex = 15;
            this.yInputLabel.Text = "Y-axis:";
            // 
            // zInputLabel
            // 
            this.zInputLabel.AutoSize = true;
            this.zInputLabel.Location = new System.Drawing.Point(542, 113);
            this.zInputLabel.Name = "zInputLabel";
            this.zInputLabel.Size = new System.Drawing.Size(38, 13);
            this.zInputLabel.TabIndex = 16;
            this.zInputLabel.Text = "Z-axis:";
            // 
            // xInputPercentLabel
            // 
            this.xInputPercentLabel.AutoSize = true;
            this.xInputPercentLabel.Location = new System.Drawing.Point(586, 59);
            this.xInputPercentLabel.Name = "xInputPercentLabel";
            this.xInputPercentLabel.Size = new System.Drawing.Size(15, 13);
            this.xInputPercentLabel.TabIndex = 17;
            this.xInputPercentLabel.Text = "%";
            // 
            // yInputPercentLabel
            // 
            this.yInputPercentLabel.AutoSize = true;
            this.yInputPercentLabel.Location = new System.Drawing.Point(586, 86);
            this.yInputPercentLabel.Name = "yInputPercentLabel";
            this.yInputPercentLabel.Size = new System.Drawing.Size(15, 13);
            this.yInputPercentLabel.TabIndex = 18;
            this.yInputPercentLabel.Text = "%";
            // 
            // zInputPercentLabel
            // 
            this.zInputPercentLabel.AutoSize = true;
            this.zInputPercentLabel.Location = new System.Drawing.Point(586, 113);
            this.zInputPercentLabel.Name = "zInputPercentLabel";
            this.zInputPercentLabel.Size = new System.Drawing.Size(15, 13);
            this.zInputPercentLabel.TabIndex = 19;
            this.zInputPercentLabel.Text = "%";
            // 
            // pitchLabel
            // 
            this.pitchLabel.AutoSize = true;
            this.pitchLabel.Location = new System.Drawing.Point(660, 36);
            this.pitchLabel.Name = "pitchLabel";
            this.pitchLabel.Size = new System.Drawing.Size(31, 13);
            this.pitchLabel.TabIndex = 20;
            this.pitchLabel.Text = "Pitch";
            // 
            // rollLabel
            // 
            this.rollLabel.AutoSize = true;
            this.rollLabel.Location = new System.Drawing.Point(660, 61);
            this.rollLabel.Name = "rollLabel";
            this.rollLabel.Size = new System.Drawing.Size(25, 13);
            this.rollLabel.TabIndex = 21;
            this.rollLabel.Text = "Roll";
            // 
            // yawLabel
            // 
            this.yawLabel.AutoSize = true;
            this.yawLabel.Location = new System.Drawing.Point(660, 86);
            this.yawLabel.Name = "yawLabel";
            this.yawLabel.Size = new System.Drawing.Size(28, 13);
            this.yawLabel.TabIndex = 22;
            this.yawLabel.Text = "Yaw";
            // 
            // pitchRadiansBox
            // 
            this.pitchRadiansBox.Location = new System.Drawing.Point(697, 36);
            this.pitchRadiansBox.Name = "pitchRadiansBox";
            this.pitchRadiansBox.Size = new System.Drawing.Size(100, 20);
            this.pitchRadiansBox.TabIndex = 23;
            // 
            // rollRadiansBox
            // 
            this.rollRadiansBox.Location = new System.Drawing.Point(697, 61);
            this.rollRadiansBox.Name = "rollRadiansBox";
            this.rollRadiansBox.Size = new System.Drawing.Size(100, 20);
            this.rollRadiansBox.TabIndex = 24;
            // 
            // yawRadiansBox
            // 
            this.yawRadiansBox.Location = new System.Drawing.Point(697, 86);
            this.yawRadiansBox.Name = "yawRadiansBox";
            this.yawRadiansBox.Size = new System.Drawing.Size(100, 20);
            this.yawRadiansBox.TabIndex = 25;
            // 
            // grasperLabel
            // 
            this.grasperLabel.AutoSize = true;
            this.grasperLabel.Location = new System.Drawing.Point(850, 24);
            this.grasperLabel.Name = "grasperLabel";
            this.grasperLabel.Size = new System.Drawing.Size(44, 13);
            this.grasperLabel.TabIndex = 26;
            this.grasperLabel.Text = "Grasper";
            // 
            // marker1Label
            // 
            this.marker1Label.AutoSize = true;
            this.marker1Label.Location = new System.Drawing.Point(850, 67);
            this.marker1Label.Name = "marker1Label";
            this.marker1Label.Size = new System.Drawing.Size(49, 13);
            this.marker1Label.TabIndex = 27;
            this.marker1Label.Text = "Marker 1";
            // 
            // marker2Label
            // 
            this.marker2Label.AutoSize = true;
            this.marker2Label.Location = new System.Drawing.Point(850, 110);
            this.marker2Label.Name = "marker2Label";
            this.marker2Label.Size = new System.Drawing.Size(49, 13);
            this.marker2Label.TabIndex = 28;
            this.marker2Label.Text = "Marker 2";
            // 
            // torpedo2Label
            // 
            this.torpedo2Label.AutoSize = true;
            this.torpedo2Label.Location = new System.Drawing.Point(970, 110);
            this.torpedo2Label.Name = "torpedo2Label";
            this.torpedo2Label.Size = new System.Drawing.Size(56, 13);
            this.torpedo2Label.TabIndex = 29;
            this.torpedo2Label.Text = "Torpedo 2";
            // 
            // torpedo1Label
            // 
            this.torpedo1Label.AutoSize = true;
            this.torpedo1Label.Location = new System.Drawing.Point(970, 67);
            this.torpedo1Label.Name = "torpedo1Label";
            this.torpedo1Label.Size = new System.Drawing.Size(56, 13);
            this.torpedo1Label.TabIndex = 30;
            this.torpedo1Label.Text = "Torpedo 1";
            // 
            // releaseLabel
            // 
            this.releaseLabel.AutoSize = true;
            this.releaseLabel.Location = new System.Drawing.Point(970, 24);
            this.releaseLabel.Name = "releaseLabel";
            this.releaseLabel.Size = new System.Drawing.Size(46, 13);
            this.releaseLabel.TabIndex = 31;
            this.releaseLabel.Text = "Release";
            // 
            // grasperBox
            // 
            this.grasperBox.Location = new System.Drawing.Point(850, 42);
            this.grasperBox.Name = "grasperBox";
            this.grasperBox.Size = new System.Drawing.Size(100, 20);
            this.grasperBox.TabIndex = 32;
            // 
            // marker1Box
            // 
            this.marker1Box.Location = new System.Drawing.Point(850, 85);
            this.marker1Box.Name = "marker1Box";
            this.marker1Box.Size = new System.Drawing.Size(100, 20);
            this.marker1Box.TabIndex = 33;
            // 
            // marker2Box
            // 
            this.marker2Box.Location = new System.Drawing.Point(850, 128);
            this.marker2Box.Name = "marker2Box";
            this.marker2Box.Size = new System.Drawing.Size(100, 20);
            this.marker2Box.TabIndex = 34;
            // 
            // releaseBox
            // 
            this.releaseBox.Location = new System.Drawing.Point(970, 42);
            this.releaseBox.Name = "releaseBox";
            this.releaseBox.Size = new System.Drawing.Size(100, 20);
            this.releaseBox.TabIndex = 35;
            // 
            // torpedo1Box
            // 
            this.torpedo1Box.Location = new System.Drawing.Point(970, 85);
            this.torpedo1Box.Name = "torpedo1Box";
            this.torpedo1Box.Size = new System.Drawing.Size(100, 20);
            this.torpedo1Box.TabIndex = 36;
            // 
            // torpedo2Box
            // 
            this.torpedo2Box.Location = new System.Drawing.Point(970, 128);
            this.torpedo2Box.Name = "torpedo2Box";
            this.torpedo2Box.Size = new System.Drawing.Size(100, 20);
            this.torpedo2Box.TabIndex = 37;
            // 
            // killSwitchBox
            // 
            this.killSwitchBox.Location = new System.Drawing.Point(697, 111);
            this.killSwitchBox.Name = "killSwitchBox";
            this.killSwitchBox.Size = new System.Drawing.Size(100, 20);
            this.killSwitchBox.TabIndex = 38;
            // 
            // killSwitchLabel
            // 
            this.killSwitchLabel.AutoSize = true;
            this.killSwitchLabel.Location = new System.Drawing.Point(633, 111);
            this.killSwitchLabel.Name = "killSwitchLabel";
            this.killSwitchLabel.Size = new System.Drawing.Size(55, 13);
            this.killSwitchLabel.TabIndex = 39;
            this.killSwitchLabel.Text = "Kill Switch";
            // 
            // depthLabel
            // 
            this.depthLabel.AutoSize = true;
            this.depthLabel.Location = new System.Drawing.Point(1092, 24);
            this.depthLabel.Name = "depthLabel";
            this.depthLabel.Size = new System.Drawing.Size(36, 13);
            this.depthLabel.TabIndex = 40;
            this.depthLabel.Text = "Depth";
            // 
            // altitudeLabel
            // 
            this.altitudeLabel.AutoSize = true;
            this.altitudeLabel.Location = new System.Drawing.Point(1093, 67);
            this.altitudeLabel.Name = "altitudeLabel";
            this.altitudeLabel.Size = new System.Drawing.Size(42, 13);
            this.altitudeLabel.TabIndex = 41;
            this.altitudeLabel.Text = "Altitude";
            // 
            // temperatureLabel
            // 
            this.temperatureLabel.AutoSize = true;
            this.temperatureLabel.Location = new System.Drawing.Point(1093, 110);
            this.temperatureLabel.Name = "temperatureLabel";
            this.temperatureLabel.Size = new System.Drawing.Size(67, 13);
            this.temperatureLabel.TabIndex = 42;
            this.temperatureLabel.Text = "Temperature";
            // 
            // depthBox
            // 
            this.depthBox.Location = new System.Drawing.Point(1093, 41);
            this.depthBox.Name = "depthBox";
            this.depthBox.Size = new System.Drawing.Size(100, 20);
            this.depthBox.TabIndex = 43;
            // 
            // altitudeBox
            // 
            this.altitudeBox.Location = new System.Drawing.Point(1093, 84);
            this.altitudeBox.Name = "altitudeBox";
            this.altitudeBox.Size = new System.Drawing.Size(100, 20);
            this.altitudeBox.TabIndex = 44;
            // 
            // temperatureBox
            // 
            this.temperatureBox.Location = new System.Drawing.Point(1093, 127);
            this.temperatureBox.Name = "temperatureBox";
            this.temperatureBox.Size = new System.Drawing.Size(100, 20);
            this.temperatureBox.TabIndex = 45;
            // 
            // motor1Label
            // 
            this.motor1Label.AutoSize = true;
            this.motor1Label.Location = new System.Drawing.Point(381, 180);
            this.motor1Label.Name = "motor1Label";
            this.motor1Label.Size = new System.Drawing.Size(43, 13);
            this.motor1Label.TabIndex = 46;
            this.motor1Label.Text = "Motor 1";
            // 
            // motor2Label
            // 
            this.motor2Label.AutoSize = true;
            this.motor2Label.Location = new System.Drawing.Point(586, 180);
            this.motor2Label.Name = "motor2Label";
            this.motor2Label.Size = new System.Drawing.Size(43, 13);
            this.motor2Label.TabIndex = 47;
            this.motor2Label.Text = "Motor 2";
            // 
            // motor3Label
            // 
            this.motor3Label.AutoSize = true;
            this.motor3Label.Location = new System.Drawing.Point(791, 180);
            this.motor3Label.Name = "motor3Label";
            this.motor3Label.Size = new System.Drawing.Size(43, 13);
            this.motor3Label.TabIndex = 48;
            this.motor3Label.Text = "Motor 3";
            // 
            // motor4Label
            // 
            this.motor4Label.AutoSize = true;
            this.motor4Label.Location = new System.Drawing.Point(996, 180);
            this.motor4Label.Name = "motor4Label";
            this.motor4Label.Size = new System.Drawing.Size(43, 13);
            this.motor4Label.TabIndex = 49;
            this.motor4Label.Text = "Motor 4";
            // 
            // motor5Label
            // 
            this.motor5Label.AutoSize = true;
            this.motor5Label.Location = new System.Drawing.Point(381, 212);
            this.motor5Label.Name = "motor5Label";
            this.motor5Label.Size = new System.Drawing.Size(43, 13);
            this.motor5Label.TabIndex = 50;
            this.motor5Label.Text = "Motor 5";
            // 
            // motor6Label
            // 
            this.motor6Label.AutoSize = true;
            this.motor6Label.Location = new System.Drawing.Point(586, 212);
            this.motor6Label.Name = "motor6Label";
            this.motor6Label.Size = new System.Drawing.Size(43, 13);
            this.motor6Label.TabIndex = 51;
            this.motor6Label.Text = "Motor 6";
            // 
            // motor7Label
            // 
            this.motor7Label.AutoSize = true;
            this.motor7Label.Location = new System.Drawing.Point(791, 212);
            this.motor7Label.Name = "motor7Label";
            this.motor7Label.Size = new System.Drawing.Size(43, 13);
            this.motor7Label.TabIndex = 52;
            this.motor7Label.Text = "Motor 7";
            // 
            // motor8Label
            // 
            this.motor8Label.AutoSize = true;
            this.motor8Label.Location = new System.Drawing.Point(996, 212);
            this.motor8Label.Name = "motor8Label";
            this.motor8Label.Size = new System.Drawing.Size(43, 13);
            this.motor8Label.TabIndex = 53;
            this.motor8Label.Text = "Motor 8";
            // 
            // motor1Box
            // 
            this.motor1Box.Location = new System.Drawing.Point(445, 176);
            this.motor1Box.Name = "motor1Box";
            this.motor1Box.Size = new System.Drawing.Size(100, 20);
            this.motor1Box.TabIndex = 54;
            // 
            // motor2Box
            // 
            this.motor2Box.Location = new System.Drawing.Point(650, 176);
            this.motor2Box.Name = "motor2Box";
            this.motor2Box.Size = new System.Drawing.Size(100, 20);
            this.motor2Box.TabIndex = 55;
            // 
            // motor3Box
            // 
            this.motor3Box.Location = new System.Drawing.Point(855, 176);
            this.motor3Box.Name = "motor3Box";
            this.motor3Box.Size = new System.Drawing.Size(100, 20);
            this.motor3Box.TabIndex = 56;
            // 
            // motor4Box
            // 
            this.motor4Box.Location = new System.Drawing.Point(1060, 176);
            this.motor4Box.Name = "motor4Box";
            this.motor4Box.Size = new System.Drawing.Size(100, 20);
            this.motor4Box.TabIndex = 57;
            // 
            // motor5Box
            // 
            this.motor5Box.Location = new System.Drawing.Point(445, 208);
            this.motor5Box.Name = "motor5Box";
            this.motor5Box.Size = new System.Drawing.Size(100, 20);
            this.motor5Box.TabIndex = 58;
            // 
            // motor6Box
            // 
            this.motor6Box.Location = new System.Drawing.Point(650, 208);
            this.motor6Box.Name = "motor6Box";
            this.motor6Box.Size = new System.Drawing.Size(100, 20);
            this.motor6Box.TabIndex = 59;
            // 
            // motor7Box
            // 
            this.motor7Box.Location = new System.Drawing.Point(855, 208);
            this.motor7Box.Name = "motor7Box";
            this.motor7Box.Size = new System.Drawing.Size(100, 20);
            this.motor7Box.TabIndex = 60;
            // 
            // motor8Box
            // 
            this.motor8Box.Location = new System.Drawing.Point(1060, 208);
            this.motor8Box.Name = "motor8Box";
            this.motor8Box.Size = new System.Drawing.Size(100, 20);
            this.motor8Box.TabIndex = 61;
            // 
            // camera3Panel
            // 
            this.camera3Panel.Location = new System.Drawing.Point(541, 311);
            this.camera3Panel.Name = "camera3Panel";
            this.camera3Panel.Size = new System.Drawing.Size(258, 227);
            this.camera3Panel.TabIndex = 62;
            // 
            // histogramPanel
            // 
            this.histogramPanel.Location = new System.Drawing.Point(1069, 311);
            this.histogramPanel.Name = "histogramPanel";
            this.histogramPanel.Size = new System.Drawing.Size(258, 227);
            this.histogramPanel.TabIndex = 63;
            // 
            // camera2Panel
            // 
            this.camera2Panel.Location = new System.Drawing.Point(277, 311);
            this.camera2Panel.Name = "camera2Panel";
            this.camera2Panel.Size = new System.Drawing.Size(258, 227);
            this.camera2Panel.TabIndex = 64;
            // 
            // camera4Panel
            // 
            this.camera4Panel.Location = new System.Drawing.Point(805, 311);
            this.camera4Panel.Name = "camera4Panel";
            this.camera4Panel.Size = new System.Drawing.Size(258, 227);
            this.camera4Panel.TabIndex = 65;
            // 
            // camera1Panel
            // 
            this.camera1Panel.Location = new System.Drawing.Point(13, 311);
            this.camera1Panel.Name = "camera1Panel";
            this.camera1Panel.Size = new System.Drawing.Size(258, 227);
            this.camera1Panel.TabIndex = 66;
            // 
            // PrimaryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 575);
            this.Controls.Add(this.camera1Panel);
            this.Controls.Add(this.camera4Panel);
            this.Controls.Add(this.camera2Panel);
            this.Controls.Add(this.histogramPanel);
            this.Controls.Add(this.camera3Panel);
            this.Controls.Add(this.motor8Box);
            this.Controls.Add(this.motor7Box);
            this.Controls.Add(this.motor6Box);
            this.Controls.Add(this.motor5Box);
            this.Controls.Add(this.motor4Box);
            this.Controls.Add(this.motor3Box);
            this.Controls.Add(this.motor2Box);
            this.Controls.Add(this.motor1Box);
            this.Controls.Add(this.motor8Label);
            this.Controls.Add(this.motor7Label);
            this.Controls.Add(this.motor6Label);
            this.Controls.Add(this.motor5Label);
            this.Controls.Add(this.motor4Label);
            this.Controls.Add(this.motor3Label);
            this.Controls.Add(this.motor2Label);
            this.Controls.Add(this.motor1Label);
            this.Controls.Add(this.temperatureBox);
            this.Controls.Add(this.altitudeBox);
            this.Controls.Add(this.depthBox);
            this.Controls.Add(this.temperatureLabel);
            this.Controls.Add(this.altitudeLabel);
            this.Controls.Add(this.depthLabel);
            this.Controls.Add(this.killSwitchLabel);
            this.Controls.Add(this.killSwitchBox);
            this.Controls.Add(this.torpedo2Box);
            this.Controls.Add(this.torpedo1Box);
            this.Controls.Add(this.releaseBox);
            this.Controls.Add(this.marker2Box);
            this.Controls.Add(this.marker1Box);
            this.Controls.Add(this.grasperBox);
            this.Controls.Add(this.releaseLabel);
            this.Controls.Add(this.torpedo1Label);
            this.Controls.Add(this.torpedo2Label);
            this.Controls.Add(this.marker2Label);
            this.Controls.Add(this.marker1Label);
            this.Controls.Add(this.grasperLabel);
            this.Controls.Add(this.yawRadiansBox);
            this.Controls.Add(this.rollRadiansBox);
            this.Controls.Add(this.pitchRadiansBox);
            this.Controls.Add(this.yawLabel);
            this.Controls.Add(this.rollLabel);
            this.Controls.Add(this.pitchLabel);
            this.Controls.Add(this.zInputPercentLabel);
            this.Controls.Add(this.yInputPercentLabel);
            this.Controls.Add(this.xInputPercentLabel);
            this.Controls.Add(this.zInputLabel);
            this.Controls.Add(this.yInputLabel);
            this.Controls.Add(this.xInputLabel);
            this.Controls.Add(this.controlInputLabel);
            this.Controls.Add(this.batteryTimeRemainingBox);
            this.Controls.Add(this.batt2PercentLabel);
            this.Controls.Add(this.batt1PercentLabel);
            this.Controls.Add(this.timeRemainingLabel);
            this.Controls.Add(this.battery2Label);
            this.Controls.Add(this.battery1Label);
            this.Controls.Add(this.detectEdgesBtn);
            this.Controls.Add(this.edgesDetectedPanel);
            this.Name = "PrimaryDisplay";
            this.Text = "RoboSUB";
            this.Load += new System.EventHandler(this.PrimaryDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel edgesDetectedPanel;
        private System.Windows.Forms.Button detectEdgesBtn;
        private System.Windows.Forms.Label battery1Label;
        private System.Windows.Forms.Label battery2Label;
        private System.Windows.Forms.Label timeRemainingLabel;
        private System.Windows.Forms.Label batt1PercentLabel;
        private System.Windows.Forms.Label batt2PercentLabel;
        private System.Windows.Forms.TextBox batteryTimeRemainingBox;
        private System.Windows.Forms.Label controlInputLabel;
        private System.Windows.Forms.Label xInputLabel;
        private System.Windows.Forms.Label yInputLabel;
        private System.Windows.Forms.Label zInputLabel;
        private System.Windows.Forms.Label xInputPercentLabel;
        private System.Windows.Forms.Label yInputPercentLabel;
        private System.Windows.Forms.Label zInputPercentLabel;
        private System.Windows.Forms.Label pitchLabel;
        private System.Windows.Forms.Label rollLabel;
        private System.Windows.Forms.Label yawLabel;
        private System.Windows.Forms.TextBox pitchRadiansBox;
        private System.Windows.Forms.TextBox rollRadiansBox;
        private System.Windows.Forms.TextBox yawRadiansBox;
        private System.Windows.Forms.Label grasperLabel;
        private System.Windows.Forms.Label marker1Label;
        private System.Windows.Forms.Label marker2Label;
        private System.Windows.Forms.Label torpedo2Label;
        private System.Windows.Forms.Label torpedo1Label;
        private System.Windows.Forms.Label releaseLabel;
        private System.Windows.Forms.TextBox grasperBox;
        private System.Windows.Forms.TextBox marker1Box;
        private System.Windows.Forms.TextBox marker2Box;
        private System.Windows.Forms.TextBox releaseBox;
        private System.Windows.Forms.TextBox torpedo1Box;
        private System.Windows.Forms.TextBox torpedo2Box;
        private System.Windows.Forms.TextBox killSwitchBox;
        private System.Windows.Forms.Label killSwitchLabel;
        private System.Windows.Forms.Label depthLabel;
        private System.Windows.Forms.Label altitudeLabel;
        private System.Windows.Forms.Label temperatureLabel;
        private System.Windows.Forms.TextBox depthBox;
        private System.Windows.Forms.TextBox altitudeBox;
        private System.Windows.Forms.TextBox temperatureBox;
        private System.Windows.Forms.Label motor1Label;
        private System.Windows.Forms.Label motor2Label;
        private System.Windows.Forms.Label motor3Label;
        private System.Windows.Forms.Label motor4Label;
        private System.Windows.Forms.Label motor5Label;
        private System.Windows.Forms.Label motor6Label;
        private System.Windows.Forms.Label motor7Label;
        private System.Windows.Forms.Label motor8Label;
        private System.Windows.Forms.TextBox motor1Box;
        private System.Windows.Forms.TextBox motor2Box;
        private System.Windows.Forms.TextBox motor3Box;
        private System.Windows.Forms.TextBox motor4Box;
        private System.Windows.Forms.TextBox motor5Box;
        private System.Windows.Forms.TextBox motor6Box;
        private System.Windows.Forms.TextBox motor7Box;
        private System.Windows.Forms.TextBox motor8Box;
        private System.Windows.Forms.Panel camera3Panel;
        private System.Windows.Forms.Panel histogramPanel;
        private System.Windows.Forms.Panel camera2Panel;
        private System.Windows.Forms.Panel camera4Panel;
        private System.Windows.Forms.Panel camera1Panel;
    }
}