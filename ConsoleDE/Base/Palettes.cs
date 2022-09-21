using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base {
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class Palettes {
        public static readonly ColorPalette Light = new() {
            PrimaryColor = Color.LightGray,
            SecondaryColor = Color.DimGray,
            TextColor = Color.Black,
            BackgroundColor = Color.White,
        };
        
        public static readonly ColorPalette Steel = new() {
            PrimaryColor = new Color(10, 9, 12),
            SecondaryColor = new Color(52, 49, 63),
            TextColor = Color.White,
            BackgroundColor = new Color(27, 25, 33),
        };
        
        public static readonly ColorPalette Purple = new() {
            PrimaryColor = new Color(112, 99, 198),
            SecondaryColor = new Color(127, 116, 194),
            TextColor = new Color(246, 245, 252),
            BackgroundColor = new Color(110, 101, 168),
        };

        public static readonly ColorPalette Hack = new() {
            PrimaryColor = new Color(21, 178, 21),
//            SecondaryColor = new Color(96, 96, 96),
            SecondaryColor = new Color(33, 237, 33),
            TextColor = new Color(33, 237, 33),
            BackgroundColor = Color.Black,
        };

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
                
                palettes.Add(palette);
            }
        }
        #endregion
    }
}