using Feev;
using Feev.Debug;
using Feev.Graphics;
using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SandBox2D.DesktopGL
{
    public class Game1 : GameScreen
    {
        public Game1()
        {
            IsMouseVisible = true;
        }

        protected override void OnInitialize()
        {
            Window.AllowUserResizing = true;
            Batch.SamplerState = SamplerState.PointClamp;
        }

        protected override void OnLoad()
        {
            SpriteFont font = Globals.Content.Load<SpriteFont>("Font");
            Texture2D scarfy = Globals.Content.Load<Texture2D>("scarfy");
            Texture2D sheet = Globals.Content.Load<Texture2D>("sheet");

            Entity tilemap = new Entity();
            Entity animatedSprite2 = new Entity();
            Entity scarfySprite = new Entity();
            Entity animatedSprite = new Entity();
            Entity camera = new Entity("Camera");
            Entity button = new Entity("Button");
            Entity label = new Entity();

            ref ScriptComponent scriptComponent = ref animatedSprite.AddComponent<ScriptComponent>();
            scriptComponent.Bind<Bob>(animatedSprite);

            ref AnimatedSpriteComponent animatedSpriteComponent = ref animatedSprite.AddComponent<AnimatedSpriteComponent>();
            ref AnimatedSpriteComponent animatedSpriteComponent2 = ref animatedSprite2.AddComponent<AnimatedSpriteComponent>();

            animatedSpriteComponent = new AnimatedSpriteComponent("file");
            animatedSpriteComponent.Origin = new Vector2(scarfy.Width / 6 / 2, scarfy.Height / 2);
            animatedSpriteComponent.Play("idle");

            animatedSpriteComponent2 = new AnimatedSpriteComponent("file");
            animatedSpriteComponent2.Origin = new Vector2(scarfy.Width / 6 / 2, 0);
            animatedSpriteComponent2.Play("not_idle");

            ref SpriteComponent scarfySpriteComponent = ref scarfySprite.AddComponent<SpriteComponent>();
            ref TransformComponent scarfyTransformComponent = ref scarfySprite.GetComponent<TransformComponent>();

            scarfyTransformComponent.Position = new Vector2(Globals.Graphics.PreferredBackBufferWidth / 2, 200);
            scarfyTransformComponent.Rotation = 0f;
            scarfyTransformComponent.Scale = Vector2.One;

            scarfySpriteComponent = new SpriteComponent(scarfy, new Vector2(scarfy.Width / 2, 0));

            ref TransformComponent cameraTransformComponent = ref camera.GetComponent<TransformComponent>();
            ref CameraComponent cameraComponent = ref camera.AddComponent<CameraComponent>();

            cameraTransformComponent.Position = new Vector2(Globals.Graphics.PreferredBackBufferWidth, Globals.Graphics.PreferredBackBufferHeight) / 2;
            cameraTransformComponent.Rotation = 0f;
            cameraTransformComponent.Scale = Vector2.One;

            cameraComponent = new CameraComponent(camera);
            cameraComponent.SetAsMainCamera();

            ref TilemapComponent tilemapComponent = ref tilemap.AddComponent<TilemapComponent>();
            tilemapComponent = new TilemapComponent("file");

            ref ButtonComponent buttonComponent = ref button.AddComponent<ButtonComponent>();
            ref TransformComponent buttonTransformComponent = ref button.AddComponent<TransformComponent>();
            buttonComponent = new ButtonComponent(
                Globals.Content.Load<Texture2D>("NormalButton"),
                Globals.Content.Load<Texture2D>("HoverButton"),
                Globals.Content.Load<Texture2D>("PressedButton"));

            buttonTransformComponent.Position = new Vector2(20, 20);

            ref LabelComponent labelComponent = ref label.AddComponent<LabelComponent>();
            ref TransformComponent labelTransform = ref label.GetComponent<TransformComponent>();
            labelComponent = new LabelComponent("Hello", font);
            labelComponent.Color = Color.Red;
            labelTransform.Position = new Vector2(20, 60);

            Log.Info(animatedSprite);
        }
    }
}
