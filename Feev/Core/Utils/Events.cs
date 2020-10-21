using Microsoft.Xna.Framework;

namespace Feev.Utils
{
    public delegate void TransformEventHandler(object source, TransformEventArgs e);
    public class TransformEventArgs
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;

        public TransformEventArgs(Vector2 position, float rotation, Vector2 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}
