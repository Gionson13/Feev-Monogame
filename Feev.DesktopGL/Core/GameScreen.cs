using Feev.DesktopGL.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.DesktopGL
{
    public class GameScreen : Game
    {
        public GameScreen()
        {
            Globals.graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            Globals.content = this.Content;
        }

        protected sealed override void Initialize()
        {
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
            FeevKeyboard.Update();
            FeevMouse.Update();
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
