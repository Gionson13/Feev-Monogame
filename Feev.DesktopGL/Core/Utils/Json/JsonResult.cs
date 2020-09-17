﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Feev.DesktopGL.Utils.Json
{
    struct JsonTilemapResult
    {
        public List<Tile> Tiles;
        public string SpriteSheet;
        public int[][] Map;
        public Vector2 Size;
        public Vector2 Position;
    }
}
