using Feev.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace Feev.Graphics.UI
{
    static class Label
    {
        public static void Draw(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            LabelComponent label = entity.GetComponent<LabelComponent>();

            Batch.DrawString(label.Font, label.Text, transform.Position, label.Color, transform.Rotation, label.Origin, transform.Scale, SpriteEffects.None, 0f);
        }
    }
}
