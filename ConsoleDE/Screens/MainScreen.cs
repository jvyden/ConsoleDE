using System.Numerics;
using ConsoleDE.Base;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Screen = Furball.Engine.Engine.Screen;

namespace ConsoleDE.Screens {
    public class MainScreen : Screen {
        public override void Initialize() {
            this.Manager.Add(new DrawableButton(new Vector2(20, 20),
                Fonts.DefaultFont,
                24,
                "buton",
                Palettes.Light.MainColor,
                Palettes.Light.TextColor,
                Palettes.Light.SecondaryColor,
                new Vector2(100, 50)));
        }
    }
}