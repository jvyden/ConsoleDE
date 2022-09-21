using Silk.NET.Windowing;

namespace ConsoleDE {
    internal static class Program {
        internal static void Main(string[] args) {
            // We don't need low latency and high framerates.
            // Just stick to what the display is capable of.
            WindowOptions options = WindowOptions.Default;
            options.VSync = true; 
            #if !DEBUG
            options.WindowState = WindowState.Fullscreen;
            options.WindowBorder = WindowBorder.Hidden;
            #endif

            ConsoleDEGame game = new();
            game.Run(options);
        }
    }
}

