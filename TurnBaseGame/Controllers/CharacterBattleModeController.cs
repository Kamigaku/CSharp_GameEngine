using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TurnBaseGame.Datas;
using TurnBaseGame.Entities.Implementations;

namespace TurnBaseGame.Controllers
{
    public class CharacterBattleModeController
    {

        #region Properties
        private bool _isActive;
        private MobileEntity _assignedEntity;
        #endregion

        #region Constructor
        public CharacterBattleModeController() { }

        public CharacterBattleModeController(MobileEntity entity)
        {

        }
        #endregion Constructor

        #region Public methods

        /// <summary>
        /// Change the Entity that will be affected by the current controller
        /// </summary>
        /// <param name="assignedEntity">The new entity</param>
        public void ChangeAssignedEntity(MobileEntity assignedEntity)
        {
            if (assignedEntity != null)
            {
                _assignedEntity = assignedEntity;
            }
        }

        /// <summary>
        /// Activate or deactivate a controller
        /// </summary>
        /// <param name="newState">The new controller status</param>
        public void ChangeState(bool newState)
        {
            GameDatas.KeyboardListener.OnMouseLeftButtonDown -= MouseLeftButtonDown;
            GameDatas.KeyboardListener.OnMouseLeftButtonUp -= MouseLeftButtonUp;
            GameDatas.KeyboardListener.OnMouseRightButtonDown -= MouseRightButtonDown;
            GameDatas.KeyboardListener.OnMouseRightButtonUp -= MouseRightButtonUp;
            _isActive = newState;
            if (_isActive)
            {
                GameDatas.KeyboardListener.OnMouseLeftButtonDown += MouseLeftButtonDown;
                GameDatas.KeyboardListener.OnMouseLeftButtonUp += MouseLeftButtonUp;
                GameDatas.KeyboardListener.OnMouseRightButtonDown += MouseRightButtonDown;
                GameDatas.KeyboardListener.OnMouseRightButtonUp += MouseRightButtonUp;
            }
        }

        #endregion Public methods

        #region Private methods
        /// <summary>
        /// Event fired when the left button of the mouse is pressed.
        /// </summary>
        private void MouseLeftButtonUp(object sender, MouseState mouseState)
        {
            Vector2 mousePosition = new Vector2(mouseState.X, mouseState.Y);
            Vector2 worldPosition = GameDatas.MainCamera.ScreenToWorld(mousePosition);
            worldPosition = Helpers.GraphicHelper.ConvertGraphicCoordinateToTile((int)worldPosition.X, (int)worldPosition.Y);
            _assignedEntity.SetTilePosition((int)worldPosition.X, (int)worldPosition.Y);
        }

        /// <summary>
        /// Event fired when the left button of the mouse is released.
        /// </summary>
        private void MouseLeftButtonDown(object sender, MouseState mouseState)
        {
        }

        /// <summary>
        /// Event fired when the right button of the mouse is pressed.
        /// </summary>
        private void MouseRightButtonUp(object sender, MouseState mouseState)
        {
        }

        /// <summary>
        /// Event fired when the right button of the mouse is released.
        /// </summary>
        private void MouseRightButtonDown(object sender, MouseState mouseState)
        {
        }
        #endregion Private methods

    }
}
