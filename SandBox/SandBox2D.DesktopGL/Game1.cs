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
        Texture2D scarfy;
        Texture2D sheet;
        Color clearColor = Color.Black;
        AnimatedSprite animatedSprite;
        AnimatedSprite animatedSprite2;
        Sprite sprite;
        Tilemap tilemap;
        Camera2D camera;
        Button button;
        Label label;
        float speed = 400;

        PointLight pointLight;

        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void OnInitialize()
        {
            camera = new Camera2D(0f, 1f);
            Window.AllowUserResizing = true;
            Batch.SamplerState = SamplerState.PointClamp;
        }

        protected override void OnLoad()
        {
            font = Globals.Content.Load<SpriteFont>("Font");
            scarfy = Globals.Content.Load<Texture2D>("scarfy");
            sheet = Globals.Content.Load<Texture2D>("sheet");
            sprite = new Sprite(scarfy, new Transform2D(new Vector2(Globals.Graphics.PreferredBackBufferWidth / 2, 200), 0f, Vector2.One), new Vector2(scarfy.Width / 2, 0));

            animatedSprite = Globals.Content.LoadAnimatedSprite("file", new Vector2(Globals.Graphics.PreferredBackBufferWidth / 2 - scarfy.Width / 6, 0));
            animatedSprite.Origin = new Vector2(scarfy.Width / 6 / 2, scarfy.Height / 2);
            animatedSprite2 = Globals.Content.LoadAnimatedSprite("file", new Vector2(Globals.Graphics.PreferredBackBufferWidth / 2 + scarfy.Width / 6, 0));
            animatedSprite2.Origin = new Vector2(scarfy.Width / 6 / 2, 0);
            animatedSprite2.Play("not_idle");

            tilemap = Globals.Content.LoadTilemap("file");

            button = new Button(new Vector2(20, 20),
                Globals.Content.Load<Texture2D>("NormalButton"),
                Globals.Content.Load<Texture2D>("HoverButton"),
                Globals.Content.Load<Texture2D>("PressedButton"));

            label = new Label("Hello", font, Color.Red, new Transform2D(new Vector2(20, 60), 0f, Vector2.One));

            button.OnClick += delegate
            {
                Log.Error("Hello");
            };

            button.OnReleased += delegate
            {
                Log.Info("Hello");
            };

            pointLight = new PointLight(Vector2.Zero, 120f, Color.White);

            Log.Info(animatedSprite);
        }

        protected override void OnUpdate(GameTime gameTime)
        {
            if (GamePad.IsButtonDown(GamePadButtons.Back, Player.One) || Keyboard.IsKeyDown(Keys.Escape))
                Exit();

            Random random = new Random();
            if (Mouse.IsButtonDown(MouseButtons.XButton1))
            {
                clearColor = random.NextColor(Color.Black, Color.White);
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

            if (Keyboard.IsKeyDown(Keys.Plus))
                pointLight.Radius += 100f * gameTime.GetElapsedSeconds();
            if (pointLight.Radius > 0 && Keyboard.IsKeyDown(Keys.Minus))
                pointLight.Radius -= 100f * gameTime.GetElapsedSeconds();

            pointLight.Position = camera.ScreenToWorld(Mouse.Position);

            if (Mouse.IsButtonJustPressed(MouseButtons.Left))
            {
                var pointLight2 = new PointLight(camera.ScreenToWorld(Mouse.Position), 100f, random.NextColor());
            }

            //if (Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys().Length > 0)
            //    Log.Print(Microsoft.Xna.Framework.Input.Keyboard.GetState().GetPressedKeys()[0]);
        }

        protected override void OnDraw()
        {
            GraphicsDevice.Clear(clearColor);

            RenderTarget2D renderTarget = new RenderTarget2D(GraphicsDevice, 800, 480);

            Batch.Begin(renderTarget);
            Batch.BeginMode2D(camera, true);
            tilemap.Draw();
            sprite.Draw();
            animatedSprite2.Draw();
            animatedSprite.Draw();
            Batch.EndMode2D();
            Batch.End();

            PointLight.Draw(renderTarget, camera);

            Batch.Begin();
            button.Draw();
            label.Draw();
            Batch.End();

            renderTarget.Dispose();
        }
    }
}
