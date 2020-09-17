using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Feev.DesktopGL.Utils.Json
{
    static class JsonParser
    {
        public static JsonTilemapResult ParseTilemap(string json)
        {
            dynamic tilemap = JsonConvert.DeserializeObject(json);

            JArray jsonMap = tilemap.map;
            JArray jsonTiles = tilemap.tiles;
            float xPos = tilemap.position[0];
            float yPos = tilemap.position[1];

            List<Tile> tiles = new List<Tile>();

            foreach (var item in jsonTiles)
            {
                int id = item["id"].ToObject<int>();

                JToken jsonSourceRect = item["source_rectangle"];
                int x = jsonSourceRect["x"].ToObject<int>();
                int y = jsonSourceRect["y"].ToObject<int>();
                int w = jsonSourceRect["width"].ToObject<int>();
                int h = jsonSourceRect["height"].ToObject<int>();

                tiles.Add(new Tile() { Id = id, SourceRectangle = new Rectangle(x, y, w, h) });
            }

            int[][] map = jsonMap.ToObject<int[][]>();
            string spriteSheet = tilemap.spritesheet;
            int width = tilemap.tile_width;
            int height = tilemap.tile_height;
            Vector2 position = new Vector2(xPos, yPos);

            return new JsonTilemapResult()
            {
                Tiles = tiles,
                Map = map,
                SpriteSheet = spriteSheet,
                Size = new Vector2(width, height),
                Position = position,
            };
        }
    }
}
