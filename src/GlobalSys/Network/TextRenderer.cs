using System;
using Cosmos.System.Graphics;
using System.Drawing;

namespace NexonKernel.Network
{
    public static class TextRenderer
    {
        private static Canvas canvas;
        private static int cursorY = 0;

        public static void Init(Canvas sysCanvas)
        {
            canvas = sysCanvas;
            cursorY = 0;
            canvas.Clear(Color.Black);
        }

        public static void Print(string text, Color color)
        {
            int cursorX = 0;
            foreach (char c in text)
            {
                if (c == '\n') {
                    cursorY += 16;
                    cursorX = 0;
                }
                else {
                    canvas.DrawString(c.ToString(), PSFFont.Default, color, cursorX, cursorY);
                    cursorX += 8;
                }
            }
            cursorY += 16;
        }

        public static void Clear()
        {
            canvas.Clear(Color.Black);
            cursorY = 0;
        }
    }
}
