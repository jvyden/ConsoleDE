using System.Numerics;
using System.Threading;
using ConsoleDE.Base;
using Furball.Engine;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Engine.Engine.Input.Events;
using Furball.Vixie;
using Furball.Vixie.Backends.Shared.Backends;
using Screen = Furball.Engine.Engine.Screen;
using Task = System.Threading.Tasks.Task;

namespace ConsoleDE.Screens {
    public class MainScreen : Screen {
        private DrawableButton hideButton;
        
        public override void Initialize() {
            this.Manager.Add(this.hideButton = new DrawableButton(new Vector2(20, 20),
                Fonts.DefaultFont,
                24,
                "Hide for 5 seconds",
                Palettes.Light.MainColor,
                Palettes.Light.TextColor,
                Palettes.Light.SecondaryColor,
                new Vector2(250, 50)));
            
            this.hideButton.OnClick += hideButtonOnOnClick;
        }
        private void hideButtonOnOnClick(object? sender, MouseButtonEventArgs e) {
            Backend currentBackend = FurballGame.Instance.WindowManager.Backend;
            EventLoop currentEventLoop = FurballGame.Instance.EventLoop;

            FurballGame.Instance.WindowManager.Backend = Backend.Dummy;
            FurballGame.Instance.RecreateWindow(new HeadlessEventLoop());

            FurballGame.GameTimeScheduler.ScheduleMethod(delegate {
                FurballGame.Instance.WindowManager.Backend = currentBackend;
                FurballGame.Instance.RecreateWindow(currentEventLoop);
            }, FurballGame.Time + 5000d);
        }
    }
}