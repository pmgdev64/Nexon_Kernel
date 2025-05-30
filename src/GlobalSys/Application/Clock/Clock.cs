using System;
using NexonKernel.Kernel;
using System.Drawing;
using Cosmos.System.Graphic;
using NexonKernel.Application;

namespace NexonKernel.Application {
    public class Clock : App {
        public override string Title = "Terminal";
        public override void OnDraw(Canvas canvas) {
            canvas.DrawString("Shell@NexonKernel: ~$ ", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Black, 110, 140);
        }
        public override void OnClick(int x, int y) {
            // For example, focus or click button
        }
    }
}