using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base.Styling {
    public class ColorPalette {
        public Color PrimaryColor;
        public Color SecondaryColor;
        public Color TextColor;
        public Color BackgroundColor;

        public ColorPalette() {
            this.PrimaryColor = Color.Black;
            this.SecondaryColor = Color.Black;
            this.TextColor = Color.Black;
            this.BackgroundColor = Color.Black;
        }
    }
}