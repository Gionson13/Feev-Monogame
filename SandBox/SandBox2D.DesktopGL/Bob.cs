using Feev;
using Feev.Debug;
using Feev.Input;
using Feev.Utils;
using Feev.Extension;
using Microsoft.Xna.Framework;
using System;

namespace SandBox2D.DesktopGL
{
    class Bob : ScriptableEntity
    {
        float speed = 400;
        Entity camera;
        Entity button;

        bool wasPressed = false;

        protected override void OnInitialize()
        {
            camera = GetEntity("Camera");
            button = GetEntity("Button");
        }

        protected override void OnUpdate()
        {
            if (GamePad.IsButtonDown(GamePadButtons.Back, Player.One) || Keyboard.IsKeyDown(Keys.Escape))
                Exit();

            ref TransformComponent transform = ref GetComponent<TransformComponent>();
            ref TransformComponent cameraTransform = ref camera.GetComponent<TransformComponent>();
            ButtonComponent buttonComponent = button.GetComponent<ButtonComponent>();

            Random random = new Random();
            if (Keyboard.IsKeyDown(Keys.P))
                Globals.ClearColor = random.NextColor(Color.Black, Color.White);

            if (Keyboard.IsKeyDown(Keys.A))
                transform.Position.X -= speed * Time.DeltaTime;
            if (Keyboard.IsKeyDown(Keys.D))
                transform.Position.X += speed * Time.DeltaTime;

            if (Keyboard.IsKeyDown(Keys.W))
                transform.Position.Y -= speed * Time.DeltaTime;
            if (Keyboard.IsKeyDown(Keys.S))
                transform.Position.Y += speed * Time.DeltaTime;

            if (Keyboard.IsKeyDown(Keys.Q))
                cameraTransform.Rotation -= Time.DeltaTime;
            if (Keyboard.IsKeyDown(Keys.E))
                cameraTransform.Rotation += Time.DeltaTime;

            cameraTransform.Position += (transform.Position - cameraTransform.Position) / 10;
            cameraTransform.Scale += new Vector2(MathHelper.Lerp(0, 1, Mouse.ScrollWheelValue * Time.DeltaTime / 15));
            cameraTransform.Scale = new Vector2(Math.Clamp(cameraTransform.Scale.X, 0.01f, float.PositiveInfinity));

            if (Keyboard.GetPressedKeys().Length > 0)
                Log.Print(Keyboard.GetPressedKeys()[0]);

            if (buttonComponent.IsPressed)
            {
                if (!wasPressed)
                {
                    Log.Error("Hello");
                    wasPressed = true;
                }
            }
            else
            {
                if (wasPressed)
                {
                    Log.Info("Hello");
                    wasPressed = false;
                }
            }
        }
    }
}
