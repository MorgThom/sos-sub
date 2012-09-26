using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.Movement
{
    class StopMotors
    {
        public static void Main()
        {
            DirectMotorLink.KillAllMotors();
        }
    }
}
