using System;
using System.Numerics;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Engine.Engine.Input.Events;

namespace ConsoleDE.Base {
    /// <summary>
    /// A <c>DrawableButton</c> that takes in a delegate and a palette.
    /// </summary>
    public class ConsoleButton : DrawableButton {
        public ConsoleButton(Vector2 position, Font font, int textSize, string text, Vector2 buttonSize, EventHandler<MouseButtonEventArgs> onClick, float margin = 5) :
            base(position,
                font,
                textSize,
                text,
                ConsoleDEGame.Instance.CurrentPalette.PrimaryColor,
                ConsoleDEGame.Instance.CurrentPalette.TextColor,
                ConsoleDEGame.Instance.CurrentPalette.SecondaryColor,
                buttonSize,
                onClick,
                margin) {}
    }
}