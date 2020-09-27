using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Feev.Graphics
{
    public class PointLight : IDisposable
    {
        public Vector2 Position;
        public Color Color;
        public float Radius;

        private bool _disposed = false;

        private static Effect pointLightEffect;

        public PointLight(Vector2 position, float radius, Color color)
        {

            if (pointLightEffect == null)
            {
#if OPENGL
                byte[] pointLightCode = File.ReadAllBytes("Resources/OpenGL/pointLightShader.mgfxo");
                pointLightEffect = new Effect(Globals.GraphicsDevice, pointLightCode);
#else
                throw new Exception("Invalid graphics library.");
#endif
            }

            Position = position;
            Color = color;
            Radius = radius;

            if (Globals.pointLights == null)
                Globals.pointLights = new List<PointLight>();

            Globals.pointLights.Add(this);
        }

        #region Static methods

        /// <summary>
        /// Draws the light on top of a renderTarget. (Draws the result on screen).
        /// </summary>
        /// <param name="renderTarget">The render target to draw on.</param>
        public static void Draw(RenderTarget2D renderTarget)
        {
            InitializeDraw(out Vector2[] positions, out Vector4[] colors, out float[] radiuses);

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = Globals.pointLights[i].Position;
                colors[i] = Globals.pointLights[i].Color.ToVector4();
                radiuses[i] = Globals.pointLights[i].Radius;
            }

            Draw(renderTarget, colors, positions, radiuses);
        }

        /// <summary>
        /// Draws the light on top of a renderTarget. (Draws the result on screen).
        /// </summary>
        /// <param name="renderTarget">The render target to draw on.</param>
        /// <param name="camera">A camera.</param>
        public static void Draw(RenderTarget2D renderTarget, Camera2D camera)
        {
            InitializeDraw(out Vector2[] positions, out Vector4[] colors, out float[] radiuses);

            for (int i = 0; i < positions.Length; i++)
            {
                positions[i] = camera.WorldToScreen(Globals.pointLights[i].Position);
                colors[i] = Globals.pointLights[i].Color.ToVector4();
                radiuses[i] = Globals.pointLights[i].Radius * camera.Zoom;
            }

            Draw(renderTarget, colors, positions, radiuses);
        }

        private static void Draw(RenderTarget2D renderTarget, Vector4[] colors, Vector2[] positions, float[] radiuses)
        {

            pointLightEffect.Parameters["lightCount"].SetValue(positions.Length);
            pointLightEffect.Parameters["positions"].SetValue(positions);
            pointLightEffect.Parameters["radiuses"].SetValue(radiuses);
            pointLightEffect.Parameters["lightColors"].SetValue(colors);
            pointLightEffect.Parameters["screenSize"].SetValue(Globals.Graphics.GraphicsDevice.Viewport.Bounds.Size.ToVector2());
            Batch.ApplyEffect(pointLightEffect);

            Batch.Begin();
            Batch.Draw(renderTarget, Vector2.Zero, Color.White);
            Batch.End();

            Batch.ApplyEffect(null);
        }

        private static void InitializeDraw(out Vector2[] positions, out Vector4[] colors, out float[] radiuses)
        {
            if (Globals.pointLights.Count > Globals.maxLights)
            {
                colors = new Vector4[Globals.maxLights];
                positions = new Vector2[Globals.maxLights];
                radiuses = new float[Globals.maxLights];
            }
            else
            {
                colors = new Vector4[Globals.pointLights.Count];
                positions = new Vector2[Globals.pointLights.Count];
                radiuses = new float[Globals.pointLights.Count];
            }
        }

        #endregion

        public void Dispose()
        {
            if (!_disposed)
            {
                Globals.pointLights.Remove(this);
                _disposed = true;
            }
        }
    }
}
