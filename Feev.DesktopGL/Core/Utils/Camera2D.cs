using Microsoft.Xna.Framework;
using System.Net.NetworkInformation;

namespace Feev.DesktopGL.Utils
{
    public class Camera2D
    {
        public Vector2 Position;
        public float Rotation;
        public float Zoom;
        public Vector2 Origin;
        public Rectangle Bounds
        {
            get
            {
                Vector2 viewPortCorner = ScreenToWorld(new Vector2(0, 0));
                Vector2 viewPortBottomCorner = ScreenToWorld(new Vector2(Globals.graphics.GraphicsDevice.Viewport.Width,
                    Globals.graphics.GraphicsDevice.Viewport.Height));

                return new Rectangle(viewPortCorner.ToPoint(), (viewPortBottomCorner - viewPortCorner).ToPoint());
            }
        }


        internal Matrix TranslationMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Position, 0)) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateScale(Zoom) *
                    Matrix.CreateTranslation(new Vector3(Origin, 0));
            }
        }

        public Camera2D(float rotation, float zoom)
        {
            Position = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight) / 2; ;
            Rotation = rotation;
            Zoom = zoom;
            Origin = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight) / 2;
        }

        public Camera2D(Vector2 position, float rotation, float zoom)
        {
            Position = position;
            Rotation = rotation;
            Zoom = zoom;
            Origin = new Vector2(Globals.graphics.PreferredBackBufferWidth, Globals.graphics.PreferredBackBufferHeight) / 2;
        }


        public Camera2D(Vector2 position, float rotation, float zoom, Vector2 origin)
        {
            Position = position;
            Rotation = rotation;
            Zoom = zoom;
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
