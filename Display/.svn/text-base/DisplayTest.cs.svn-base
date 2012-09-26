using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RoboSub.RemoteControl;
using System.Threading;
using System.Windows.Forms;

namespace RoboSub.Display {
    class DisplayTest {

        static void Main() {
            new DisplayTest();
        }

        static PrimaryDisplay display = new PrimaryDisplay();

        DisplayTest() {
            IInputGatherer boss = new BaseGatherer();
            Thread controller = new Thread(new Xbox360Pad(boss).Main);
            controller.Start();
            boss.RegisterListener(display);
            Application.Run(display);
            //IInputListener console = new OutputToConsole(boss);
            //boss.RegisterListener(console);
            System.Console.WriteLine("Build Done.");
        }

    }
}
