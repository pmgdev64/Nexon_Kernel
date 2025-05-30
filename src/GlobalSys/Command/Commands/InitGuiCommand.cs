using System;
using Cosmos.System;
using NexonKernel.Command;
using NexonKernel.Gui;

namespace NexonKernel.Command {
    public class InitGuiCommand : BaseCommand {

        public override string Name = "InitGui";
        public override string Description = "Load the Graphic Ui";

        public override void Execute(string[] args) {
            Console.WriteLine("Gui is loading....");
            Gui.loadGui();
        }
    }
}
