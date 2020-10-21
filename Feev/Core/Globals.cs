using Feev.Graphics;
using Feev.Utils;
using Leopotam.Ecs;
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
        internal static List<Entity> entities = new List<Entity>();
        internal static Camera2D mainCamera = null;
        internal static SpriteBatch spriteBatch;
        internal static bool shouldExit = false;

        public static EcsWorld ecsWorld;

        public static GraphicsDeviceManager Graphics;
        public static ContentManager Content;
        public static GraphicsDevice GraphicsDevice;

        public static Color ClearColor = Color.Black;
    }
}
