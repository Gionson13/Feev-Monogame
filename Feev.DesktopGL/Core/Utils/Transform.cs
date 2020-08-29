using Microsoft.Xna.Framework;

namespace Feev.DesktopGL.Utils
{
    public struct Transform2D
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public Transform2D(Vector2 position, float rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}
