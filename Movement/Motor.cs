using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.Exceptions;
using Pololu.Jrk;

namespace RoboSub.Movement
{ /// <summary>
    /// Contains the reference to a single motor, its 3D coordinate, and whether it's reversible.
    /// Used to control the specific motor. 
    /// Input is expected to be between negative 100 and positive 100,
    /// representing the percentage of max power to operate at. Negative input indicates reverse,
    /// and if the motor is not capable of reverse, an InvalidInputException is thrown.
    /// </summary>
    class Motor
    {
        #region variables
        public MotorInfo info;

        /// <summary>
        /// Represents the current speed;
        /// </summary>
        public sbyte speed;
        public const sbyte MAX_SPEED = 30;//percentage of actual maximum amperage to pass
        public const sbyte RAMP_SPEED = 1;//percentage of actual maximum amperage to ramp by every pass
        public const int RAMP_PAUSE_MILLISECONDS = 5;//pause between rampage passes
        #endregion

        #region constructors
        /// <summary>
        /// Builds a Motor with the appropriate specifications. Only the horizontal angle and elevation angle have direct getters and setters.
        /// </summary>
        /// <param name="xLoc"></param>
        /// <param name="yLoc"></param>
        /// <param name="zLoc"></param>
        /// <param name="horizontalAngle"></param>
        /// <param name="elevationAngle"></param>
        /// <param name="reversable"></param>
        /// <param name="controller"></param>
        public Motor(int xLoc, int yLoc, int zLoc, int horizontalAngle, int elevationAngle, bool reversable, Jrk controller, String name)
            : this(new MotorInfo(null, xLoc, yLoc, zLoc, horizontalAngle, elevationAngle, reversable, controller, name))
        {
        }

        public Motor(MotorInfo info, Jrk controller)
        {
            if (controller == null)
            {
                throw new InvalidInputException("Motor must have Jrk controller attached!");
            }
            this.info = info;
            this.info.controller = controller;
            this.info.controller.setJrkParameter(jrkParameter.PARAMETER_MOTOR_COAST_WHEN_OFF, 0);//set to brake when power is turned off
            SetSpeed(0);
        }

        public Motor(MotorInfo info) :
            this(info, info.controller)
        {
        }

        #endregion

        #region speed adjustment
        /// <summary>
        /// Sets speed as a percentage of total value
        /// </summary>
        /// <param name="speed"></param>
        private void SetSpeed(sbyte speed)
        {
            if (speed > MAX_SPEED)
            {
                speed = MAX_SPEED;
            }
            else if (speed < -MAX_SPEED)
            {
                speed = -MAX_SPEED;
            }
            this.speed = speed;
            RequestSpeed(speed);
        }

        public void RequestSpeed(sbyte requestedSpeed)
        {
            //test for error conditions
            if (requestedSpeed < 0 && !info.reversable)
            {
                SetSpeed(0);
                throw new RoboSub.Exceptions.InvalidInputException("Motor not reversible.", null);
            }
            else if (requestedSpeed < -MAX_SPEED || requestedSpeed > MAX_SPEED)
            {
                SetSpeed(0);
                throw new RoboSub.Exceptions.InvalidInputException("Input speed more than 100%.", null);
            }

            //indicates which direction to change speed
            bool increaseSpeed = requestedSpeed > speed;
            bool ramping = true;

            //step by RAMP_SPEED% until desired speed reached
            while (ramping)
            {
                if (increaseSpeed)
                {
                    speed += RAMP_SPEED;

                    if (speed > requestedSpeed)
                    {
                        ramping = false;
                    }
                    SetSpeed((sbyte)(speed));

                }
                else
                {
                    speed -= RAMP_SPEED;
                    if (speed < requestedSpeed)
                    {
                        ramping = false;
                    }
                    SetSpeed((sbyte)(speed));
                }
                System.Threading.Thread.Sleep(RAMP_PAUSE_MILLISECONDS);//sleep briefly to prevent abrupt changes
            }
        }

        /// <summary>
        /// Instantly stops the motor.
        /// </summary>
        public void KillMotors()
        {
            TurnOffMotor();
        }

        public void TurnOffMotor()
        {
            info.controller.motorOff();            
        }

        #endregion

        /// <summary>
        /// Provides a method for getting both the target and scaled feedback values. Items
        /// are in the returned list in that order.
        /// </summary>
        /// <returns></returns>
        public List<string> GetStatus()
        {
            List<string> ret = new List<string>();
            ret.Add(info.controller.getVariables().target.ToString());
            ret.Add(info.controller.getVariables().current.ToString());
            ret.Add(info.controller.getVariables().dutyCycle.ToString());
            //ret.Add(info.controller.getVariables().scaledFeedback.ToString());
            return ret;
        }
    }

    /// <summary>
    /// Data structure to hold all the information of one single motor
    /// </summary>
    class MotorInfo
    {
        public string serial;
        public int xPos;
        public int yPos;
        public int zPos;
        public int horzTheta;
        public int vertTheta;
        public bool reversable;
        public Jrk controller;
        public string name;

        public MotorInfo(string serial, int xPos, int yPos, int zPos, int horzTheta, int vertTheta, bool reversable, Jrk controller, string name)
        {
            this.serial = serial;
            this.xPos = xPos;
            this.yPos = yPos;
            this.zPos = zPos;
            this.horzTheta = horzTheta;
            this.vertTheta = vertTheta;
            this.reversable = reversable;
            this.controller = controller;
            this.name = name;
        }
    }
}
