using System.Diagnostics.Contracts;
using FontStashSharp;
using Furball.Engine.Engine.Graphics;
using SixLabors.Fonts;

namespace ConsoleDE.Base.Styling {
    public class Font {
        internal readonly FontSystemSettings Settings;
        internal FontSystem System { get; private set; }
        internal readonly string FamilyName;
        internal readonly FontStyle Style;
        
        public Font(string familyName, FontStyle style, FontSystemEffect effect = FontSystemEffect.None) {
            this.FamilyName = familyName;
            this.Style = style;
            
            this.Settings = new FontSystemSettings {
                FontResolutionFactor = 2f,
                KernelWidth = 1,
                KernelHeight = 1,
                Effect = effect,
                TextureWidth = 2048,
                TextureHeight = 2048,
            };

            this.System = new FontSystem(this.Settings);
        }

        public void LoadContent() {
            this.System = ContentManager.LoadSystemFont(this.FamilyName, this.Style, this.Settings);
        }

        [Pure]
        public static implicit operator FontSystem(Font font) => font.System;
    }
}