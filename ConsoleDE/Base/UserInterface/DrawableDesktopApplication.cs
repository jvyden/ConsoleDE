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
    public class DrawableDesktopApplication : CompositeDrawable {
        private readonly DesktopApplication application;
        private readonly DrawableBorderedBox box;
        private readonly TexturedDrawable? icon = null;
        private readonly ConsoleText text;
        
        public DrawableDesktopApplication(Vector2 position, DesktopApplication application) {
            this.application = application;
            Texture? iconTexture = this.application.Icon;

            this.Position = position;

            this.box = new DrawableBorderedBox(Vector2.Zero, new Vector2(220, 220));
            this.box.ToolTip = application.DesktopFile.Comment;
            #if DEBUG
            this.box.ToolTip += $" ({nameof(DesktopFile.Exec)}: {application.DesktopFile.Exec})";
            #endif
            this.Drawables.Add(box);
            
            if(iconTexture != null) {
                icon = new TexturedDrawable(iconTexture, Vector2.Zero);
                this.icon.OriginType = OriginType.Center;

                Vector2 targetSize = new(110, 110);
                icon.Scale = targetSize / icon.Size;

                this.Drawables.Add(icon);
            }

            this.text = new ConsoleText(Vector2.Zero, Fonts.Default, application.DesktopFile.Name, 24);
            this.text.OriginType = OriginType.Center;
            this.Drawables.Add(this.text);
            
            this.Drawables.Add(this.box.OutlineDrawable);

            foreach(Drawable drawable in this.Drawables) {
                drawable.OnClick += this.onClick;
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
            FurballGame.TimeStepMethods.Add(method = new FixedTimeStepMethod(100, showAfterExecutionComplete));
        }

        public override Vector2 Size => this.box.Size;

        public override void Update(double time) {
            base.Update(time);

            if(this.icon != null) {
                this.icon.Position.X = this.box.Size.X / 2;
                this.icon.Position.Y = (this.box.Size.Y / 2) - 15;
            }

            this.text.Position.X = this.box.Size.X / 2;
            this.text.Position.Y = this.box.Size.Y - 30;
        }
    }
}