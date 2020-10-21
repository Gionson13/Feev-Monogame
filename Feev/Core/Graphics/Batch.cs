using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace Feev.Graphics
{
    public static class Batch
    {
        #region Begin Options

        private static SpriteSortMode _sortMode;
        private static BlendState _blendState;
        private static SamplerState _samplerState;
        private static DepthStencilState _depthStencilState;
        private static RasterizerState _rasterizerState;
        private static Effect _effect;
        private static Matrix? _translationMatrix;

        public static SpriteSortMode SortMode
        {
            get { return _sortMode; }
            set
            {
                _sortMode = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static BlendState BlendState
        {
            get { return _blendState; }
            set
            {
                _blendState = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static SamplerState SamplerState
        {
            get { return _samplerState; }
            set
            {
                _samplerState = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static DepthStencilState DepthStencilState
        {
            get { return _depthStencilState; }
            set
            {
                _depthStencilState = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static RasterizerState RasterizerState
        {
            get { return _rasterizerState; }
            set
            {
                _rasterizerState = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static Effect Effect
        {
            get { return _effect; }
            set
            {
                _effect = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }
        public static Matrix? TranslationMatrix
        {
            get { return _translationMatrix; }
            set
            {
                _translationMatrix = value;
                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, BlendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }

        #endregion

        private static bool _hasBegun = false;

        /// <summary>
        /// Begins a new sprite and text batch with the specified render state.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown if Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode,Microsoft.Xna.Framework.Graphics.BlendState,Microsoft.Xna.Framework.Graphics.SamplerState,Microsoft.Xna.Framework.Graphics.DepthStencilState,Microsoft.Xna.Framework.Graphics.RasterizerState,Microsoft.Xna.Framework.Graphics.Effect,System.Nullable{Microsoft.Xna.Framework.Matrix})
        /// is called next time without previous Microsoft.Xna.Framework.Graphics.SpriteBatch.End.</exception>
        /// <remarks>This method uses optional parameters.</remarks>
        public static void Begin()
        {
            _hasBegun = true;
            Globals.spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
        }


        /// <summary>
        /// Begins a new sprite and text batch with the specified render state.
        /// </summary>
        /// <param name="renderTarget">The render target.</param>
        /// <exception cref="System.InvalidOperationException">Thrown if Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode,Microsoft.Xna.Framework.Graphics.BlendState,Microsoft.Xna.Framework.Graphics.SamplerState,Microsoft.Xna.Framework.Graphics.DepthStencilState,Microsoft.Xna.Framework.Graphics.RasterizerState,Microsoft.Xna.Framework.Graphics.Effect,System.Nullable{Microsoft.Xna.Framework.Matrix})
        /// is called next time without previous Microsoft.Xna.Framework.Graphics.SpriteBatch.End.</exception>
        /// <remarks>This method uses optional parameters.</remarks>
        public static void Begin(RenderTarget2D renderTarget)
        {
            _hasBegun = true;
            Globals.spriteBatch.GraphicsDevice.SetRenderTarget(renderTarget);
            Globals.spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
        }

        /// <summary>
        /// Begin drawing relative to a camera.
        /// </summary>
        /// <param name="camera">The camera.</param>
        public static void BeginMode2D(Camera2D camera)
        {
            Globals.spriteBatch.End();

            _translationMatrix = camera.TranslationMatrix;

            Globals.spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="destinationRectangle">The drawing bounds on screen.</param>
        /// <param name="color">A color mask.</param>
        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            Draw(texture, destinationRectangle, null, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="position">The drawing location on screen.param>
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        public static void Draw(Texture2D texture, Vector2 position, Color color)
        {
            Draw(texture, position, null, color, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="position">The drawing location on screen.param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full 
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        public static void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            Draw(texture, position, sourceRectangle, color, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="destinationRectangle">The drawing bounds on screen.</param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full 
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            Draw(texture, destinationRectangle, sourceRectangle, color, 0f, Vector2.Zero, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full 
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this sprite.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this sprite.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this sprite.</param>
        public static void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            Draw(texture, position, sourceRectangle, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full 
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this sprite.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this sprite.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this sprite.</param>
        public static void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Globals.spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }

        /// <summary>
        /// Submit a sprite for drawing in the current batch.
        /// </summary>
        /// <param name="texture">A texture.</param>
        /// <param name="destinationRectangle">The drawing bounds on screen.</param>
        /// <param name="sourceRectangle">An optional region on the texture which will be rendered. If null - draws full 
        /// texture.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this sprite.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this sprite.</param>
        public static void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            Globals.spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this string.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this string.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this string.</param>
        public static void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Globals.spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        public static void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            DrawString(spriteFont, text, position, color, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this string.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this string.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this string.</param>
        public static void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawString(spriteFont, text, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this string.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this string.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this string.</param>
        public static void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Globals.spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        public static void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            DrawString(spriteFont, text, position, color, 0f, Vector2.Zero, Vector2.One, SpriteEffects.None, 0f);
        }

        /// <summary>
        /// Submit a text string of sprites for drawing in the current batch.
        /// </summary>
        /// <param name="spriteFont">A font.</param>
        /// <param name="text">The text which will be drawn.param>
        /// <param name="position">The drawing location on screen.</param>
        /// <param name="color">A color mask.</param>
        /// <param name="rotation">A rotation of this string.</param>
        /// <param name="origin">Center of the rotation. 0,0 by default.</param>
        /// <param name="scale">A scaling of this string.</param>
        /// <param name="effects">Modificators for drawing. Can be combined.</param>
        /// <param name="layerDepth">A depth of the layer of this string.</param>
        public static void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            DrawString(spriteFont, text, position, color, rotation, origin, new Vector2(scale), effects, layerDepth);
        }

        /// <summary>
        /// Apply an <see cref="Effect"/> to the batch.
        /// </summary>
        /// <param name="effect">The effect to apply.</param>
        public static void ApplyEffect(Effect effect)
        {
            if (effect != _effect)
            {
                _effect = effect;

                if (_hasBegun)
                {
                    Globals.spriteBatch.End();
                    Globals.spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect, _translationMatrix);
                }
            }
        }

        /// <summary>
        /// Flushes all batched text and sprites to the screen.
        /// </summary>
        /// <remarks>This command should be called after Microsoft.Xna.Framework.Graphics.SpriteBatch.Begin(Microsoft.Xna.Framework.Graphics.SpriteSortMode,Microsoft.Xna.Framework.Graphics.BlendState,Microsoft.Xna.Framework.Graphics.SamplerState,Microsoft.Xna.Framework.Graphics.DepthStencilState,Microsoft.Xna.Framework.Graphics.RasterizerState,Microsoft.Xna.Framework.Graphics.Effect,System.Nullable{Microsoft.Xna.Framework.Matrix})
        /// and drawing commands.</remarks>
        public static void End()
        {
            Globals.spriteBatch.End();
            _hasBegun = false;
            _effect = null;

            Globals.spriteBatch.GraphicsDevice.SetRenderTarget(null);

        }

        /// <summary>
        /// End drawing relative to the camera.
        /// </summary>
        public static void EndMode2D()
        {
            _translationMatrix = null;
            Globals.spriteBatch.End();
            Globals.spriteBatch.Begin(_sortMode, _blendState, _samplerState, _depthStencilState, _rasterizerState, _effect);
        }
    }
}
