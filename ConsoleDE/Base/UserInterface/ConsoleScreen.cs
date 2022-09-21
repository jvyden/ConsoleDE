using System.Linq;
using System.Numerics;
using ConsoleDE.Base.Styling;
using Furball.Engine.Engine;
using Furball.Engine.Engine.Graphics.Drawables.Primitives;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;

namespace ConsoleDE.Base.UserInterface {
    public class ConsoleScreen : Screen {
        private protected RectanglePrimitiveDrawable? background;

        public override void Initialize() {
            this.background = new RectanglePrimitiveDrawable(Vector2.Zero, ConsoleDEGame.Instance.WindowManager.WindowSize, 1, true);
            this.background.Clickable = false;
            this.background.ColorOverride = ConsoleDEGame.Instance.CurrentPalette.BackgroundColor;
            
            this.Manager.Add(this.background);
            
            base.Initialize();
        }

        public override void Relayout(float newWidth, float newHeight) {
            if(this.background != null) {
                this.background.RectSize = new Vector2(newWidth, newHeight);
            }
            base.Relayout(newWidth, newHeight);
        }

        public void UpdateColors(ColorPalette palette) {
            this.background?.FadeColor(palette.BackgroundColor, 500);

            foreach(ISupportsPalettes drawable in this.Manager.Drawables.OfType<ISupportsPalettes>()) {
                drawable.UpdateColors(palette);
            }
            
            foreach(DrawableButton button in this.Manager.Drawables.OfType<DrawableButton>()) {
                button.ButtonColor = palette.PrimaryColor;
                button.TextColor = palette.TextColor;
                button.OutlineColor = palette.SecondaryColor;
            }
        }
    }
}