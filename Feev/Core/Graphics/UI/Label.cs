using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.Graphics.UI
{
    public class Label
    {
        public string Text;
        public SpriteFont Font;
        public Color Color;

        public Vector2 Position = Vector2.Zero;
        public float Rotation = 0f;
        public Vector2 Scale = Vector2.One;

        public Vector2 Origin;

        public Label(string text, SpriteFont font, Color color) : this(text, font, color, Vector2.Zero)
        {
        }

        public Label(string text, SpriteFont font, Color color, Vector2 origin)
        {
            Text = text;
            Font = font;
            Color = color;
            Origin = origin;
        }

        public void Draw()
        {
            Batch.DrawString(Font, Text, Position, Color, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }
    }
}
