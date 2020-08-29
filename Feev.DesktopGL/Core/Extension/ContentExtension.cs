using Feev.DesktopGL.Graphics;
using Feev.DesktopGL.Utils.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Feev.DesktopGL.Extension
{
    public static class ContentExtension
    {
        private static Dictionary<string, AnimatedSprite> _animatedSpriteCache = new Dictionary<string, AnimatedSprite>();

        /// <summary>
        /// Load an animated sprite.
        /// </summary>
        /// <param name="content">The content manager.</param>
        /// <param name="filename">The name of the file.</param>
        /// <returns>An animated sprite.</returns>
        public static AnimatedSprite LoadAnimatedSprite(this ContentManager content, string filename)
        {
            string key = $"{content.RootDirectory}/{filename.Replace('\\', '/')}";
            if (_animatedSpriteCache.ContainsKey(key))
                return _animatedSpriteCache[key];

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(key + ".xml");

            var xmlAnimations = XmlParser.ParseSpriteAnimation(xmlDocument);

            AnimatedSprite result = new AnimatedSprite();

            foreach (var xmlAnimation in xmlAnimations)
            {
                var spriteSheet = content.Load<Texture2D>(xmlAnimation.Filename);
                Rectangle[] frames;

                if (xmlAnimation.Frames != null)
                    frames = xmlAnimation.Frames;
                else
                {
                    frames = new Rectangle[(int)xmlAnimation.NumberOfFrames];
                    int frameWidth = spriteSheet.Width / (int)xmlAnimation.NumberOfFrames;
                    for (int i = 0; i < frames.Length; i++)
                        frames[i] = new Rectangle(i * frameWidth, 0, frameWidth, spriteSheet.Height);
                }

                var animation = new SpriteAnimation
                {
                    SpriteSheet = spriteSheet,
                    FrameDuration = xmlAnimation.FrameDuration,
                    Frames = frames
                };
                result._animations.Add(xmlAnimation.Name, animation);
                result._currentAnimation = result._animations.Values.ElementAt(0);
            }

            return result;
        }

        /// <summary>
        /// Load an animated sprite.
        /// </summary>
        /// <param name="content">The content manager.</param>
        /// <param name="filename">The name of the file.</param>
        /// <param name="position">The position of the animated sprite.</param>
        /// <returns>An animated sprite.</returns>
        public static AnimatedSprite LoadAnimatedSprite(this ContentManager content, string filename, Vector2 position)
        {
            var result = LoadAnimatedSprite(content, filename);
            result.Transform.Position = position;
            return result;
        }
    }
}
