using System.Diagnostics;
using System.Numerics;
using ConsoleDE.Base;
using Furball.Engine;
using Furball.Engine.Engine.Input.Events;
using Furball.Vixie;
using Furball.Vixie.Backends.Shared.Backends;

namespace ConsoleDE.Screens {
    public class MainScreen : ConsoleScreen {
        public override void Initialize() {
            base.Initialize();
            
            this.Manager.Add(new ConsoleButton(new Vector2(20, 20),
                Fonts.DefaultFont,
                24,
                "Hide for 5 seconds",
                new Vector2(250, 50),
                this.hideButtonOnClick)
            );

            this.Manager.Add(new ConsoleButton(new Vector2(20, 90),
                Fonts.DefaultFont,
                24,
                "Launch RetroArch",
                new Vector2(250, 50),
                this.retroArchButtonOnClick)
            );

            this.Manager.Add(new ConsoleButton(new Vector2(20, 160),
                Fonts.DefaultFont,
                24,
                "Cycle Themes",
                new Vector2(250, 50),
                this.themeTestScreenButtonOnClick)
            );
        }

        private void hideButtonOnClick(object? sender, MouseButtonEventArgs e) {
            Backend currentBackend = FurballGame.Instance.WindowManager.Backend;
            EventLoop currentEventLoop = FurballGame.Instance.EventLoop;

            FurballGame.Instance.WindowManager.Backend = Backend.Dummy;
            FurballGame.Instance.RecreateWindow(new HeadlessEventLoop());

            FurballGame.GameTimeScheduler.ScheduleMethod(delegate {
                FurballGame.Instance.WindowManager.Backend = currentBackend;
                FurballGame.Instance.RecreateWindow(currentEventLoop);
            }, FurballGame.Time + 5000d);
        }

        private void retroArchButtonOnClick(object? sender, MouseButtonEventArgs e) {
            Process.Start(new ProcessStartInfo("retroarch"));
        }

        private int currentTheme = 1;
        private void themeTestScreenButtonOnClick(object? sender, MouseButtonEventArgs e) {
            ConsoleDEGame.Instance.CurrentPalette = Palettes.AllPalettes[this.currentTheme];
            
            this.currentTheme++;
            if(this.currentTheme == Palettes.AllPalettes.Count) {
                this.currentTheme = 0;
            }
        }
    }
}