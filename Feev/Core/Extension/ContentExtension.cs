using Feev.Graphics;
using Feev.Utils;
using Feev.Utils.Json;
using Feev.Utils.Xml;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Feev.Extension
{
    public static class ContentExtension
    {
        private static Dictionary<string, AnimatedSpriteComponent> _animatedSpriteCache = new Dictionary<string, AnimatedSpriteComponent>();

        /// <summary>
        /// Load an animated sprite.
        /// </summary>
        /// <param name="content">The content manager.</param>
        /// <param name="filename">The name of the file.</param>
        /// <returns>An animated sprite.</returns>
        public static AnimatedSpriteComponent LoadAnimatedSprite(this ContentManager content, string filename)
        {
            string key = $"{content.RootDirectory}/{filename.Replace('\\', '/')}";
            if (_animatedSpriteCache.ContainsKey(key))
                return _animatedSpriteCache[key];

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(key + ".xml");

            var xmlAnimations = XmlParser.ParseSpriteAnimation(xmlDocument);

            AnimatedSpriteComponent result = new AnimatedSpriteComponent();
            result.animations = new Dictionary<string, SpriteAnimation>();

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
                result.animations.Add(xmlAnimation.Name, animation);
                result.currentAnimation = result.animations.Values.ElementAt(0);
            }

            return result;
        }

        /// <summary>
        /// Load a tilemap
        /// </summary>
        /// <param name="content">The content manager.</param>
        /// <param name="filename">The name of the file.</param>
        /// <returns>A tilemap.</returns>
        public static TilemapComponent LoadTilemap(this ContentManager content, string filename)
        {
            string json = File.ReadAllText($"{content.RootDirectory}/{filename}.json");
            JsonTilemapResult jsonTilemap = JsonParser.ParseTilemap(json);

            Texture2D spriteSheet = content.Load<Texture2D>(jsonTilemap.SpriteSheet);

            return new TilemapComponent(spriteSheet, jsonTilemap.Map, jsonTilemap.Tiles, jsonTilemap.Size);
        }
    }
}
