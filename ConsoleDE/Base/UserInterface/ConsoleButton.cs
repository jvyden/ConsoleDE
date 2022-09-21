using System;
using System.Numerics;
using ConsoleDE.Base.Styling;
using Furball.Engine.Engine.Graphics.Drawables.UiElements;
using Furball.Engine.Engine.Input.Events;
using Furball.Vixie.Backends.Shared;

namespace ConsoleDE.Base.UserInterface {
    /// <summary>
    /// A <c>DrawableButton</c> that takes in a delegate and a palette.
    /// </summary>
    public class ConsoleButton : DrawableButton, ISupportsPalettes {
        public ConsoleButton(Vector2 position, Font font, int textSize, string text, Vector2 buttonSize, EventHandler<MouseButtonEventArgs> onClick, float margin = 5) :
            base(position,
                font,
                textSize,
                text,
                Color.Black,
                Color.Black,
                Color.Black,
                buttonSize,
                onClick,
                margin) {}
        
        public void UpdateColors(ColorPalette palette) {
            this.ButtonColor = palette.PrimaryColor;
            this.TextColor = palette.TextColor;
            this.OutlineColor = palette.SecondaryColor;
        }
    }
}