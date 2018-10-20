using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using TurnBaseGame.Datas;
using MonoGame.Extended;
using TurnBaseGame.Cameras;

namespace TurnBaseGame.Controllers
{
    public class CameraController
    {
        #region Member fields
        private bool _isActive;
        private readonly ControllableCamera2D _assignedCamera;
        private Vector2 _translationVector;
        #endregion Member fields

        #region Propeties
        public Vector2 TranslationVector
        {
            get { return _translationVector; }
        }
        #endregion Properties

        #region Constructor
        public CameraController(ControllableCamera2D assignedCamera)
        {
            _assignedCamera = assignedCamera;
            _translationVector = Vector2.Zero;
            ChangeState(true);
        }
        #endregion Constructor

        #region Public methods
        public void ChangeState(bool newState)
        {
            GameDatas.KeyboardListener.OnKeyDown -= OnKeyboardDown;
            GameDatas.KeyboardListener.OnKeyUp -= OnKeyboardUp;
            GameDatas.KeyboardListener.OnMouseWheelDown -= OnMouseWheelDown;
            GameDatas.KeyboardListener.OnMouseWheelUp -= OnMouseWheelUp;
            _isActive = newState && _assignedCamera != null;
            if (_isActive)
            {
                GameDatas.KeyboardListener.OnKeyDown += OnKeyboardDown;
                GameDatas.KeyboardListener.OnKeyUp += OnKeyboardUp;
                GameDatas.KeyboardListener.OnMouseWheelDown += OnMouseWheelDown;
                GameDatas.KeyboardListener.OnMouseWheelUp += OnMouseWheelUp;
            }
        }
        #endregion Public methods

        #region Private methods
        private void OnKeyboardUp(object sender, Keys e)
        {
            switch (e)
            {
                case Keys.Up:
                    _translationVector.Y += 1;
                    break;
                case Keys.Down:
                    _translationVector.Y -= 1;
                    break;
                case Keys.Left:
                    _translationVector.X += 1;
                    break;
                case Keys.Right:
                    _translationVector.X -= 1;
                    break;
            }
        }

        private void OnKeyboardDown(object sender, Keys e)
        {
            switch (e)
            {
                case Keys.Up:
                    _translationVector.Y -= 1;
                    break;
                case Keys.Down:
                    _translationVector.Y += 1;
                    break;
                case Keys.Left:
                    _translationVector.X -= 1;
                    break;
                case Keys.Right:
                    _translationVector.X += 1;
                    break;
            }
        }

        private void OnMouseWheelUp(object sender, MouseState e)
        {
            if (_assignedCamera.Zoom - 1 > _assignedCamera.MinimumZoom)
            {
                _assignedCamera.Zoom -= 1;
            }
        }

        private void OnMouseWheelDown(object sender, MouseState e)
        {
            if (_assignedCamera.Zoom + 1 < _assignedCamera.MaximumZoom)
            {
                _assignedCamera.Zoom += 1;
            }
        }
        #endregion Private methods
    }
}
