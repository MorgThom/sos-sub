using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.Movement
{
    /// <summary>
    /// Provides a convenient way to build up the list of motors that are connected.
    /// Should be converted to read from a text file at some point.
    /// </summary>
    class HandCodeMotorConstants
    {
        private const string controller1 = "00024514";
        private const string controller2 = "00008379";
        private const string controller3 = "00014978";
        private const string controller4 = "00014141";
        private const string controller5 = "00014139";
        private const string controller6 = "00013557";
        public static int STRAIGHT=0, RIGHT=1, BACK=2, LEFT=3;
        /// <summary>
        /// Array that contains the information for each of the connected motors.
        /// </summary>
        public static MotorInfo[] handCodedMotors = new MotorInfo[6]{ 
          new MotorInfo(controller1, 0, 1, 0, 0, 1, true, null, "Front Vert"),
          new MotorInfo(controller2, 0, -1, 0, 0, 1, true, null, "Back Vert"),
          new MotorInfo(controller3, -1, 0, 0, 1, 0, true, null, "Back Strafe"),
          new MotorInfo(controller4, 1, 0, 0, 3, 0, true, null, "Forward Strafe"),
          new MotorInfo(controller5, -1, 0, 0, 0, 0, true, null, "Left Side"),
          new MotorInfo(controller6, 1, 0, 0, 0, 0, true, null, "Right Side"),
    };
}
}

