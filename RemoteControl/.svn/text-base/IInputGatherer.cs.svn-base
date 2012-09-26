using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.RemoteControl {
    interface IInputGatherer {
        /// <summary>
        /// Provides a method for a listener to register for event notifications.
        /// </summary>
        /// <param name="listener"></param>
        void RegisterListener(IInputListener listener);

        /// <summary>
        /// Notifies registered listeners that an event has happened. Should send
        /// array of bytes as outlined in IInputListener
        /// </summary>
        void NotifyListeners();

        void RequestXMotion(sbyte speed);

        void RequestYMotion(sbyte speed);

        void RequestZMotion(sbyte speed);

        void RequestXRotation(sbyte speed);

        void RequestYRotation(sbyte speed);

        void RequestZRotation(sbyte speed);

        /// <summary>
        /// The byte passed in represents which torpedo to fire
        /// </summary>
        /// <param name="torpedo"></param>
        void RequestTorpedoFire(sbyte torpedo);

        /// <summary>
        /// The byte passed in represents which marker to drop
        /// </summary>
        /// <param name="marker"></param>
        void RequestMarkerDrop(sbyte marker);

        void RequestGrasp();

        void RequestRelease();

        void RequestKillSwitch();

        void RequestMovement();
    }
}
