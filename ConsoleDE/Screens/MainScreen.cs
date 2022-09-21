using System.Diagnostics;
using System.Linq;
using System.Numerics;
using ConsoleDE.Base;
using Furball.Engine;
using Furball.Engine.Engine.Graphics.Drawables;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Engine.Engine.Input.Events;
using Furball.Vixie;
using Furball.Vixie.Backends.Shared.Backends;
using Screen = Furball.Engine.Engine.Screen;

namespace ConsoleDE.Screens {
    public class MainScreen : ConsoleScreen {
        private DrawableButton hideButton;
        private DrawableButton retroArchButton;
        private DrawableButton themeTestScreenButton;
        
        public override void Initialize() {
            this.Manager.Add(this.hideButton = new DrawableButton(new Vector2(20, 20),
                Fonts.DefaultFont,
                24,
                "Hide for 5 seconds",
                ConsoleDEGame.Instance.CurrentPalette.PrimaryColor,
                ConsoleDEGame.Instance.CurrentPalette.TextColor,
                ConsoleDEGame.Instance.CurrentPalette.SecondaryColor,
                new Vector2(250, 50)));

            this.Manager.Add(this.retroArchButton = new DrawableButton(new Vector2(20, 90),
                Fonts.DefaultFont,
                24,
                "Launch RetroArch",
                ConsoleDEGame.Instance.CurrentPalette.PrimaryColor,
                ConsoleDEGame.Instance.CurrentPalette.TextColor,
                ConsoleDEGame.Instance.CurrentPalette.SecondaryColor,
                new Vector2(250, 50)));

            this.Manager.Add(this.themeTestScreenButton = new DrawableButton(new Vector2(20, 160),
                Fonts.DefaultFont,
                24,
                "Cycle Themes",
                ConsoleDEGame.Instance.CurrentPalette.PrimaryColor,
                ConsoleDEGame.Instance.CurrentPalette.TextColor,
                ConsoleDEGame.Instance.CurrentPalette.SecondaryColor,
                new Vector2(250, 50)));

            this.hideButton.OnClick += hideButtonOnOnClick;
            this.retroArchButton.OnClick += retroArchButtonOnOnClick;
            this.themeTestScreenButton.OnClick += themeTestScreenButtonOnOnClick;
        }

        private void hideButtonOnOnClick(object? sender, MouseButtonEventArgs e) {
            Backend currentBackend = FurballGame.Instance.WindowManager.Backend;
            EventLoop currentEventLoop = FurballGame.Instance.EventLoop;

            FurballGame.Instance.WindowManager.Backend = Backend.Dummy;
            FurballGame.Instance.RecreateWindow(new HeadlessEventLoop());

            FurballGame.GameTimeScheduler.ScheduleMethod(delegate {
                FurballGame.Instance.WindowManager.Backend = currentBackend;
                FurballGame.Instance.RecreateWindow(currentEventLoop);
            }, FurballGame.Time + 5000d);
        }

        private void retroArchButtonOnOnClick(object? sender, MouseButtonEventArgs e) {
            Process.Start(new ProcessStartInfo("retroarch"));
        }

        private int currentTheme = 0;
        private void themeTestScreenButtonOnOnClick(object? sender, MouseButtonEventArgs e) {
            ConsoleDEGame.Instance.CurrentPalette = this.currentTheme switch {
                0 => Palettes.Dark,
                1 => Palettes.Slate,
                2 => Palettes.Light,
            };
            
            this.currentTheme++;
            if(this.currentTheme == 3) {
                this.currentTheme = 0;
            }
        }
    }
}