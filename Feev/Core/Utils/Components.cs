using Feev.Extension;
using Feev.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Feev.Utils
{
    public struct TagComponent
    {
        public string Tag;
    }

    public struct TransformComponent
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
    }

    public struct SpriteComponent
    {
        #region public fiedlds

        public Texture2D Texture;
        public Vector2 Origin;
        public Rectangle? SourceRectangle;

        #endregion

        public SpriteComponent(Texture2D texture, Vector2 origin) : this(texture, origin, null)
        {
        }

        public SpriteComponent(Texture2D texture, Vector2 origin, Rectangle? sourceRectangle)
        {
            Texture = texture;
            Origin = origin;
            SourceRectangle = sourceRectangle;
        }
    }

    public struct AnimatedSpriteComponent
    {
        internal float elapsedTime;
        internal int frameIndex;
        public bool Paused;

        internal SpriteAnimation currentAnimation;
        internal Dictionary<string, SpriteAnimation> animations;
        public Vector2 Origin;

        public AnimatedSpriteComponent(string filename)
        {
            this = Globals.Content.LoadAnimatedSprite(filename);
        }

        /// <summary>
        /// Play the specified animation.
        /// </summary>
        /// <param name="animation">The animation to play.</param>
        /// <exception cref="KeyNotFoundException"/>
        public void Play(string animation)
        {
            if (animations.ContainsKey(animation))
            {
                currentAnimation = animations[animation];
                elapsedTime = 0f;
                frameIndex = 0;
                Paused = false;
            }
            else
                throw new KeyNotFoundException($"{animation} does not exist");
        }
        //         public void Pause() => _animatedSprite.Pause();
        //         public void Resume() => _animatedSprite.Resume();

        #region Overrides

        public override string ToString()
        {
            string result = "{";

            foreach (var item in animations)
                result += $"{{Name: {item.Key}, Animation: {item.Value}}}, ";

            result = result.Substring(0, result.Length - 2);
            result += "}";
            return result;
        }

        #endregion
    }

    public struct CameraComponent
    {
        public bool PixelPerfect;
        public Vector2 Origin;
        internal Entity owner;

        public Rectangle Bounds
        {
            get
            {
                Vector2 viewPortCorner = ScreenToWorld(new Vector2(0, 0));
                Vector2 viewPortBottomCorner = ScreenToWorld(new Vector2(Globals.Graphics.GraphicsDevice.Viewport.Width,
                    Globals.Graphics.GraphicsDevice.Viewport.Height));

                return new Rectangle(viewPortCorner.ToPoint(), (viewPortBottomCorner - viewPortCorner).ToPoint());
            }
        }

        public Matrix TranslationMatrix
        {
            get
            {
                TransformComponent transform = owner.GetComponent<TransformComponent>();

                if (PixelPerfect)
                    return Matrix.CreateTranslation(new Vector3((int)-transform.Position.X, (int)-transform.Position.Y, 0)) *
                        Matrix.CreateRotationZ(transform.Rotation) *
                        Matrix.CreateScale(new Vector3(transform.Scale, 1)) *
                        Matrix.CreateTranslation(new Vector3(Origin, 0));
                else
                    return Matrix.CreateTranslation(new Vector3(-transform.Position, 0)) *
                        Matrix.CreateRotationZ(transform.Rotation) *
                        Matrix.CreateScale(new Vector3(transform.Scale, 1)) *
                        Matrix.CreateTranslation(new Vector3(Origin, 0));
            }
        }

        public CameraComponent(Entity owner)
        {
            this.owner = owner;
            Origin = new Vector2(Globals.GraphicsDevice.Viewport.Width / 2, Globals.GraphicsDevice.Viewport.Height / 2);
            PixelPerfect = false;
        }

        public CameraComponent(Entity owner, Vector2 origin)
        {
            this.owner = owner;
            Origin = origin;
            PixelPerfect = false;
        }

        public CameraComponent(Entity owner, Vector2 origin, bool pixelPerfect)
        {
            this.owner = owner;
            Origin = origin;
            PixelPerfect = pixelPerfect;
        }

        public void SetAsMainCamera() => Globals.mainCamera = this;

        public Vector2 ScreenToWorld(Vector2 pixel)
        {
            return Vector2.Transform(pixel, Matrix.Invert(TranslationMatrix));
        }

        public Vector2 WorldToScreen(Vector2 worldPosition)
        {
            return Vector2.Transform(worldPosition, TranslationMatrix);
        }
    }

    public struct ScriptComponent
    {
        internal ScriptableEntity script;

        public void Bind<T>(Entity entity) where T : ScriptableEntity, new()
        {
            script = new T();
            script.owner = entity;
            script.OnInitialize();
        }

    }

    public struct TilemapComponent
    {
        internal readonly Texture2D spriteSheet;
        internal Vector2 tileSize;
        public List<Tile> Tiles;
        public int[][] Map;

        internal TilemapComponent(Texture2D spriteSheet, int[][] map, List<Tile> tiles, Vector2 tileSize)
        {
            this.spriteSheet = spriteSheet;
            this.tileSize = tileSize;

            Tiles = tiles;
            Map = map;
        }

        public TilemapComponent(string tilemapFilename)
        {
            this = Globals.Content.LoadTilemap(tilemapFilename);
        }
    }

    // UI -----------------------------------------------------------------------

    public struct ButtonComponent
    {
        public Texture2D Normal;
        public Texture2D Hover;
        public Texture2D Pressed;

        public bool IsPressed;

        internal Texture2D currentTexture;

        public ButtonComponent(Texture2D normal, Texture2D hover, Texture2D pressed)
        {
            Normal = normal;
            Hover = hover;
            Pressed = pressed;
            currentTexture = normal;
            IsPressed = false;
        }
    }

    public struct LabelComponent
    {
        public Color Color;
        public SpriteFont Font;
        public string Text;
        public Vector2 Origin;

        public LabelComponent(string text, SpriteFont font)
        {
            Text = text;
            Font = font;
            Color = Color.White;
            Origin = Vector2.Zero;
        }
    }
}
