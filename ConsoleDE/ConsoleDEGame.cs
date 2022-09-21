using ConsoleDE.Base;
using ConsoleDE.Screens;
using Furball.Engine;
using Silk.NET.Windowing;
using Fonts = ConsoleDE.Base.Fonts;

namespace ConsoleDE {
    public class ConsoleDEGame : FurballGame {
        public ConsoleDEGame() : base(new MainScreen()) {}

        public new static ConsoleDEGame Instance => (ConsoleDEGame)FurballGame.Instance;

        private ColorPalette palette = Palettes.Light;
        public ColorPalette CurrentPalette {
            get => this.palette;
            set {
                this.palette = value;
                (this.RunningScreen as ConsoleScreen)?.UpdateColors();
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
        }

        protected override void LoadContent() {
            Fonts.LoadContent();
            base.LoadContent();
        }
    }
}