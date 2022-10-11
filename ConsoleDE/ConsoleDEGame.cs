using System.Diagnostics;
using ConsoleDE.Base.Styling;
using ConsoleDE.Base.UserInterface;
using ConsoleDE.Screens;
using ConsoleDE.Services;
using Eto.Forms;
using Furball.Engine;
using Furball.Engine.Engine.Graphics.Drawables;
using Silk.NET.Windowing;
using Fonts = ConsoleDE.Base.Styling.Fonts;
using Screen = Furball.Engine.Engine.Screen;

namespace ConsoleDE {
    public class ConsoleDEGame : FurballGame {
        public ConsoleDEGame() : base(new MainScreen()) {}

        public new static ConsoleDEGame Instance => (ConsoleDEGame)FurballGame.Instance;
        public IWindowSuspensionService WindowSuspensionService;

        public bool GamescopeAvailable { get; private set; } = false;

        private ColorPalette palette = Palettes.AllPalettes[0];
        public ColorPalette CurrentPalette {
            get => this.palette;
            set {
                this.palette = value;
                (this.RunningScreen as ConsoleScreen)?.UpdateColors(value);
            }
        }

        /// <summary>
        /// Run the game with custom window options.
        /// </summary>
        /// <param name="options">The <see cref="WindowOptions"/> to start up with.</param>
        public void Run(WindowOptions options) => base.Run(options); // expose protected function

        protected override void Initialize() {
            base.Initialize();

            TooltipDrawable.TextDrawable.SetFont(Fonts.Default, TooltipDrawable.TextDrawable.FontSize);

            // When unfocused, limit to 30fps (debug) or 1fps (release).
            #if DEBUG
            this.WindowManager.TargetUnfocusedFramerate = 30;
            #else
            this.WindowManager.TargetUnfocusedFramerate = 1;
            #endif

            this.WindowManager.TargetUnfocusedUpdaterate = 30;
            this.WindowManager.EnableUnfocusCap = true;

            // We don't need low latency and high framerates.
            // Just stick to what the display is capable of.
            this.WindowManager.VerticalSync = true;

//            this.WindowSuspensionService = new WindowBackendSuspensionService(this);
            this.WindowSuspensionService = new WindowStateSuspensionService(this);

            // Gamescope does not like the state suspension service
            if(this.WindowSuspensionService is WindowBackendSuspensionService) {
                Process? gamescopeProcess = Process.Start("gamescope", "--help");
                if(gamescopeProcess == null) GamescopeAvailable = false;
                else {
                    gamescopeProcess.WaitForExit();
                    GamescopeAvailable = gamescopeProcess.ExitCode == 0;
                }
            }

            base.AfterScreenChange += AfterScreenChange;
        }

        private new void AfterScreenChange(object? sender, Screen e) {
            (this.RunningScreen as ConsoleScreen)?.UpdateColors(this.CurrentPalette);
        }

        protected override void LoadContent() {
            Fonts.LoadContent();
            base.LoadContent();
        }
    }
}