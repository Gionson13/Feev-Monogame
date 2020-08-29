using Feev.DesktopGL.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.DesktopGL.Graphics
{
    public class Sprite
    {
        public Texture2D Texture;
        public Transform2D Transform;
        public Vector2 Origin;
        public Rectangle? SourceRectangle;

        public Sprite(Texture2D texture, Transform2D transform, Vector2 origin)
        {
            Texture = texture;
            Transform = transform;
            Origin = origin;
            SourceRectangle = null;
        }

        public Sprite(Texture2D texture, Transform2D transform, Vector2 origin, Rectangle? sourceRectangle)
        {
            Texture = texture;
            Transform = transform;
            Origin = origin;
            SourceRectangle = sourceRectangle;
        }

        #region Draw

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        public void Draw()
        {
            Draw(Color.White);
        }

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="colorMask">A color mask.</param>
        public void Draw(Color colorMask)
        {
            Globals.spriteBatch.Draw(Texture, Transform.Position, SourceRectangle, colorMask, Transform.Rotation, Origin, Transform.Scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
