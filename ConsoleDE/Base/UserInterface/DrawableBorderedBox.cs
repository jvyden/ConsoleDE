using System.Numerics;
using ConsoleDE.Base.Styling;
using Furball.Engine.Engine.Graphics.Drawables;
using Furball.Engine.Engine.Graphics.Drawables.Primitives;

namespace ConsoleDE.Base.UserInterface {
    public class DrawableBorderedBox : CompositeDrawable, ISupportsPalettes {
        private readonly RectanglePrimitiveDrawable backgroundDrawable;
        public readonly RectanglePrimitiveDrawable OutlineDrawable;
        
        public DrawableBorderedBox(Vector2 position, Vector2 size, bool dontAddOutline = false, int borderSize = 5) {
            this.backgroundDrawable = new RectanglePrimitiveDrawable(position, size, 1, true);
            this.OutlineDrawable = new RectanglePrimitiveDrawable(position, size, borderSize, false);
            
            this.Children.Add(this.backgroundDrawable);
            if(!dontAddOutline) this.Children.Add(this.OutlineDrawable);
        }

        public void UpdateColors(ColorPalette palette) {
            this.backgroundDrawable.FadeColor(palette.PrimaryColor, 500);
            this.OutlineDrawable.FadeColor(palette.SecondaryColor, 500);
        }
    }
}