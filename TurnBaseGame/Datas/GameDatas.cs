using Microsoft.Xna.Framework.Content;
using MonoGame.Extended;
using System.Collections.Generic;
using TurnBaseGame.Entities;
using TurnBaseGame.Controllers;
using TurnBaseGame.Entities.Implementations;

namespace TurnBaseGame.Datas
{
    public static class GameDatas
    {

        #region Class fields

        private static MobileEntity _mainEntity;

        #endregion Class fields

        #region Properties

        #region Entities
        public static Dictionary<int, AEntity> AllEntities { get; private set; }

        public static MobileEntity MainEntity
        {
            get
            {
                return _mainEntity;
            }
            set
            {
                _mainEntity = value;
                CharacterFreeModeController.ChangeAssignedEntity(MainEntity);
                CharacterBattleModeController.ChangeAssignedEntity(MainEntity);
            }
        }
        #endregion Entities

        #region Content
        public static ContentManager AssetManager { get; set; }
        #endregion Content

        #region Controls
        public static Controller KeyboardListener { get; private set; }
        public static CharacterFreeModeController CharacterFreeModeController { get; private set; }
        public static CharacterBattleModeController CharacterBattleModeController { get; private set; }
        #endregion Controls

        #region Main camera
        public static Camera2D MainCamera { get; set; }
        #endregion Main camera

        #endregion Properties

        static GameDatas()
        {
            AllEntities = new Dictionary<int, AEntity>();
            KeyboardListener = new Controller();
            CharacterFreeModeController = new CharacterFreeModeController();
            CharacterBattleModeController = new CharacterBattleModeController();
        }

    }
}
