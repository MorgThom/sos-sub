using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.RemoteControl {
    /// <summary>
    /// Due to the nature of enums in C#, these values can be used to refer to the array
    /// element corresponding to the expected value.
    /// New values must be added to the end of the list so that legacy code will be unaffected.
    /// Code using these values should have a robust default section that can deal with new values
    /// in a sensible way, ie: no runtime errors generated.
    /// </summary>
    public enum InputMessageValues : int { xMagnitude, yMagnitude, zMagnitude, roll, pitch, yaw, torpedo, marker, grasp, release, kill }

    interface IInputListener {

        /// <summary> 
        /// Elements of the byte array are as follows:
        /// X Magnitude
        /// Y Magnitude
        /// Z Magnitude
        /// Roll
        /// Pitch
        /// Yaw
        /// --------all of the above will be from -100 to 100 as a percentage of maximum
        /// Torpedo to fire (0 for no torpedo otherwise # of the specific torpedo to fire)
        /// Marker to drop (0 for no marker otherwise # of the specific marker to drop)
        /// Activate grasper (0 for no activation, 1 for activation)
        /// Activate release (0 for no activation, 1 for activation)
        /// Activate kill switch (0 for no activation, 1 for activation)
        /// </summary>
        /// <param name="message"></param>
        void InputNotify(sbyte[] message);
    }
}
