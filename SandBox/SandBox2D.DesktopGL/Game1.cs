using Feev.DesktopGL;
using Feev.DesktopGL.Debug;
using Feev.DesktopGL.Extension;
using Feev.DesktopGL.Graphics;
using Feev.DesktopGL.Input;
using Feev.DesktopGL.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace SandBox2D.DesktopGL
{
    public class Game1 : GameScreen
    {
        SpriteFont font;
        Color clearColor = Color.White;
        AnimatedSprite animatedSprite;
        AnimatedSprite animatedSprite2;
        Sprite sprite;

        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void OnInitialize()
        {
        }

        protected override void OnLoad()
        {
            font = Globals.content.Load<SpriteFont>("Font");
            var spriteSheet = Globals.content.Load<Texture2D>("scarfy");
            sprite = new Sprite(spriteSheet, new Transform2D(new Vector2(Globals.graphics.PreferredBackBufferWidth / 2, 200), 0f, Vector2.One), new Vector2(spriteSheet.Width / 2, 0));

            animatedSprite = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 - spriteSheet.Width / 6, 0));
            animatedSprite.Origin = new Vector2(spriteSheet.Width / 6 / 2, 0);
            animatedSprite2 = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 + spriteSheet.Width / 6, 0));
            animatedSprite2.Origin = new Vector2(spriteSheet.Width / 6 / 2, 0);
            animatedSprite2.Play("not_idle");

            Log.Info(animatedSprite);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || FeevKeyboard.IsKeyDown(Keys.Escape))
                Exit();

            if (FeevMouse.IsButtonDown(MouseButtons.XButton1))
            {
                Random random = new Random();
                float r = random.NextFloat();
                float g = random.NextFloat();
                float b = random.NextFloat();
                clearColor = new Color(r, g, b);
            }

            animatedSprite.Update(gameTime);
            animatedSprite2.Update(gameTime);
        }

        protected override void OnDraw()
        {
            GraphicsDevice.Clear(clearColor);

            Globals.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            animatedSprite.Draw();
            animatedSprite2.Draw();
            sprite.Draw();
            Globals.spriteBatch.End();
        }
    }
}
