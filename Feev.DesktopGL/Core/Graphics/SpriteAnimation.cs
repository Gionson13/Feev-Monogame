using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.DesktopGL.Graphics
{
    struct SpriteAnimation
    {
        public Texture2D SpriteSheet;
        public Rectangle[] Frames;
        public float FrameDuration;

        public override string ToString()
        {
            string result = $"{{FrameDuration: {FrameDuration}, SpriteSheet: {SpriteSheet}, Frames: {{";

            foreach (Rectangle rectangle in Frames)
            {
                result += $"{{X: {rectangle.X}, Y: {rectangle.Y}, Width: {rectangle.Width}, Height: {rectangle.Height}}}, ";
            }

            result = result.Substring(0, result.Length - 2);
            result += "}}";
            return result;
        }
    }
}
