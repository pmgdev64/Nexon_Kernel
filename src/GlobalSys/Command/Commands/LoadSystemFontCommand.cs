using System;
using Cosmos.System;
using Cosmos.System.Graphics.Fonts;
using NexonKernel.Command;

namespace NexonKernel.Command {
    public class LoadSystemFontCommand : BaseCommand {
        public Font myFont;
        public override string Name = "Loadsystemfont";
        public override string Description = "Load the available font in Sysfont";

        public override void Execute(string[] args) {
            myFont = PCScreenFont.LoadFont("Sysfont/ComicSans.psf");  // Replace with your file name
        }
    }
}
