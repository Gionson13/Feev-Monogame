using Feev.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Feev.Graphics
{
    public class Tilemap
    {
        private readonly Texture2D _spriteSheet;
        private Vector2 _tileSize;

        public List<Tile> Tiles;
        public Vector2 Position;
        public int[][] Map;

        public Tilemap(Texture2D spriteSheet, Vector2 position, int[][] map, List<Tile> tiles, Vector2 tileSize)
        {
            _spriteSheet = spriteSheet;
            _tileSize = tileSize;

            Tiles = tiles;
            Position = position;
            Map = map;
        }

        public void Draw()
        {
            Draw(Color.White);
        }

        public void Draw(Color coloMask)
        {
            for(int y = 0; y < Map.Length; y++)
            {
                for(int x = 0; x < Map[y].Length; x++)
                {
                    if (Map[y][x] == 0)
                        continue;

                    Batch.Draw(_spriteSheet, new Vector2(x, y) * _tileSize + Position, Tiles.First(tile => tile.Id == Map[y][x]).SourceRectangle, coloMask);
                }
            }
        }
    }
}
