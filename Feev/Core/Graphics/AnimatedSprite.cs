using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.Graphics
{
    static class AnimatedSprite
    {
        #region Update

        /// <summary>
        /// Updated the animation.
        /// </summary>
        public static void Update(Entity entity)
        {
            ref AnimatedSpriteComponent animatedSprite = ref entity.GetComponent<AnimatedSpriteComponent>();

            if (!animatedSprite.Paused)
            {
                animatedSprite.elapsedTime += Time.DeltaTime;

                if (animatedSprite.elapsedTime >= animatedSprite.currentAnimation.FrameDuration)
                {
                    animatedSprite.frameIndex++;
                    animatedSprite.elapsedTime = 0f;
                    if (animatedSprite.frameIndex > animatedSprite.currentAnimation.Frames.Length - 1)
                        animatedSprite.frameIndex = 0;
                }
            }
        }

        #endregion

        #region Draw

        /// <summary>
        /// Draw the animation.
        /// </summary>
        public static void Draw(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            AnimatedSpriteComponent animatedSprite = entity.GetComponent<AnimatedSpriteComponent>();
            Batch.Draw(animatedSprite.currentAnimation.SpriteSheet, transform.Position, animatedSprite.currentAnimation.Frames[animatedSprite.frameIndex], Color.White, transform.Rotation, animatedSprite.Origin, transform.Scale, SpriteEffects.None, 0f);

        }

        #endregion
    }
}
