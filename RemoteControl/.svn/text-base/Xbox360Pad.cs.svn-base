
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;



//set up main with a while true loop,update state,  check switch button, condence button methods

namespace RoboSub.RemoteControl {

    //class that handles the input from the XBox controller
    class Xbox360Pad {
        public static bool swap = false; //used in the switch control scheme
        IInputGatherer gatherer;


        public Xbox360Pad(IInputGatherer gatherer) {
            this.gatherer = gatherer;
        }
        #region Controller State

        public static sbyte LeftThumbX {
            get {
                Vector2 vector = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Left;
                vector.Normalize();
                sbyte ret = (sbyte) (vector.X * 100);
                return ret;
            }
        }

        public static sbyte LeftThumbY {
            get {
                Vector2 vector = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Left;
                vector.Normalize();
                sbyte ret = (sbyte) (vector.Y * 100);
                return ret;
            }
        }

        public static sbyte LeftTrigger {
            get {
                float triggerVal = GamePad.GetState(PlayerIndex.One).Triggers.Left;
                sbyte ret = (sbyte) (triggerVal * 100);
                return ret;
            }
        }

        public static sbyte RightTrigger {
            get {
                float triggerVal = GamePad.GetState(PlayerIndex.One).Triggers.Right;
                sbyte ret = (sbyte) (triggerVal * 100);
                return ret;
            }
        }

        public static sbyte RightThumbX {
            get {
                Vector2 vector = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Right;
                vector.Normalize();
                sbyte ret = (sbyte) (vector.X * 100);
                return ret;
            }
        }

        public static sbyte RightThumbY {
            get {
                Vector2 vector = GamePad.GetState(PlayerIndex.One, GamePadDeadZone.Circular).ThumbSticks.Left;
                vector.Normalize();
                sbyte ret = (sbyte) (vector.Y * 100);
                return ret;
            }
        }
        #endregion



        public void Main() {
            System.Console.WriteLine("Attached devices: ");
            System.Console.WriteLine("1 attached: " + GamePad.GetState(PlayerIndex.One).IsConnected);
            System.Console.WriteLine("2 attached: " + GamePad.GetState(PlayerIndex.Two).IsConnected);
            System.Console.WriteLine("3 attached: " + GamePad.GetState(PlayerIndex.Three).IsConnected);
            System.Console.WriteLine("4 attached: " + GamePad.GetState(PlayerIndex.Four).IsConnected);
            while (true) {
                CheckButtons();
                CheckSwitchButton();

                if (swap == false) {
                    DirectControl();
                }
                if (swap == true) {
                    LinearControl();

                }
                gatherer.RequestMovement();
                System.Threading.Thread.Sleep(10);
            }
        }

        public void CheckButtons() {
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed) {
                gatherer.RequestTorpedoFire(1);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed) {
                gatherer.RequestTorpedoFire(2);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed) {
                gatherer.RequestMarkerDrop(1);
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed) {
                gatherer.RequestMarkerDrop(2);
            }
        }

        public void CheckSwitchButton()//switches control schemes
    {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed) {
                swap = true;
            }
            if (swap == true) {
                LinearControl();
            } else if (swap == false)
                DirectControl();

        }

        public void DirectControl()//direct control controlls motor banks
        {   //left stick controlls


           if (LeftThumbX != 0)//left side vert motors
            {

                gatherer.RequestZRotation(LeftThumbX);
                gatherer.RequestZMotion(0);


            }
            if (LeftThumbY != 0)//left main drive motors
            {

                gatherer.RequestYRotation(LeftThumbY);
                gatherer.RequestYMotion(0);

            }



            //right side controls      

            if (RightThumbX != 0)// right vert motors
            {

                gatherer.RequestZRotation(RightThumbX);
                gatherer.RequestZMotion(0);

            }
           if(RightThumbY != 0)//right main drive motors
            {
                gatherer.RequestYRotation(RightThumbY);
                gatherer.RequestYMotion(0);
                
            }


            if (LeftTrigger > 0)//foward vert motors
            {

                gatherer.RequestZRotation(LeftTrigger);
                gatherer.RequestZMotion(0);

            }
            if (RightTrigger > 0) //rear vert motors
            {

                gatherer.RequestZRotation((sbyte) (-1 * RightTrigger));
                gatherer.RequestZMotion(0);
            }

        }


        //linear control scheme
        public void LinearControl() {

            if (LeftThumbX != 0) {
                gatherer.RequestZMotion(LeftThumbX);
                gatherer.RequestZRotation(0);

            }
            if (LeftThumbY != 0)// all main drive
            {
                gatherer.RequestXMotion(LeftThumbY);
                gatherer.RequestXRotation(0);
                

            }

            if (RightThumbX != 0)// x rotation
            {

                gatherer.RequestXRotation(RightThumbX);
                gatherer.RequestXMotion(0);
               

            }
            if (RightThumbY != 0) //controls pitch on y axis
            {

                gatherer.RequestYRotation(RightThumbY);              
                gatherer.RequestYMotion(0);
               

            }
            //right trigger
            if (RightTrigger > 0)//raise sub
            {

                gatherer.RequestYMotion(RightTrigger);               
                gatherer.RequestYRotation(0);
               

            }
            //left trigger
            if (LeftTrigger > 0)//sinks sub
            {
                gatherer.RequestYMotion((sbyte) (-1 * LeftTrigger));
                gatherer.RequestYRotation(0);
               

            }
        }

    }
}