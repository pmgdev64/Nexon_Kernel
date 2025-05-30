using System;
using System.Collections.Generic;
using Cosmos.System;
using Cosmos.Core;
using Cosmos.System.FileSystem.VFS;
using Cosmos.System.Graphics;
using System.Drawing;

namespace NexonKernel.Gui
{
    public class Gui
    {
        private Canvas canvas;

        // Bitmaps
        private Bitmap bg;
        private Bitmap iconCafe;
        private Bitmap iconSchedule;
        private Bitmap iconMission;

        public Gui(Canvas canvas)
        {
            this.canvas = canvas;

            // Load bitmaps from resources or embed them
            bg = new Bitmap("textures/Background.bmp"); // Must be 24-bit BMP
            iconCafe = new Bitmap("textures/icon_cafe.bmp");
            iconSchedule = new Bitmap("textures/icon_schedule.bmp");
            iconMission = new Bitmap("textures/icon_mission.bmp");
        }

        public void loadGui()
        {
            CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            
            frameCount++;
            
            // Check if one second has passed
            DateTime currentTime = DateTime.Now;
            if ((currentTime - lastTime).TotalSeconds >= 1)
            {
                fps = frameCount;
                frameCount = 0;
                lastTime = currentTime;
            }
            
            uint freeRAM = GCImplementation.GetAvailableRAM();
            
            canvas.DrawImage(bg, 0, 0);

            
            // Top UI bar
            canvas.DrawFilledRectangle(Color.FromArgb(255, 255, 255), 0, 0, canvas.Mode.Columns, 50);
            canvas.DrawString("Disk {VFSManager.GetDisks()} | {freeRAM}Mb Free | Cpu: ? | Fps: {fps}", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Black, 10, 15);

            // Icons (you can adjust positions as needed)
            canvas.DrawImage(iconCafe, 20, 400);
            canvas.DrawString("Cafe", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.White, 25, 450);

            canvas.DrawImage(iconSchedule, 100, 400);
            canvas.DrawString("Schedule", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.White, 95, 450);

            canvas.DrawImage(iconMission, 200, 400);
            canvas.DrawString("Mission", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.White, 210, 450);
            
            try
            {
                Cosmos.System.MouseManager.ScreenWidth = (uint)canvas.Mode.Columns;
                Cosmos.System.MouseManager.ScreenHeight = (uint)canvas.Mode.Rows;
                Pen pen = new Pen(Color.Red);
                int X = (int)Cosmos.System.MouseManager.X;
                int Y = (int)Cosmos.System.MouseManager.Y;
                canvas.DrawLine(pen, X, Y, X + 5, Y);
                canvas.DrawLine(pen, X, Y, X, Y - 5);
                canvas.DrawLine(pen, X, Y, X + 5, Y - 5);
            }
            catch (Exception ex)
            {
                return;
            }

            canvas.Display();
        }
    }
}
