using MonoGame.Extended.Tiled;
using System.IO;
using Newtonsoft.Json.Linq;
using TurnBaseGame.Datas;

namespace TurnBaseGame.Levels
{
    public class ALevel : ILevel
    {

        #region Member variables
        private TiledMap _map;
        #endregion Member variables

        #region Constructor
        public ALevel(string mapPath)
        {
            LoadMap(mapPath);
        }
        #endregion Constructor

        #region Private methods
        private void LoadMap(string mapPath)
        {
            using(StreamReader sr = File.OpenText(mapPath))
            {
                JObject mapParsed = JObject.Parse(sr.ReadToEnd());
                JToken mapToken = mapParsed.SelectToken("Map");
                _map = new TiledMap(mapToken["Location"].Value<string>(), mapToken["Width"].Value<int>(),
                                    mapToken["Height"].Value<int>(), GameSettings.TileWidth, GameSettings.TileHeight,
                                    TiledMapTileDrawOrder.LeftUp, TiledMapOrientation.Orthogonal);
            }
        }
        #endregion Private methods

    }
}
