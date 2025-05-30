using System;
using System.Collections.Generic;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using NexonKernel.Driver
using NexonKernel.Application;

namespace NexonKernel.Application {
    public class AppWindow {
        private App app;
        private int x, y, width, height;
        private int boxX = 100;
        private int boxY = 100;
        private int boxWidth = 400;
        private int boxHeight = 200;

        private bool isDragging = false;
        private int dragOffsetX = 0;
        private int dragOffsetY = 0;
        
        public AppWindow(App app, int x, int y, int width, int height) {
            this.app = app;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        
        public void Draw(Canvas canvas) {
            HandleMouse();

            // Clear previous dialog (optional)
            canvas.Clear(Color.LightGray);

            // Draw background
            canvas.DrawFilledRectangle(Color.White, boxX, boxY, boxWidth, boxHeight);

            // Draw border
            canvas.DrawRectangle(Color.DarkGray, boxX, boxY, boxWidth, boxHeight);

            // Title Bar
            canvas.DrawFilledRectangle(Color.LightBlue, boxX, boxY, boxWidth, 30);
            canvas.DrawString(title, PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Black, boxX + 10, boxY + 8);
            
            while(true) 
            {
                DrawScreen()
                UpdateScreen()
            }

            /* 
            // Message
            canvas.DrawString(message, PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Black, boxX + 20, boxY + 50);

            // Confirm button
            int btnWidth = 150;
            int btnHeight = 40;
            int btnX = boxX + (boxWidth - btnWidth) / 2;
            int btnY = boxY + boxHeight - 60;

            canvas.DrawFilledRectangle(Color.LightBlue, btnX, btnY, btnWidth, btnHeight);
            canvas.DrawRectangle(Color.Blue, btnX, btnY, btnWidth, btnHeight);
            canvas.DrawString("Example Button", PCScreenFont.LoadFont("Sysfont/ComicSans.psf"), Color.Black, btnX + 40, btnY + 10); 
            */

            canvas.Display();
        }
        
        private void DrawScreen() 
        {
            return;
        }
        
        private void UpdateScreen()
        {
            return;
        }
        
        private void HandleMouse()
        {
            int mouseX = (int)MouseManager.X;
            int mouseY = (int)MouseManager.Y;
            bool isPressed = MouseManager.MouseState == MouseState.Left;

            // Title bar drag zone (30px high)
            bool inDragZone = mouseX >= boxX && mouseX <= boxX + boxWidth &&
                              mouseY >= boxY && mouseY <= boxY + 30;

            if (isPressed && inDragZone && !isDragging)
            {
                isDragging = true;
                dragOffsetX = mouseX - boxX;
                dragOffsetY = mouseY - boxY;
            }

            if (!isPressed)
            {
                isDragging = false;
            }

            if (isDragging)
            {
                boxX = mouseX - dragOffsetX;
                boxY = mouseY - dragOffsetY;
            }
        }
    }
}
