using System.Linq;
using Furball.Engine.Engine;
using Furball.Engine.Engine.Graphics.Drawables.Primitives;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;

namespace ConsoleDE.Base {
    public class ConsoleScreen : Screen {
        public void UpdateColors() {
            foreach(DrawableButton button in this.Manager.Drawables.OfType<DrawableButton>()) {
                ColorPalette palette = ConsoleDEGame.Instance.CurrentPalette;
                
                button.ButtonColor = palette.PrimaryColor;
                button.TextColor = palette.TextColor;
                button.OutlineColor = palette.SecondaryColor;

//                button.Drawables[0].ColorOverride = palette.PrimaryColor; // background
//                button.Drawables[1].ColorOverride = palette.SecondaryColor; // outline
            }
        }
    }
}