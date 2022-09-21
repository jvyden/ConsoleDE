using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base {
    public static class Palettes {
        public static readonly ColorPalette Light = new(Color.White, Color.LightGray, Color.Black);
        public static readonly ColorPalette Dark = new(Color.Black, Color.DimGray, Color.White);

        public static readonly ColorPalette Slate = new(new Color(110,101,168), new Color(127,116,194), new Color(246,245,252));
    }
}