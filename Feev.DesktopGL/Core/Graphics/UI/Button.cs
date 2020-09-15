using Feev.DesktopGL.Input;
using Feev.DesktopGL.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Feev.DesktopGL.Graphics.UI
{
    public class Button
    {
        public Texture2D Normal;
        public Texture2D Hover;
        public Texture2D Pressed;
        public Transform2D Transform;
        public bool IsPressed = false;

        public event EventHandler OnClick;
        public event EventHandler OnReleased;

        private Texture2D _currentTexture;

        public Button(Vector2 position, Texture2D normal, Texture2D hover, Texture2D pressed)
        {
            Transform = new Transform2D(position, 0f, Vector2.One);
            Normal = normal;
            Hover = hover;
            Pressed = pressed;
            _currentTexture = Normal;
        }
        
        public Button(Transform2D transform, Texture2D normal, Texture2D hover, Texture2D pressed)
        {
            Transform = transform;
            Normal = normal;
            Hover = hover;
            Pressed = pressed;
            _currentTexture = Normal;
        }

        public void Update()
        {
            Vector2 mousePosition = Mouse.Position;

            if (mousePosition.X > Transform.Position.X && mousePosition.X < Transform.Position.X + _currentTexture.Width &&
                mousePosition.Y > Transform.Position.Y && mousePosition.Y < Transform.Position.Y + _currentTexture.Height)
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
            Batch.Draw(_currentTexture, Transform.Position, null, color, Transform.Rotation, Vector2.Zero, Transform.Scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
