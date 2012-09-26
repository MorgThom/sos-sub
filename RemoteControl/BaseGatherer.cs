using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoboSub.RemoteControl {
    class BaseGatherer : IInputGatherer {

        List<IInputListener> listeners = new List<IInputListener>();
        sbyte[] message = new sbyte[11];

        public BaseGatherer() {
            ResetMessage();
        }

        /// <summary>
        /// Sets all elements of the message to zero
        /// </summary>
        private void ResetMessage() {
            for (int i = 0; i < message.Length; i++) {//initialize all data to be 0
                message[i] = 0;
            }
        }

        #region IInputGatherer Members

        public void RegisterListener(IInputListener listener) {
            listeners.Add(listener);
        }

        public void NotifyListeners() {
            foreach (IInputListener i in listeners) {
                i.InputNotify(message);
            }
            System.Threading.Thread.Sleep(20);
        }

        public void RequestMovement() {
            NotifyListeners();
            ResetMessage();
        }

        public void RequestXMotion(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.xMagnitude] = speed;
            }
        }

        public void RequestYMotion(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.yMagnitude] = speed;
            }
        }

        public void RequestZMotion(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.zMagnitude] = speed;
            }
        }

        public void RequestXRotation(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.roll] = speed;
            }
        }

        public void RequestYRotation(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.pitch] = speed;
            }
        }

        public void RequestZRotation(sbyte speed) {
            if (speed <= 100 && speed >= -100) {
                message[(int) InputMessageValues.yaw] = speed;
            }
        }

        public void RequestTorpedoFire(sbyte torpedo) {
            if (torpedo == 1 || torpedo == 2) {
                message[(int) InputMessageValues.torpedo] = torpedo;
            }
        }

        public void RequestMarkerDrop(sbyte marker) {
            if (marker == 1 || marker == 2) {
                message[(int) InputMessageValues.marker] = marker;
            }
        }

        public void RequestGrasp() {
            message[(int) InputMessageValues.grasp] = 1;
            message[(int) InputMessageValues.release] = 0;
        }

        public void RequestRelease() {
            message[(int) InputMessageValues.grasp] = 0;
            message[(int) InputMessageValues.release] = 1;
        }

        public void RequestKillSwitch() {
            message[(int) InputMessageValues.kill] = 1;
        }

        #endregion
    }
}
