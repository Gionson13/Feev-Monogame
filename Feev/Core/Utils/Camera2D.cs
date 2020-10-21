using Microsoft.Xna.Framework;

namespace Feev.Utils
{
    public class Camera2D
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
        public Vector2 Origin;
        public bool PixelPerfect = false;


        public Rectangle Bounds
        {
            get
            {
                Vector2 viewPortCorner = ScreenToWorld(new Vector2(0, 0));
                Vector2 viewPortBottomCorner = ScreenToWorld(new Vector2(Globals.Graphics.GraphicsDevice.Viewport.Width,
                    Globals.Graphics.GraphicsDevice.Viewport.Height));

                return new Rectangle(viewPortCorner.ToPoint(), (viewPortBottomCorner - viewPortCorner).ToPoint());
            }
        }


        internal Matrix TranslationMatrix
        {
            get
            {
                if (PixelPerfect)
                    return Matrix.CreateTranslation(new Vector3((int)-Position.X, (int)-Position.Y, 0)) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateScale(new Vector3(Scale, 1)) *
                        Matrix.CreateTranslation(new Vector3(Origin, 0));
                else
                    return Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                        Matrix.CreateRotationZ(Rotation) *
                        Matrix.CreateScale(new Vector3(Scale, 1)) *
                        Matrix.CreateTranslation(new Vector3(Origin, 0));
            }
        }

        public Camera2D(float rotation, float scale)
        {
            Position = new Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight) / 2;
            Rotation = rotation;
            Scale = new Vector2(scale, 1);
            Origin = new Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight) / 2;
        }

        public Camera2D(Vector2 position, float rotation, float scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = new Vector2(scale, 1);
            Origin = new Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight) / 2;
        }


        public Camera2D(Vector2 position, float rotation, float scale, Vector2 origin)
        {
            Position = position;
            Rotation = rotation;
            Scale = new Vector2(scale, 1);
            Origin = origin;
        }

        public Vector2 ScreenToWorld(Vector2 pixel)
        {
            return Vector2.Transform(pixel, Matrix.Invert(TranslationMatrix));
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, TranslationMatrix);
        }

    }
}
