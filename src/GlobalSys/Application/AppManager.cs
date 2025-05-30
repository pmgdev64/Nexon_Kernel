using System;
using System.Collections.Generic;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using NexonKernel.Driver

namespace NexonKernel.Application {
    public static class AppManager {
        private static List<AppWindow> windows = new List<AppWindow>();
        private static Canvas canvas;
        
        public static void Initialize(Canvas mainCanvas) {
            canvas = mainCanvas;
        }
        
        public static void OpenApp(App app) {
            windows.Add(new AppWindow(app, 100, 100, 300, 200));
            DrawAll();
        }
        
        public static void DrawAll() {
            canvas.Clear(Color.LightGray);
            foreach (var win in windows)
            win.Draw(canvas);
            canvas.Display();
        }
    }
}
