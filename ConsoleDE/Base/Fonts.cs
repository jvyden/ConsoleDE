using SixLabors.Fonts;

namespace ConsoleDE.Base {
    public static class Fonts {
        public static readonly Font DefaultFont = new("SF Pro Display", FontStyle.Bold);

        public static void LoadContent() {
            DefaultFont.LoadContent();
        }
    }
}