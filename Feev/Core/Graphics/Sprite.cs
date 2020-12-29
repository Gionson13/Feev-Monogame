using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.Graphics
{
    static class Sprite
    {
        
        #region Draw

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        public static void Draw(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            SpriteComponent sprite = entity.GetComponent<SpriteComponent>();
            Batch.Draw(sprite.Texture, transform.Position, sprite.SourceRectangle, Color.White, transform.Rotation, sprite.Origin, transform.Scale, SpriteEffects.None, 0f);
        }

        #endregion
    }
}
