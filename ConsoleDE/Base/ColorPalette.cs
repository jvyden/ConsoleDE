using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base {
    public readonly struct ColorPalette {
        public readonly Color PrimaryColor;
        public readonly Color SecondaryColor;
        public readonly Color TextColor;
        
        public ColorPalette(Color primary, Color secondary, Color text) {
            this.PrimaryColor = primary;
            this.SecondaryColor = secondary;
            this.TextColor = text;
        }
    }
}