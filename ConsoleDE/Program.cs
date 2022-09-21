using Silk.NET.Windowing;

namespace ConsoleDE {
    internal static class Program {
        internal static void Main(string[] args) {
            WindowOptions options = WindowOptions.Default;
            
            // We don't need low latency and high framerates.
            // Just stick to what the display is capable of.
            options.VSync = true;
            
            // On a developer system, fullscreen would get in the way.
            // The intended use-case is being a "desktop environment" of sorts, on a dedicated computer.
            //
            // Thus, we only fullscreen on release builds.
            #if !DEBUG
            options.WindowState = WindowState.Fullscreen;
            options.WindowBorder = WindowBorder.Hidden;
            #endif

            ConsoleDEGame game = new();
            game.Run(options);
        }
    }
}

