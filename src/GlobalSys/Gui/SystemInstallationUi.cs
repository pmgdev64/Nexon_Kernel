using Cosmos.System.Graphics;
using System;
using Cosmos.System;
using System.Drawing;
using NexonKernel.Filesystem.Installer;

namespace NexonKernel.Gui {
    public class SystemInstalliationUi
    {
        private Canvas canvas;
        private int progress = 0;
        private int frame = 0;
        
        public SystemInstalliationUi(Canvas canvas)
        {
            this.canvas = canvas;
        }
        
        public void Render()
        {
            canvas.Clear(Color.FromArgb(20, 20, 40)); // Deep blue background
            
            DrawTitle();
            DrawPanel();
            DrawProgressBar();
            DrawStatusText();
            
            Installer.installSystem();
        }
        
        private void DrawTitle()
        {
            canvas.DrawString("Nexon Kernel Installer", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Cyan, 50, 30);
        }
        
        private void DrawPanel()
        {
            int x = 40, y = 70, w = 240, h = 100;
            canvas.DrawFilledRectangle(Color.FromArgb(30, 30, 60), x, y, w, h);
            canvas.DrawRectangle(Color.Cyan, x, y, w, h);
        }
        
        private void DrawProgressBar()
        {
            int x = 60, y = 130, width = 200, height = 10;
            canvas.DrawRectangle(Color.White, x, y, width, height);
            canvas.DrawFilledRectangle(Color.Cyan, x, y, progress * width / 100, height);
        }
        
        private void DrawStatusText()
        {
            string[] statusTexts = {
                "Preparing installation...",
                "Copying files...",
                "Installing system...",
                "Finalizing setup..."
                "Restarting...";
            };
            
            string status = statusTexts[(progress / 25) % statusTexts.Length];
            canvas.DrawString(status, PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.White, 60, 110);
            
            frame++;
            if (frame % 10 == 0) {
                progress = (progress + 1) % 101;
            }
        }
    }
}
