using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame.Datas
{
    public static class GameSettings
    {

        #region Graphics
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static int TileWidth { get; private set; }
        public static int TileHeight { get; private set; }
        #endregion Graphics

        #region Refreshing rate
        public static int GraphicRefreshingRate { get; private set; }
        public static int PhysicRefreshingRate { get; private set; }
        #endregion Refreshing rate

        static GameSettings()
        {
            Width = 800;
            Height = 480;
            GraphicRefreshingRate = 120; // can be set to <= 0 for a non fixed timestamp
            PhysicRefreshingRate = 60;
            TileWidth = 32;
            TileHeight = 32;
        }

    }
}
