namespace ConsoleDE.Services {
    public class WindowStateSuspensionService : IWindowSuspensionService {
        private readonly ConsoleDEGame game;
        public WindowStateSuspensionService(ConsoleDEGame game) {
            this.game = game;
        }

        public void Show() {
            this.game.WindowManager.Minimized = false;
            #if !DEBUG
            this.game.WindowManager.Fullscreen = true;
            #endif
        }
        public void Hide() {
            this.game.WindowManager.Minimized = true;
        }
    }
}