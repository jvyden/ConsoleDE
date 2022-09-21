using SixLabors.Fonts;

namespace ConsoleDE.Base.Styling {
    public static class Fonts {
        public static readonly Font Default = new("Ubuntu", FontStyle.Regular);

        public static void LoadContent() {
            Default.LoadContent();
        }
    }
}