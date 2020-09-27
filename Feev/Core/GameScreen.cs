using Feev.Input;
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
            OnUpdate(gameTime);
            base.Update(gameTime);
        }

        protected sealed override void Draw(GameTime gameTime)
        {
            OnDraw();
            base.Draw(gameTime);
        }

        protected virtual void OnInitialize() { }
        protected virtual void OnLoad() { }
        protected virtual void OnUpdate(GameTime gameTime) { }
        protected virtual void OnDraw() { }
    }
}
