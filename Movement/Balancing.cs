using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.Movement
{
    class Balancing
    {
        List<Motor> motors = new List<Motor>();
        List<Motor> LeftFrontVerticalMotors = new List<Motor>();
        List<Motor> RightFrontVerticalMotors = new List<Motor>();
        List<Motor> LeftRearVerticalMotors = new List<Motor>();
        List<Motor> RightRearVerticalMotors = new List<Motor>();
        List<Motor> LeftThrustMotors = new List<Motor>();
        List<Motor> RightThrustMotors = new List<Motor>();
        List<Motor> FrontStrafeMotors = new List<Motor>();
        List<Motor> RearStrafeMotors = new List<Motor>();
    }
}
