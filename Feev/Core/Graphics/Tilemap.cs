using Feev.Utils;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Feev.Graphics
{
    static class Tilemap
    {
        public static void Draw(Entity entity)
        {
            TransformComponent transform = entity.GetComponent<TransformComponent>();
            TilemapComponent tilemap = entity.GetComponent<TilemapComponent>();

            for (int y = 0; y < tilemap.Map.Length; y++)
            {
                for (int x = 0; x < tilemap.Map[y].Length; x++)
                {
                    if (tilemap.Map[y][x] == 0)
                        continue;

                    Batch.Draw(tilemap.spriteSheet, new Vector2(x, y) * tilemap.tileSize * transform.Scale + transform.Position, tilemap.Tiles.First(tile => tile.Id == tilemap.Map[y][x]).SourceRectangle, Color.White);
                }
            }
        }
    }
}
