using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using MonoGame.Extended.Input.InputListeners;
using System;
using TurnBaseGame.Controllers;

namespace TurnBaseGame.Cameras
{
    public class ControllableCamera2D : Camera2D
    {

        #region Member fields
        private readonly int _speed;
        #endregion Member fields

        #region Properties
        public CameraController Controller
        {
            get; private set;
        }
        #endregion Properties

        #region Constructors
        /// <summary>
        /// Initialize a controllable camera via inputs.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device</param>
        /// <param name="speed">Pixels per seconds</param>
        public ControllableCamera2D(GraphicsDevice graphicsDevice, int speed) : base(graphicsDevice)
        {
            Controller = new CameraController(this);
            _speed = speed;
        }

        /// <summary>
        /// Initialize a controllable camera via inputs.
        /// </summary>
        /// <param name="viewportAdapter">Boxing viewport adapter</param>
        /// <param name="speed">Pixels per seconds</param>
        public ControllableCamera2D(ViewportAdapter viewportAdapter, int speed) : base(viewportAdapter)
        {
            Controller = new CameraController(this);
            _speed = speed;
        }
        #endregion Constructors

        #region Public methods
        public void Update(GameTime gameTime)
        {
            if (Controller.TranslationVector != Vector2.Zero)
            {
                Vector2 v = new Vector2(Controller.TranslationVector.X * (float)gameTime.ElapsedGameTime.TotalSeconds * _speed,
                                        Controller.TranslationVector.Y * (float)gameTime.ElapsedGameTime.TotalSeconds * _speed);
                Move(v);
            }
        }
        #endregion Public methods
    }
}
