using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using TurnBaseGame.Datas;
using TurnBaseGame.Entities.Implementations;

namespace TurnBaseGame.Controllers
{
    public class CharacterFreeModeController
    {

        #region Properties
        private bool _isActive;
        private Vector2 _translationVector;
        private MobileEntity _assignedEntity;
        #endregion

        #region Constructor
        public CharacterFreeModeController() { }

        public CharacterFreeModeController(MobileEntity assignedEntity)
        {
            ChangeAssignedEntity(assignedEntity);
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
                _assignedEntity?.SetTranslationVector(Vector2.Zero);
                _assignedEntity = assignedEntity;
            }
        }

        /// <summary>
        /// Activate or deactivate a controller
        /// </summary>
        /// <param name="newState">The new controller status</param>
        public void ChangeState(bool newState)
        {
            GameDatas.KeyboardListener.OnKeyDown -= OnKeyboardDown;
            GameDatas.KeyboardListener.OnKeyUp -= OnKeyboardUp;
            _isActive = newState;
            if (_isActive)
            {
                GameDatas.KeyboardListener.OnKeyDown += OnKeyboardDown;
                GameDatas.KeyboardListener.OnKeyUp += OnKeyboardUp;
            }
            else
            {
                _assignedEntity?.SetTranslationVector(Vector2.Zero);
            }
        }

        #endregion Public methods

        #region Private methods
        /// <summary>
        /// Event fired when a keyboard key is up
        /// </summary>
        /// <param name="sender">The controller handling the keys</param>
        /// <param name="e">The key that is up</param>
        private void OnKeyboardUp(object sender, Keys e)
        {
            switch (e)
            {
                case Keys.Z:
                    _translationVector.Y += 1;
                    break;
                case Keys.S:
                    _translationVector.Y -= 1;
                    break;
                case Keys.Q:
                    _translationVector.X += 1;
                    break;
                case Keys.D:
                    _translationVector.X -= 1;
                    break;
            }
            _assignedEntity?.SetTranslationVector(_translationVector);
        }

        /// <summary>
        /// Event fired when a keyboard key is released.
        /// </summary>
        /// <param name="sender">The controller that handle the keys</param>
        /// <param name="e">The key that has been released.</param>
        private void OnKeyboardDown(object sender, Keys e)
        {
            switch (e)
            {
                case Keys.Z:
                    _translationVector.Y -= 1;
                    break;
                case Keys.S:
                    _translationVector.Y += 1;
                    break;
                case Keys.Q:
                    _translationVector.X -= 1;
                    break;
                case Keys.D:
                    _translationVector.X += 1;
                    break;
            }
            _assignedEntity?.SetTranslationVector(_translationVector);
        }
        #endregion Private methods
    }
}
