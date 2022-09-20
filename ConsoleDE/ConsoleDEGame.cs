using ConsoleDE.Base;
using ConsoleDE.Screens;
using Furball.Engine;

namespace ConsoleDE {
    public class ConsoleDEGame : FurballGame {
        public ConsoleDEGame() : base(new MainScreen()) {}

        protected override void LoadContent() {
            Fonts.LoadContent();
            base.LoadContent();
        }
    }
}