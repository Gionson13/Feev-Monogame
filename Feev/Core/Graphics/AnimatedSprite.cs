using Feev.Extension;
using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Feev.Graphics
{
    public class AnimatedSprite
    {
        private float _elapsedTime = 0f;
        private int frameIndex = 0;
        private bool paused = false;

        internal SpriteAnimation _currentAnimation;
        internal Dictionary<string, SpriteAnimation> _animations;

        public Transform2D Transform = new Transform2D(Vector2.Zero, 0f, Vector2.One);
        public Vector2 Origin = Vector2.Zero;

        public AnimatedSprite()
        {
            _animations = new Dictionary<string, SpriteAnimation>();
        }

        #region Update

        /// <summary>
        /// Updated the animation.
        /// </summary>
        /// <param name="gameTime">The elapsed time since the last call.</param>
        public void Update(GameTime gameTime)
        {
            Update(gameTime.GetElapsedSeconds());
        }

        /// <summary>
        /// Updated the animation.
        /// </summary>
        /// <param name="gameTime">The elapsed time since the last call.</param>
        public void Update(float gameTime)
        {
            if (!paused)
            {
                _elapsedTime += gameTime;

                if (_elapsedTime >= _currentAnimation.FrameDuration)
                {
                    frameIndex++;
                    _elapsedTime = 0f;
                    if (frameIndex > _currentAnimation.Frames.Length - 1)
                        frameIndex = 0;
                }
            }
        }

        #endregion

        #region Draw

        /// <summary>
        /// Draw the animation.
        /// </summary>
        public void Draw()
        {
            Draw(Color.White);
        }

        /// <summary>
        /// Draw the animation.
        /// </summary>
        /// <param name="colorMask">A color mask.</param>
        public void Draw(Color colorMask)
        {
            Batch.Draw(_currentAnimation.SpriteSheet, Transform.Position, _currentAnimation.Frames[frameIndex], colorMask, Transform.Rotation, Origin, Transform.Scale, SpriteEffects.None, 0f);
        }

        #endregion

        #region Logic

        /// <summary>
        /// Play the specified animation.
        /// </summary>
        /// <param name="animation">The animation to play.</param>
        /// <exception cref="KeyNotFoundException"/>
        public void Play(string animation)
        {
            if (_animations.ContainsKey(animation))
            {
                _currentAnimation = _animations[animation];
                _elapsedTime = 0f;
                frameIndex = 0;
                paused = false;
            }
            else
                throw new KeyNotFoundException($"{animation} does not exist");
        }

        /// <summary>
        /// Pause the animation.
        /// </summary>
        public void Pause()
        {
            paused = true;
        }

        /// <summary>
        /// Resume the animation.
        /// </summary>
        public void Resume()
        {
            paused = false;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            string result = "{";

            foreach (var item in _animations)
                result += $"{{Name: {item.Key}, Animation: {item.Value}}}, ";

            result = result.Substring(0, result.Length - 2);
            result += "}";
            return result;
        }

        #endregion
    }
}
