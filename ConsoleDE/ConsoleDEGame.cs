using ConsoleDE.Base.Styling;
using ConsoleDE.Base.UserInterface;
using ConsoleDE.Screens;
using ConsoleDE.Services;
using Furball.Engine;
using Furball.Engine.Engine;
using Silk.NET.Windowing;
using Fonts = ConsoleDE.Base.Styling.Fonts;

namespace ConsoleDE {
    public class ConsoleDEGame : FurballGame {
        public ConsoleDEGame() : base(new MainScreen()) {}

        public new static ConsoleDEGame Instance => (ConsoleDEGame)FurballGame.Instance;
        public IWindowSuspensionService WindowSuspensionService;

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

            // When unfocused, limit to 30fps (debug) or 1fps (release).
            #if DEBUG
            this.WindowManager.TargetUnfocusedFramerate = 30;
            #else
            this.WindowManager.TargetUnfocusedFramerate = 1;
            #endif
            
            this.WindowManager.TargetUnfocusedUpdaterate = 30;

//            this.WindowSuspensionService = new WindowBackendSuspensionService(this);
            this.WindowSuspensionService = new WindowStateSuspensionService(this);
            
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