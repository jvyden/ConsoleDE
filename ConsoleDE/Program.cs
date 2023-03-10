using System;
using System.Diagnostics;
using System.Text.Json;
using System.Threading;
using ConsoleDE.Base.Applications;
using Silk.NET.Windowing;

namespace ConsoleDE {
    internal static class Program {
        internal static void Main(string[] args) {
            WindowOptions options = WindowOptions.Default;

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

