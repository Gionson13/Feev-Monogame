using Feev.Extension;
using Feev.Graphics;
using Feev.Graphics.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Net.Http.Headers;

namespace Feev.Utils
{
    public struct TagComponent
    {
        public string Tag;
    }

    public struct TransformComponent
    {
        internal Entity owner;

        private Vector2 _position;
        private float _rotation;
        private Vector2 _scale;

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; owner.TransformChanged(_position, _rotation, _scale); }
        }
        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; owner.TransformChanged(_position, _rotation, _scale); }
        }
        public Vector2 Scale
        {
            get { return _scale; }
            set { _scale = value; owner.TransformChanged(_position, _rotation, _scale); }
        }

        public void Set(Transform2D transform)
        {
            _position = transform.Position;
            _rotation = transform.Rotation;
            _scale = transform.Scale;
            owner.TransformChanged(_position, _rotation, _scale);
        }
    }

    public struct SpriteComponent
    {
        private Sprite _sprite;
        internal Entity owner;

        #region public fiedlds

        public Texture2D Texture { get { return _sprite.Texture; } set { _sprite.Texture = value; } }
        public Vector2 Origin { get { return _sprite.Origin; } set { _sprite.Origin = value; } }
        public Rectangle? SourceRectangle { get { return _sprite.SourceRectangle; } set { _sprite.SourceRectangle = value; } }

        #endregion

        public SpriteComponent(Texture2D texture, Entity owner, Vector2 origin) : this(texture, owner, origin, null)
        {
        }

        public SpriteComponent(Texture2D texture, Entity owner, Vector2 origin, Rectangle? sourceRectangle)
        {
            this.owner = owner;
            var transform = this.owner.GetComponent<TransformComponent>();
            _sprite = new Sprite(texture, new Transform2D(transform.Position, transform.Rotation, transform.Scale), origin, sourceRectangle);
            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        #region Draw

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        public void Draw() => _sprite.Draw(Color.White);

        /// <summary>
        /// Draws the sprite.
        /// </summary>
        /// <param name="colorMask">A color mask.</param>
        public void Draw(Color colorMask) => _sprite.Draw(colorMask);

        #endregion

        private void Owner_OnTransformChanged(object source, TransformEventArgs e)
        {
            _sprite.Transform.Position = e.Position;
            _sprite.Transform.Rotation = e.Rotation;
            _sprite.Transform.Scale = e.Scale;
        }
    }

    public struct AnimatedSpriteComponent
    {
        internal Entity owner;

        private AnimatedSprite _animatedSprite;

        public Vector2 Origin
        {
            get { return _animatedSprite.Origin; }
            set { _animatedSprite.Origin = value; }
        }

        public AnimatedSpriteComponent(Entity owner, string filename)
        {
            this.owner = owner;
            var transform = this.owner.GetComponent<TransformComponent>();
            _animatedSprite = Globals.Content.LoadAnimatedSprite(filename);
            _animatedSprite.Transform.Position = transform.Position;
            _animatedSprite.Transform.Rotation = transform.Rotation;
            _animatedSprite.Transform.Scale = transform.Scale;

            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        public void Update() => _animatedSprite.Update();

        public void Draw() => _animatedSprite.Draw(Color.White);
        public void Draw(Color colorMask) => _animatedSprite.Draw(colorMask);

        public void Play(string animation) => _animatedSprite.Play(animation);
        public void Pause() => _animatedSprite.Pause();
        public void Resume() => _animatedSprite.Resume();

        private void Owner_OnTransformChanged(object source, TransformEventArgs e)
        {
            _animatedSprite.Transform.Position = e.Position;
            _animatedSprite.Transform.Rotation = e.Rotation;
            _animatedSprite.Transform.Scale = e.Scale;
        }
    }

    public struct CameraComponent
    {
        internal Entity owner;
        internal Camera2D camera;

        public bool PixelPerfect
        {
            get { return camera.PixelPerfect; }
            set { camera.PixelPerfect = value; }
        }

        public Vector2 Origin
        {
            get { return camera.Origin; }
            set { camera.Origin = value; }
        }
        public Rectangle Bounds
        {
            get { return camera.Bounds; }
        }

        public CameraComponent(Entity owner) : this(owner, 1f)
        {
        }

        public CameraComponent(Entity owner, float zoom)
        {
            this.owner = owner;
            var tranform = this.owner.GetComponent<TransformComponent>();
            camera = new Camera2D(tranform.Position, tranform.Rotation, zoom);
            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        public CameraComponent(Entity owner, float zoom, Vector2 origin)
        {
            this.owner = owner;
            var tranform = this.owner.GetComponent<TransformComponent>();
            camera = new Camera2D(tranform.Position, tranform.Rotation, zoom, origin);
            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        public void SetAsMainCamera() => Globals.mainCamera = camera;

        public Vector2 ScreenToWorld(Vector2 pixel)
        {
            return camera.ScreenToWorld(pixel);
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return camera.WorldToScreen(worldPosition);
        }

        private void Owner_OnTransformChanged(object source, TransformEventArgs e)
        {
            camera.Position = e.Position;
            camera.Rotation = e.Rotation;
            camera.Scale = e.Scale;
        }
    }

    public struct ScriptComponent
    {
        private Entity _owner;
        private ScriptableEntity _script;

        public ScriptComponent(Entity owner)
        {
            _owner = owner;
            _script = new ScriptableEntity();
        }

        internal void Update() => _script.OnUpdate();

        public void Bind<T>() where T : ScriptableEntity, new()
        {
            _script = new T();
            _script.owner = _owner;
            _script.OnInitialize();
        }
    }

    public struct TilemapComponent
    {
        private Tilemap _tilemap;

        public TilemapComponent(string tilemapFilename)
        {
            _tilemap = Globals.Content.LoadTilemap(tilemapFilename);
        }

        public void Draw() => _tilemap.Draw();
    }

    // UI -----------------------------------------------------------------------

    public struct ButtonComponent
    {
        internal Entity owner;

        private Button _button;

        public Texture2D Normal
        {
            get { return _button.Normal; }
            set { _button.Normal = value; }
        }
        public Texture2D Hover
        {
            get { return _button.Hover; }
            set { _button.Hover = value; }
        }
        public Texture2D Pressed
        {
            get { return _button.Pressed; }
            set { _button.Pressed = value; }
        }

        public event EventHandler OnClick
        {
            add { _button.OnClick += value; }
            remove { _button.OnClick -= value; }
        }

        public event EventHandler OnReleased
        {
            add { _button.OnReleased += value; }
            remove { _button.OnReleased -= value; }
        }

        public ButtonComponent(Entity owner, Texture2D normal, Texture2D hover, Texture2D pressed)
        {
            this.owner = owner;
            _button = new Button(normal, hover, pressed);
            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        private void Owner_OnTransformChanged(object source, TransformEventArgs e)
        {
            _button.Position = e.Position;
            _button.Rotation = e.Rotation;
            _button.Scale = e.Scale;
        }

        internal void Update() => _button.Update();
        internal void Draw() => _button.Draw();
    }

    public struct LabelComponent
    {
        internal Entity owner;
        private Label _label;

        public Color Color
        {
            get { return _label.Color; }
            set { _label.Color = value; }
        }

        public SpriteFont Font
        {
            get { return _label.Font; }
            set { _label.Font = value; }
        }

        public string Text
        {
            get { return _label.Text; }
            set { _label.Text = value; }
        }

        public Vector2 Origin
        {
            get { return _label.Origin; }
            set { _label.Origin = value; }
        }

        public LabelComponent(Entity owner, string text, SpriteFont font)
        {
            this.owner = owner;
            _label = new Label(text, font, Color.White);
            this.owner.OnTransformChanged += Owner_OnTransformChanged;
        }

        private void Owner_OnTransformChanged(object source, TransformEventArgs e)
        {
            _label.Position = e.Position;
            _label.Rotation = e.Rotation;
            _label.Scale = e.Scale;
        }

        internal void Draw() => _label.Draw();
    }
}
