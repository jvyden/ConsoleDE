using System.Diagnostics;
using System.Numerics;
using ConsoleDE.Base.Applications;
using ConsoleDE.Base.Styling;
using ConsoleDE.Base.UserInterface;
using Furball.Engine;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Engine.Engine.Input.Events;

namespace ConsoleDE.Screens {
    public class MainScreen : ConsoleScreen {
        public override void Initialize() {
            base.Initialize();
            
            this.Manager.Add(new ConsoleButton(new Vector2(20, 20),
                Fonts.Default,
                24,
                "Hide for 5 seconds",
                new Vector2(250, 50),
                this.hideButtonOnClick)
            );

            this.Manager.Add(new ConsoleButton(new Vector2(20, 90),
                Fonts.Default,
                24,
                "Launch RetroArch",
                new Vector2(250, 50),
                this.retroArchButtonOnClick)
            );

            this.Manager.Add(new ConsoleButton(new Vector2(20, 160),
                Fonts.Default,
                24,
                "Cycle Themes",
                new Vector2(250, 50),
                this.themeTestScreenButtonOnClick)
            );

            DesktopFileParser parser = new();
            DesktopApplication appVLC = new(parser.Parse("/usr/share/applications/vlc.desktop"));
            DesktopApplication appSteam = new(parser.Parse("/usr/share/applications/steam.desktop"));
            
            this.Manager.Add(new DrawableDesktopApplication(new Vector2(320, 20), appVLC));
            this.Manager.Add(new DrawableDesktopApplication(new Vector2(560, 20), appSteam));
        }

        private void hideButtonOnClick(object? sender, MouseButtonEventArgs e) {
            ConsoleDEGame.Instance.WindowSuspensionService.Hide();

            FurballGame.GameTimeScheduler.ScheduleMethod(delegate {
                ConsoleDEGame.Instance.WindowSuspensionService.Show();
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