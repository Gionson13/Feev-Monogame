using Feev.DesktopGL;
using Feev.DesktopGL.Debug;
using Feev.DesktopGL.Extension;
using Feev.DesktopGL.Graphics;
using Feev.DesktopGL.Input;
using Feev.DesktopGL.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SandBox2D.DesktopGL
{
    public class Game1 : GameScreen
    {
        SpriteFont font;
        Color clearColor = Color.Black;
        AnimatedSprite animatedSprite;
        AnimatedSprite animatedSprite2;
        Sprite sprite;
        Camera2D camera;
        float speed = 400;

        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void OnInitialize()
        {
            camera = new Camera2D(0f, 1f);
        }

        protected override void OnLoad()
        {
            font = Globals.content.Load<SpriteFont>("Font");
            var spriteSheet = Globals.content.Load<Texture2D>("scarfy");
            sprite = new Sprite(spriteSheet, new Transform2D(new Vector2(Globals.graphics.PreferredBackBufferWidth / 2, 200), 0f, Vector2.One), new Vector2(spriteSheet.Width / 2, 0));

            animatedSprite = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 - spriteSheet.Width / 6, 0));
            animatedSprite.Origin = new Vector2(spriteSheet.Width / 6 / 2, spriteSheet.Height / 2);
            animatedSprite2 = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 + spriteSheet.Width / 6, 0));
            animatedSprite2.Origin = new Vector2(spriteSheet.Width / 6 / 2, 0);
            animatedSprite2.Play("not_idle");

            Log.Info(animatedSprite);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            if (/*GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||*/ FeevKeyboard.IsKeyDown(FeevKeys.Escape))
                Exit();

            if (FeevMouse.IsButtonDown(MouseButtons.XButton1))
            {
                Random random = new Random();
                float r = random.NextFloat();
                float g = random.NextFloat();
                float b = random.NextFloat();
                clearColor = new Color(r, g, b);
            }

            if (FeevKeyboard.IsKeyDown(FeevKeys.A))
                animatedSprite.Transform.Position.X -= speed * gameTime.GetElapsedSeconds();
            if (FeevKeyboard.IsKeyDown(FeevKeys.D))
                animatedSprite.Transform.Position.X += speed * gameTime.GetElapsedSeconds();

            if (FeevKeyboard.IsKeyDown(FeevKeys.W))
                animatedSprite.Transform.Position.Y -= speed * gameTime.GetElapsedSeconds();
            if (FeevKeyboard.IsKeyDown(FeevKeys.S))
                animatedSprite.Transform.Position.Y += speed * gameTime.GetElapsedSeconds();

            if (FeevKeyboard.IsKeyDown(FeevKeys.Q))
                camera.Rotation -= gameTime.GetElapsedSeconds();
            if (FeevKeyboard.IsKeyDown(FeevKeys.E))
                camera.Rotation += gameTime.GetElapsedSeconds();

            if (FeevKeyboard.GetPressedKeys().Length > 0)
                Log.Warning(FeevKeyboard.GetPressedKeys()[0]);

            camera.Position += (animatedSprite.Transform.Position - camera.Position) / 10;
            camera.Zoom += MathHelper.Lerp(0, 1, FeevMouse.ScrollWheelValue * gameTime.GetElapsedSeconds() / 15);
            camera.Zoom = Math.Clamp(camera.Zoom, 0, float.PositiveInfinity);

            animatedSprite.Update(gameTime);
            animatedSprite2.Update(gameTime);
        }

        protected override void OnDraw()
        {
            GraphicsDevice.Clear(clearColor);

            Batch.Begin(samplerState: SamplerState.PointClamp);
            Batch.BeginMode2D(camera);
            sprite.Draw();
            animatedSprite2.Draw();
            animatedSprite.Draw();
            Batch.EndMode2D();
            Batch.DrawString(font, FeevMouse.TotalScrollWheelValue.ToString(), Vector2.Zero, Color.White);
            Batch.DrawString(font, camera.Zoom.ToString(), new Vector2(0, 50), Color.White);
            Batch.End();
        }
    }
}
