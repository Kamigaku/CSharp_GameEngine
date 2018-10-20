using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using TurnBaseGame.Datas;
using TurnBaseGame.Entities;
using TurnBaseGame.Logging;

namespace TurnBaseGame.Loops
{
    public class GraphicsLoop : ALoop
    {

        #region Member fields
        private readonly GraphicsDevice _graphicDevice;
        private SpriteBatch _spriteBatch;
        #endregion Member fields

        #region Consturctor
        /// <summary>
        /// Represent the Graphic loop that will render everything visual on screen.
        /// </summary>
        /// <param name="refreshingRate">The number of time the screen will refresh in a second. Can be set to less or equal than 0 for a non fixed timestamp</param>
        /// <param name="gameScreen">The game screen in which the graphic loop will render</param>
        public GraphicsLoop(int refreshingRate, Game gameScreen) : base(refreshingRate)
        {
            if (RefreshingRate > 0)
            {
                gameScreen.IsFixedTimeStep = true;
                gameScreen.TargetElapsedTime = TimeSpan.FromMilliseconds(1000d / RefreshingRate);
            }
            else
            {
                gameScreen.IsFixedTimeStep = false;
            }
            _graphicDevice = gameScreen.GraphicsDevice;

        }
        #endregion Constructor

        #region Public methods
        public override void Initialize()
        {
            _spriteBatch = new SpriteBatch(_graphicDevice);
        }

        public override void Update()
        {
            _graphicDevice.Clear(Color.CornflowerBlue);
            
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp,
                               blendState: BlendState.AlphaBlend, 
                               transformMatrix: GameDatas.MainCamera.GetViewMatrix());
            foreach(AEntity entity in GameDatas.AllEntities.Values)
            {
                entity.Draw(_spriteBatch);
            }
            _spriteBatch.End();
        }
        #endregion Public methods
        
    }
}
