using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RoboSub.RemoteControl {
    class OutputToConsole : IInputListener {
        public OutputToConsole(IInputGatherer boss) {
            boss.RegisterListener(this);
        }

        static void Main() {
            new OutputToConsole();
        }

        public OutputToConsole() {
            IInputGatherer boss = new BaseGatherer();
            Thread controller = new Thread(new Xbox360Pad(boss).Main);
            controller.Start();
            boss.RegisterListener(this);
            System.Console.WriteLine("Output set up.");
            //while (true) { }
        }

        #region IInputListener Members

        void IInputListener.InputNotify(sbyte[] input) {
            System.Console.Clear();
            System.Console.Write("x: " + input[(int) InputMessageValues.xMagnitude] + " ");
            System.Console.Write("y: " + input[(int) InputMessageValues.yMagnitude] + " ");
            System.Console.Write("z: " + input[(int) InputMessageValues.zMagnitude] + " ");
            System.Console.Write("roll: " + input[(int) InputMessageValues.roll] + " ");
            System.Console.Write("pitch: " + input[(int) InputMessageValues.pitch] + " ");
            System.Console.Write("yaw: " + input[(int) InputMessageValues.yaw] + " ");
            System.Console.Write("torp: " + input[(int) InputMessageValues.torpedo] + " ");
            System.Console.Write("mark: " + input[(int) InputMessageValues.marker] + " ");
            System.Console.Write("grasp: " + input[(int) InputMessageValues.grasp] + " ");
            System.Console.Write("release: " + input[(int) InputMessageValues.release] + " ");
            System.Console.Write("kill: " + input[(int) InputMessageValues.kill]);
            System.Console.WriteLine();
            System.Console.WriteLine();
        }

        #endregion
    }
}
