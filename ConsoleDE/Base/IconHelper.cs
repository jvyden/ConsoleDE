using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Furball.Engine.Engine.Graphics;
using Furball.Vixie;
using Svg;

namespace ConsoleDE.Base {
    public static class IconHelper {
        public static Texture? LoadSVG(string path) {
            SvgDocument? svg = SvgDocument.Open<SvgDocument>(path, null);
            Bitmap? bitmap = svg?.Draw(256, 256);
            if(bitmap == null) return null;

            using MemoryStream ms = new();
            bitmap.Save(ms, ImageFormat.Png);
            ms.Position = 0;
            
            Texture texture = Texture.CreateTextureFromStream(ms);
            texture.Name = path;
            return texture;
        }

        public static Texture? LoadPixmap(string path) {
            throw new NotImplementedException();
        }
    }
}