using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using ConsoleDE.Base.Styling;
using Furball.Engine.Engine.Graphics.Drawables;
using Furball.Engine.Engine.Graphics.Drawables.Primitives;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Vixie.Backends.Shared;
using Screen = Furball.Engine.Engine.Screen;

namespace ConsoleDE.Base.UserInterface {
    public class ConsoleScreen : Screen, ISupportsPalettes {
        private protected RectanglePrimitiveDrawable? background;

        public override void Initialize() {
            this.background = new RectanglePrimitiveDrawable(Vector2.Zero, ConsoleDEGame.Instance.WindowManager.WindowSize, 1, true);
            this.background.Clickable = false;
            this.background.ColorOverride = Color.Black;
            
            this.Manager.Add(this.background);
            
            base.Initialize();
        }

        public override void Relayout(float newWidth, float newHeight) {
            if(this.background != null) {
                this.background.RectSize = new Vector2(newWidth, newHeight);
            }
            base.Relayout(newWidth, newHeight);
        }

        private void UpdateColorsRecursively(IEnumerable<Drawable> list, ColorPalette palette) {
            foreach(Drawable drawable in list) {
                if(drawable is ISupportsPalettes paletteDrawable) {
                    paletteDrawable.UpdateColors(palette);
                }

                if(drawable is CompositeDrawable compositeDrawable) {
                    UpdateColorsRecursively(compositeDrawable.Drawables, palette);
                }
            }
        }

        public void UpdateColors(ColorPalette palette) {
            this.background?.FadeColor(palette.BackgroundColor, 500);
            
            UpdateColorsRecursively(this.Manager.Drawables, palette);

            foreach(DrawableButton button in this.Manager.Drawables.OfType<DrawableButton>()) {
                button.ButtonColor = palette.PrimaryColor;
                button.TextColor = palette.TextColor;
                button.OutlineColor = palette.SecondaryColor;
            }
        }
    }
}