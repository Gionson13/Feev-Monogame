using Microsoft.Xna.Framework;

namespace Feev.DesktopGL.Extension
{
    public static class GameTimeExtension
    {
        /// <summary>
        /// Get the elapsed second since the last update call.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>The elapsed seconds</returns>
        public static float GetElapsedSeconds(this GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
