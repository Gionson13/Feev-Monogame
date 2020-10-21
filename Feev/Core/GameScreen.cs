using Feev.Extension;
using Feev.Graphics;
using Feev.Input;
using Feev.Utils;
using Leopotam.Ecs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev
{
    public class GameScreen : Game
    {
        public GameScreen()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.Content = Content;
            Globals.ecsWorld = new EcsWorld();
        }

        protected sealed override void Initialize()
        {
            Globals.GraphicsDevice = GraphicsDevice;
            OnInitialize();

            base.Initialize();
        }

        protected sealed override void LoadContent()
        {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);
            OnLoad();
            base.LoadContent();
        }

        protected sealed override void Update(GameTime gameTime)
        {
            Keyboard.Update();
            Mouse.Update();
            GamePad.Update();

            Time.DeltaTime = gameTime.GetElapsedSeconds();
            Time.TotalTime += Time.DeltaTime;

            foreach (Entity entity in Globals.entities)
                entity.Update();

            if (Globals.shouldExit) Exit();

            base.Update(gameTime);
        }

        protected sealed override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Globals.ClearColor);


            Batch.Begin();

            if (Globals.mainCamera != null)
                Batch.BeginMode2D(Globals.mainCamera);

            foreach (Entity entity in Globals.entities)
                entity.Draw();

            if (Globals.mainCamera != null)
                Batch.EndMode2D();

            foreach (Entity entity in Globals.entities)
                entity.DrawUI();

            Batch.End();


            base.Draw(gameTime);
        }

        protected virtual void OnInitialize() { }
        protected virtual void OnLoad() { }
    }
}
