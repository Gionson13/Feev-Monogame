using Feev.Input;
using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.Graphics.UI
{
    static class Button
    {
        public static void Update(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            ref ButtonComponent button = ref entity.GetComponent<ButtonComponent>();

            Vector2 mousePosition = Mouse.Position;

            if (mousePosition.X > transform.Position.X && mousePosition.X < transform.Position.X + button.currentTexture.Width * transform.Scale.X &&
                mousePosition.Y > transform.Position.Y && mousePosition.Y < transform.Position.Y + button.currentTexture.Height * transform.Scale.Y)
            {
                button.currentTexture = button.Hover;

                if (Mouse.IsButtonDown(MouseButtons.Left))
                {
                    button.currentTexture = button.Pressed;
                    button.IsPressed = true;
                }
                else
                {
                    if (button.IsPressed)

                        button.IsPressed = false;
                }
            }
            else
                button.currentTexture = button.Normal;
        }

        #region Draw
        
        public static void Draw(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            ButtonComponent button = entity.GetComponent<ButtonComponent>();

            Batch.Draw(button.currentTexture, transform.Position, null, Color.White, transform.Rotation, Vector2.Zero, transform.Scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
