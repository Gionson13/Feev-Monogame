using Feev;
using Feev.Debug;
using Feev.Extension;
using Feev.Graphics;
using Feev.Graphics.UI;
using Feev.Input;
using Feev.Utils;
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
        Tilemap tilemap;
        Camera2D camera;
        Button button;
        Label label;
        float speed = 400;

        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void OnInitialize()
        {
            camera = new Camera2D(0f, 1f);
            Window.AllowUserResizing = true;    
        }

        protected override void OnLoad()
        {
            font = Globals.content.Load<SpriteFont>("Font");
            var texture = Globals.content.Load<Texture2D>("scarfy");
            sprite = new Sprite(texture, new Transform2D(new Vector2(Globals.graphics.PreferredBackBufferWidth / 2, 200), 0f, Vector2.One), new Vector2(texture.Width / 2, 0));

            animatedSprite = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 - texture.Width / 6, 0));
            animatedSprite.Origin = new Vector2(texture.Width / 6 / 2, texture.Height / 2);
            animatedSprite2 = Globals.content.LoadAnimatedSprite("file", new Vector2(Globals.graphics.PreferredBackBufferWidth / 2 + texture.Width / 6, 0));
            animatedSprite2.Origin = new Vector2(texture.Width / 6 / 2, 0);
            animatedSprite2.Play("not_idle");

            tilemap = Globals.content.LoadTilemap("file");

            button = new Button(new Vector2(20, 20),
                Globals.content.Load<Texture2D>("NormalButton"),
                Globals.content.Load<Texture2D>("HoverButton"),
                Globals.content.Load<Texture2D>("PressedButton"));

            label = new Label("Hello", font, Color.Red, new Transform2D(new Vector2(20, 60), 0f, Vector2.One));

            button.OnClick += delegate
            {
                Log.Error("Hello");
            };

            button.OnReleased += delegate
            {
                Log.Info("Hello");
            };

            Log.Info(animatedSprite);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            if (GamePad.IsButtonDown(GamePadButtons.Back, Player.One) || Keyboard.IsKeyDown(Keys.Escape))
                Exit();

            if (Mouse.IsButtonDown(MouseButtons.XButton1))
            {
                Random random = new Random();
                float r = random.NextFloat();
                float g = random.NextFloat();
                float b = random.NextFloat();
                clearColor = new Color(r, g, b);
            }

            if (Keyboard.IsKeyDown(Keys.A))
                animatedSprite.Transform.Position.X -= speed * gameTime.GetElapsedSeconds();
            if (Keyboard.IsKeyDown(Keys.D))
                animatedSprite.Transform.Position.X += speed * gameTime.GetElapsedSeconds();

            if (Keyboard.IsKeyDown(Keys.W))
                animatedSprite.Transform.Position.Y -= speed * gameTime.GetElapsedSeconds();
            if (Keyboard.IsKeyDown(Keys.S))
                animatedSprite.Transform.Position.Y += speed * gameTime.GetElapsedSeconds();

            if (Keyboard.IsKeyDown(Keys.Q))
                camera.Rotation -= gameTime.GetElapsedSeconds();
            if (Keyboard.IsKeyDown(Keys.E))
                camera.Rotation += gameTime.GetElapsedSeconds();

            camera.Position += (animatedSprite.Transform.Position - camera.Position) / 10;
            camera.Zoom += MathHelper.Lerp(0, 1, Mouse.ScrollWheelValue * gameTime.GetElapsedSeconds() / 15);
            camera.Zoom = Math.Clamp(camera.Zoom, 0.01f, float.PositiveInfinity);

            animatedSprite.Update(gameTime);
            animatedSprite2.Update(gameTime);
            button.Update();

            if (Keyboard.GetPressedKeys().Length > 0)
                Log.Print(Keyboard.GetPressedKeys()[0]);

            //if (Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys().Length > 0)
            //    Log.Print(Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys()[0]);
        }

        protected override void OnDraw()
        {
            GraphicsDevice.Clear(clearColor);

            Batch.Begin(samplerState: SamplerState.PointClamp);
            Batch.BeginMode2D(camera, true);
            tilemap.Draw();
            sprite.Draw();
            animatedSprite2.Draw();
            animatedSprite.Draw();
            Batch.EndMode2D();
            button.Draw();
            label.Draw();
            Batch.End();
        }
    }
}
