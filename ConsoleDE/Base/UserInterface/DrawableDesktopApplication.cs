using System;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using ConsoleDE.Base.Applications;
using ConsoleDE.Base.Styling;
using Furball.Engine;
using Furball.Engine.Engine;
using Furball.Engine.Engine.Graphics;
using Furball.Engine.Engine.Graphics.Drawables;
using Furball.Engine.Engine.Input.Events;
using Furball.Vixie;

namespace ConsoleDE.Base.UserInterface {
    public class DrawableDesktopApplication : CompositeDrawable, ISupportsPalettes {
        private DesktopApplication application;
        
        public DrawableDesktopApplication(Vector2 position, DesktopApplication application) {
            this.application = application;
            string? iconPath = this.application.IconPath;

            TexturedDrawable? icon = null;
            if(iconPath != null) {
                Texture iconTexture = ContentManager.LoadTextureFromFileCached(this.application.IconPath, ContentSource.External);
                icon = new(iconTexture, position);

                Vector2 targetSize = new(96, 96);
                icon.Scale = targetSize / icon.Size;

                this.Drawables.Add(icon);
            }

            if(icon != null) {
                icon.OnClick += this.onClick;
            }
            
            this.OnClick += this.onClick;
        }

        private bool executing = false;
        private void onClick(object? sender, MouseButtonEventArgs e) {
            if(this.executing) return;
            
            Process? process = this.application.Execute();
            if(process == null) return;

            ConsoleDEGame.Instance.WindowSuspensionService.Hide();

            this.executing = true;
            Task.Factory.StartNew(() => {
                process.WaitForExit();
                this.executing = false;
            });

            FixedTimeStepMethod method = null;
            void showAfterExecutionComplete() {
                if(this.executing) return;
                
                ConsoleDEGame.Instance.WindowSuspensionService.Show();
                FurballGame.TimeStepMethods.Remove(method);
            }

            // ReSharper disable once RedundantAssignment
            FurballGame.TimeStepMethods.Add(method = new FixedTimeStepMethod(1000, showAfterExecutionComplete));
        }

        public void UpdateColors(ColorPalette palette) {
            
        }
    }
}