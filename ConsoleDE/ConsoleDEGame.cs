using System.Numerics;
using ConsoleDE.Base;
using ConsoleDE.Screens;
using Eto.Drawing;
using Furball.Engine;
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

        protected override void LoadContent() {
            Fonts.LoadContent();
            base.LoadContent();
        }
    }
}