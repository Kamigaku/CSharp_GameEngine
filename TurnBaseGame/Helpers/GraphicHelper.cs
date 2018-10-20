using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Datas;

namespace TurnBaseGame.Helpers
{
    public abstract class GraphicHelper
    {

        protected GraphicHelper() {}

        public static Vector2 ConvertTileCoordinateToGraphic(int tileX, int tileY)
        {
            return new Vector2(tileX * GameSettings.TileWidth, tileY * GameSettings.TileHeight);
        }

        public static Vector2 ConvertGraphicCoordinateToTile(float x, float y)
        {
            return new Vector2((float)Math.Floor(x / GameSettings.TileWidth), 
                               (float)Math.Floor(y / GameSettings.TileHeight));
        }

    }
}
