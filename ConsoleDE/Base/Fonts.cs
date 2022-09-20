using SixLabors.Fonts;

namespace ConsoleDE.Base {
    public static class Fonts {
        public static readonly Font DefaultFont = new("Comic Sans", FontStyle.Regular);

        public static void LoadContent() {
            DefaultFont.LoadContent();
        }
    }
}