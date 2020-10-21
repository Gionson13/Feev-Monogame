using Feev.Input;
using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Feev.Graphics.UI
{
    public class Button
    {
        public Texture2D Normal;
        public Texture2D Hover;
        public Texture2D Pressed;
        
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public bool IsPressed = false;

        public event EventHandler OnClick;
        public event EventHandler OnReleased;

        private Texture2D _currentTexture;

        public Button(Texture2D normal, Texture2D hover, Texture2D pressed)
        {
            Normal = normal;
            Hover = hover;
            Pressed = pressed;
            _currentTexture = Normal;
        }

        public void Update()
        {
            Vector2 mousePosition = Mouse.Position;

            if (mousePosition.X > Position.X && mousePosition.X < Position.X + _currentTexture.Width * Scale.X &&
                mousePosition.Y > Position.Y && mousePosition.Y < Position.Y + _currentTexture.Height * Scale.Y)
            {
                _currentTexture = Hover;

                if (Mouse.IsButtonDown(MouseButtons.Left))
                {
                    if (!IsPressed)
                        OnClick?.Invoke(this, EventArgs.Empty);

                    _currentTexture = Pressed;
                    IsPressed = true;
                }
                else
                {
                    if (IsPressed)
                        OnReleased?.Invoke(this, EventArgs.Empty);

                    IsPressed = false;
                }
            }
            else
                _currentTexture = Normal;
        }

        #region Draw
        
        public void Draw()
        {
            Draw(Color.White);
        }

        public void Draw(Color color)
        {
            Batch.Draw(_currentTexture, Position, null, color, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
