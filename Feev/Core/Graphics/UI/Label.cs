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
        public Transform2D Transform;
        public Vector2 Origin;

        public Label(string text, SpriteFont font, Color color, Transform2D transform) : this(text, font, color, transform, Vector2.Zero)
        {
        }

        public Label(string text, SpriteFont font, Color color, Transform2D transform, Vector2 origin)
        {
            Text = text;
            Font = font;
            Color = color;
            Transform = transform;
            Origin = origin;
        }

        public void Draw()
        {
            Batch.DrawString(Font, Text, Transform.Position, Color, Transform.Rotation, Origin, Transform.Scale, SpriteEffects.None, 0f);
        }
    }
}
