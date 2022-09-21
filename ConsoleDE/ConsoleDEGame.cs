using ConsoleDE.Base;
using ConsoleDE.Screens;
using Furball.Engine;
using Silk.NET.Windowing;
using Fonts = ConsoleDE.Base.Fonts;

namespace ConsoleDE {
    public class ConsoleDEGame : FurballGame {
        public ConsoleDEGame() : base(new MainScreen()) {}

        public static ConsoleDEGame Instance => (ConsoleDEGame)FurballGame.Instance;

        private ColorPalette palette = Palettes.Light;
        public ColorPalette CurrentPalette {
            get {
                return this.palette;
            }
            set {
                this.palette = value;
                (this.RunningScreen as ConsoleScreen)?.UpdateColors();
            }
        }

        public void Run(WindowOptions options) {
            base.Run(options);
        }

        protected override void Initialize() {
            base.Initialize();
            
            this.WindowManager.TargetUnfocusedFramerate = 30;
            this.WindowManager.TargetUnfocusedUpdaterate = 30;
        }

        protected override void LoadContent() {
            Fonts.LoadContent();
            base.LoadContent();
        }
    }
}