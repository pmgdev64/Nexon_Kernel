using System;
using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using NexonKernel.Command;
using NexonKernel.FileSystem;
using NexonKernel.Gui;

namespace NexonKernel.Command {
    public class InstallCommand : BaseCommand {
        public Font myFont;
        public Canvas canvas;
        public SystemInstalliationUi systeminstalliationui;
        public override string Name = "Install";
        public override string Description = "Install the system to the HardDisk";

        public override void Execute(string[] args) {
            canvas = FullScreenCanvas.GetFullScreenCanvas();
            systeminstalliationui = new SystemInstalliationUi(canvas);
            //Installer.installSystem();
        }
    }
}
