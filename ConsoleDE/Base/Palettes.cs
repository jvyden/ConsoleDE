using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base {
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Palettes {
        public static readonly ColorPalette Light = new(Color.White, Color.LightGray, Color.Black);
        public static readonly ColorPalette Dark = new(Color.Black, Color.DimGray, Color.White);
        public static readonly ColorPalette Purple = new(new Color(110,101,168), new Color(127,116,194), new Color(246,245,252));
        public static readonly ColorPalette Vomit = new(Color.Red, Color.Green, Color.Blue);

        #region Palette List
        private static readonly List<ColorPalette> palettes = new();
        public static IReadOnlyList<ColorPalette> AllPalettes => palettes.AsReadOnly();

        public static void AddPalette(ColorPalette palette) {
            palettes.Add(palette);
        }
        
        static Palettes() {
            IEnumerable<FieldInfo> fields = typeof(Palettes)
                .GetFields()
                .Where(f => f.FieldType == typeof(ColorPalette));
            
            foreach(FieldInfo field in fields) {
                ColorPalette? palette = (ColorPalette?)(field.GetValue(null));

                if(palette == null) {
                    throw new ArgumentException($"{field.Name} is somehow not a {nameof(ColorPalette)}");
                }
                
                palettes.Add(palette.Value);
            }
        }
        #endregion
    }
}