using System;
using System.Collections.Generic;
using Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using NexonKernel.Driver;

namespace NexonKernel.Application {
    public abstract class App {
        public abstract string Title { get; }
        public abstract string TitleIcon { get; }
        public abstract void OnDraw(Canvas canvas);
        public abstract void OnClick(int x, int y);
        public abstract void Update();
    }
}