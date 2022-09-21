using System.Collections.Generic;
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

            this.Manager.Add(new ConsoleButton(new Vector2(290, 20),
                Fonts.Default,
                24,
                "Cycle Themes",
                new Vector2(250, 50),
                this.themeTestScreenButtonOnClick)
            );

            DesktopFileParser parser = new();

            List<DesktopApplication> applications = new() {
                new DesktopApplication(parser.Parse("/usr/share/applications/vlc.desktop")),
                new DesktopApplication(parser.Parse("/usr/share/applications/steam.desktop")),
                new DesktopApplication(parser.Parse("/usr/share/applications/retroarch.desktop")),
            };

            float y = FurballGame.WindowHeight / 2 - 220 / 2;
            
            int i = 0;
            foreach(DesktopApplication application in applications) {
                this.Manager.Add(new DrawableDesktopApplication(new Vector2(20 + (i * 240), y), application));
                i++;
            }
        }

        private void hideButtonOnClick(object? sender, MouseButtonEventArgs e) {
            ConsoleDEGame.Instance.WindowSuspensionService.Hide();

            FurballGame.GameTimeScheduler.ScheduleMethod(delegate {
                ConsoleDEGame.Instance.WindowSuspensionService.Show();
            }, FurballGame.Time + 5000d);
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