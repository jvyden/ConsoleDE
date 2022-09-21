using System;
using System.Diagnostics.Tracing;
using Furball.Vixie;
using Furball.Vixie.Backends.Shared.Backends;

namespace ConsoleDE.Services {
    public class WindowBackendSuspensionService : IWindowSuspensionService {
        private readonly ConsoleDEGame game;
        
        internal WindowBackendSuspensionService(ConsoleDEGame game) {
            this.game = game;
        }

        private Backend? currentBackend;
        private EventLoop? currentEventLoop;
        private bool hidden = false;

        public void Show() {
            if(!this.hidden) return;

            if(this.currentBackend == null || this.currentEventLoop == null) {
                throw new InvalidOperationException(
                    "The old state information was not saved.\n" +
                    "The window cannot be shown again."
                );
            }

            game.WindowManager.Backend = currentBackend.Value;
            game.RecreateWindow(currentEventLoop);

            currentBackend = null;
            currentEventLoop = null;
            
            hidden = false;
        }
        
        public void Hide() {
            if(this.hidden) return;

            currentBackend = game.WindowManager.Backend;
            currentEventLoop = game.EventLoop;

            game.WindowManager.Backend = Backend.Dummy;
            game.RecreateWindow(new HeadlessEventLoop());

            hidden = true;
        }
    }
}