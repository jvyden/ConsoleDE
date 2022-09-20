using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base {
    public readonly struct ColorPalette {
        public readonly Color MainColor;
        public readonly Color SecondaryColor;
        public readonly Color TextColor;
        
        public ColorPalette(Color main, Color secondary, Color text) {
            this.MainColor = main;
            this.SecondaryColor = secondary;
            this.TextColor = text;
        }
    }
}