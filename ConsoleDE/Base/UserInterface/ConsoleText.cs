using System.Numerics;
using ConsoleDE.Base.Styling;
using FontStashSharp;
using Furball.Engine.Engine.Graphics.Drawables;

namespace ConsoleDE.Base.UserInterface {
    public class ConsoleText : TextDrawable, ISupportsPalettes {
        public ConsoleText(Vector2 position, FontSystem font, string text, float fontSize) : base(position, font, text, fontSize) {}
        
        public void UpdateColors(ColorPalette palette) {
            this.FadeColor(palette.TextColor, 500);
        }
    }
}