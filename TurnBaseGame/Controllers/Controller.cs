using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame.Controllers
{
    public class Controller
    {

        #region Events
        public event EventHandler<Keys> OnKeyDown;
        public event EventHandler<Keys> OnKeyUp;
        public event EventHandler<MouseState> OnMouseLeftButtonUp;
        public event EventHandler<MouseState> OnMouseLeftButtonDown;
        public event EventHandler<MouseState> OnMouseRightButtonUp;
        public event EventHandler<MouseState> OnMouseRightButtonDown;
        public event EventHandler<MouseState> OnMouseWheelUp;
        public event EventHandler<MouseState> OnMouseWheelDown;
        #endregion Events

        #region Field variables
        private Keys[] _pressedKeys;
        private ButtonState _previousLeftButtonState;
        private ButtonState _previousRightButtonState;
        private int _previousScrollValue;
        #endregion Field variables

        #region Constructor
        public Controller()
        {
            _pressedKeys = new Keys[0];
            _previousLeftButtonState = ButtonState.Released;
            _previousRightButtonState = ButtonState.Released;
            _previousScrollValue = Mouse.GetState().ScrollWheelValue;
        }
        #endregion Constructor

        #region Public methods
        public void Update()
        {
            #region Keybaord
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] keyPressed = keyboardState.GetPressedKeys();
            IEnumerable<Keys> keyJustPressed = keyPressed.Where(key => !_pressedKeys.Any(k => k == key));

            foreach (Keys key in keyJustPressed)
            {
                OnKeyDown(null, key);
            }

            IEnumerable<Keys> keyJustUpped = _pressedKeys.Where(key => !keyPressed.Any(k => k == key));

            foreach (Keys key in keyJustUpped)
            {
                OnKeyUp(null, key);
            }
            _pressedKeys = keyPressed;
            #endregion Keybaord

            #region Mouse
            MouseState mouseState = Mouse.GetState();
            if (mouseState.LeftButton != _previousLeftButtonState)
            {
                _previousLeftButtonState = mouseState.LeftButton;
                if (_previousLeftButtonState == ButtonState.Pressed)
                {
                    OnMouseLeftButtonDown(this, mouseState);
                }
                else
                {
                    OnMouseLeftButtonUp(this, mouseState);
                }
            }

            if (mouseState.RightButton != _previousRightButtonState)
            {
                _previousRightButtonState = mouseState.RightButton;
                if (_previousRightButtonState == ButtonState.Pressed)
                {
                    OnMouseRightButtonDown(this, mouseState);
                }
                else
                {
                    OnMouseRightButtonUp(this, mouseState);
                }
            }

            if(mouseState.ScrollWheelValue != _previousScrollValue)
            {
                if(mouseState.ScrollWheelValue < _previousScrollValue)
                {
                    OnMouseWheelUp?.Invoke(this, mouseState);
                }
                else
                {
                    OnMouseWheelDown?.Invoke(this, mouseState);
                }
                _previousScrollValue = mouseState.ScrollWheelValue;
            }
            #endregion Mouse
        }
        #endregion Public methods

    }
}
