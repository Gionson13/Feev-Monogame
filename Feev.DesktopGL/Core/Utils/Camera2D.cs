﻿using Microsoft.Xna.Framework;

namespace Feev.DesktopGL.Utils
{
    public class Camera2D
    {
        public Vector2 Position;
        public float Rotation;
        public float Zoom;
        public Vector2 Origin;

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

    }
}