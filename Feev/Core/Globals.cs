using Feev.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Feev
{
    public static class Globals
    {
        internal static List<PointLight> pointLights;
        internal static int maxLights = 20;

        internal static SpriteBatch spriteBatch;

        public static GraphicsDeviceManager Graphics;
        public static ContentManager Content;
        public static GraphicsDevice GraphicsDevice;
    }
}
