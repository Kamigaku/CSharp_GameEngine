using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.TextureAtlases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Datas;

namespace TurnBaseGame.Entities.Implementations
{
    public class CollidableEntity : MobileEntity
    {

        #region Fields member
        private CircleF _boundingCircle;
        private Dictionary<int, CollidableEntity> _collideWith;
        #endregion Fields member

        #region Events
        private event EventHandler<CollidableEntity> OnCollisionExit;
        private event EventHandler<CollidableEntity> OnCollisionEnter;
        private event EventHandler<CollidableEntity> OnCollisionStay;
        #endregion Events

        #region Constructor
        /// <summary>
        /// Create an Entity that is mobile
        /// </summary>
        /// <param name="worldPosition">The world position of the Entity</param>
        /// <param name="texture">The main sprite of the Entity</param>
        /// <param name="speed">The speed of the Entity</param>
        /// <param name="detectionRadius">Detection radius of the enemy</param>
        public CollidableEntity(int id, Vector2 worldPosition, Texture2D texture, int speed, int detectionRadius)
            : base(id, worldPosition, texture, speed)
        {
            BaseLoading(detectionRadius);
        }

        /// <summary>
        /// Create an Entity that is mobile
        /// </summary>
        /// <param name="worldPosition">The world position of the Entity</param>
        /// <param name="texture">The main sprite of the Entity</param>
        /// <param name="speed">The speed of the Entity</param>
        /// <param name="detectionRadius">Detection radius of the enemy</param>
        public CollidableEntity(int id, Vector2 worldPosition, TextureRegion2D texture, int speed, int detectionRadius)
            : base(id, worldPosition, texture, speed)
        {
            BaseLoading(detectionRadius);
        }
        #endregion Constructor

        #region Public methods
        public override void Update(double totalSeconds)
        {
            base.Update(totalSeconds);
            #region Collision update
            if (TranslationVector != Vector2.Zero)
            {
                _boundingCircle.Center = new Point2(WorldPosition.X, WorldPosition.Y);
            }
            foreach (AEntity entity in GameDatas.AllEntities.Values)
            {
                if(entity is CollidableEntity && this != entity)
                {
                    if (_boundingCircle.Intersects(((CollidableEntity)entity)._boundingCircle)) {
                        if (!_collideWith.ContainsKey(entity.Id))
                        {
                            ((CollidableEntity)entity).OnCollisionEnter?.Invoke(null, this);
                            OnCollisionEnter?.Invoke(null, (CollidableEntity)entity);
                        }
                        else
                        {
                            ((CollidableEntity)entity).OnCollisionStay?.Invoke(null, this);
                            OnCollisionStay?.Invoke(null, (CollidableEntity)entity);
                        }
                    }
                    else
                    {
                        ((CollidableEntity)entity).OnCollisionExit?.Invoke(null, this);
                        OnCollisionExit?.Invoke(null, (CollidableEntity)entity);
                    }
                }
            }
            #endregion Collision update
        }
        #endregion Public methods

        #region Private methods

        private void BaseLoading(int detectionRadius)
        {
            _boundingCircle = new CircleF(WorldPosition, detectionRadius * GameSettings.TileHeight);
            _collideWith = new Dictionary<int, CollidableEntity>();
            OnCollisionEnter += OnEntityCollidedEnter;
            OnCollisionExit += OnEntityCollidedExit;
            OnCollisionStay += OnEntityCollidedStay;
        }

        #region Events callbacks
        /// <summary>
        /// Method fired when an Entity collide with another one
        /// </summary>
        /// <param name="sender">Always null</param>
        /// <param name="e">The entity who stops colliding</param>
        private void OnEntityCollidedEnter(object sender, CollidableEntity e)
        {
            Logging.Logger.Log(Logging.Logger.LogLevel.DEBUG, "Intersect !");
            SetWorldPosition(_previousWorldPosition);
            _previousWorldPosition = WorldPosition;
            _collideWith.Add(e.Id, e);
        }

        /// <summary>
        /// Method fired when an Entity stay in collision with another one
        /// </summary>
        /// <param name="sender">Always null</param>
        /// <param name="e">The entity who stops colliding</param>
        private void OnEntityCollidedStay(object sender, CollidableEntity e)
        {
            SetWorldPosition(_previousWorldPosition);
            _previousWorldPosition = WorldPosition;
        }

        /// <summary>
        /// Method fired when an Entity stop colliding with another one
        /// </summary>
        /// <param name="sender">Always null</param>
        /// <param name="e">The entity who stops colliding</param>
        private void OnEntityCollidedExit(object sender, CollidableEntity e)
        {
            _collideWith.Remove(e.Id);
        }
        #endregion Events callbacks

        #endregion Private methods

    }
}
