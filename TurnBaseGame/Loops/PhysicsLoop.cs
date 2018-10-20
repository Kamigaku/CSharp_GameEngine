using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TurnBaseGame.Datas;
using TurnBaseGame.Entities;
using TurnBaseGame.Logging;

namespace TurnBaseGame.Loops
{
    public class PhysicsLoop : ALoop
    {

        #region Member variables
        private readonly Task _logicThread;
        private readonly CancellationTokenSource _cancellationToken;
        #endregion Member variables

        public PhysicsLoop(int refreshingRate) : base(refreshingRate)
        {
            _cancellationToken = new CancellationTokenSource();
            _logicThread = new Task(() =>
            {
                Update();
            }, _cancellationToken.Token);
        }

        #region Public methods
        public override void Initialize()
        {
            _logicThread.Start();
        }
        public override void Update()
        {
            GameTime gameTime = new GameTime();
            Logger.Log(Logger.LogLevel.DEBUG, "Starting PhysicsLoop thread");
            while (true)
            {
                DateTime startTime = DateTime.Now;

                // Update la camera ici
                foreach(AEntity entity in GameDatas.AllEntities.Values)
                {
                    entity.Update(gameTime.ElapsedGameTime.TotalSeconds);
                }
                
                Thread.Sleep(1000 / RefreshingRate);
                DateTime endTime = DateTime.Now;
                TimeSpan timeSpend = endTime - startTime;
                gameTime.ElapsedGameTime = timeSpend;
                gameTime.TotalGameTime.Add(timeSpend);
                Logger.Log(Logger.LogLevel.DEBUG, "Updating PhysicsLoop took " + gameTime.ElapsedGameTime.Milliseconds + "ms.");
            }
            Logger.Log(Logger.LogLevel.DEBUG, "End PhysicsLoop thread");
        }

        /// <summary>
        /// Stop the physics loop
        /// </summary>
        public void Stop()
        {
            Logger.Log(Logger.LogLevel.DEBUG, "Stopping PhysicsLoop thread.");
            _cancellationToken.Cancel();
            Logger.Log(Logger.LogLevel.DEBUG, "PhysicsLoop thread has stopped.");
        }
        #endregion Public methods

    }
}
