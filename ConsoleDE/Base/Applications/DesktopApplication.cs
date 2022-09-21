using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Furball.Engine.Engine.Graphics;
using Furball.Vixie;

namespace ConsoleDE.Base.Applications {
    public class DesktopApplication {
        public DesktopApplication(DesktopFile desktopFile) {
            this.DesktopFile = desktopFile;

            List<string> args = this.DesktopFile.Exec
                .Split(" ")
                .ToList()
                .Where(arg => arg.Length != 2 || !arg.StartsWith('%'))
                .ToList();

            this.ExecutablePath = args[0];
            this.Arguments = string.Join(" ", args.Skip(1));
        }
        public DesktopFile DesktopFile { get; init; }

        public string ExecutablePath { get; }
        public string Arguments { get; }

        // please keep in order from largest to smallest!!!
        private static readonly string[] hicolorSizes = {
//            "1024x1024",
//            "512x512",
//            "480x480",
//            "384x384",
//            "310x310",
//            "256x256@2x",
            "256x256",
            "192x192",
            "150x150",
            "128x128",
            "96x96",
            "72x72",
            "64x64",
            "48x48",
            "48x48@2x",
            "44x44",
            "36x36",
            "32x32@2x",
            "32x32",
            "28x28",
            "24x24@2x",
            "24x24",
            "22x22",
            "16x16@2x",
            "16x16",
        };

        private string? _iconPath;
        private Texture? icon;

        public Texture? Icon {
            get {
                if(icon != null) return this.icon;

                string? path = iconPath;
                if(path == null) return null;

                return Path.GetExtension(path) switch {
                    ".png" => ContentManager.LoadTextureFromFileCached(path, ContentSource.External),
                    ".svg" => IconHelper.LoadSVG(path),
                    ".xpm" => IconHelper.LoadPixmap(path),
                    _ => null,
                };
            }
        }
        
        private string? iconPath {
            get {
                if(this._iconPath != null) return this._iconPath;

                string path;
                
                foreach(string size in hicolorSizes) {
                    path = $"/usr/share/icons/hicolor/{size}/apps/{DesktopFile.IconName}.png";
                    if(File.Exists(path)) {
                        this._iconPath = path;
                        return path;
                    }
                }

                path = $"/usr/share/pixmaps/{DesktopFile.IconName}.svg";
                if(File.Exists(path)) {
                    this._iconPath = path;
                    return path;
                }
                
                return null;
            }
        }

        public Process? Execute() {
            ProcessStartInfo psi = new() {
                WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                FileName = ExecutablePath,
                Arguments = Arguments,
            };

            return Process.Start(psi);
        }
    }
}