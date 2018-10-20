using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Sprites;
using MonoGame.Extended.TextureAtlases;
using TurnBaseGame.Entities.Configurations;

namespace TurnBaseGame.Entities
{
    /// <summary>
    /// An Entity with a default position and texture. Cannot be moved but can be drawn.
    /// </summary>
    public abstract class AEntity : IEntity
    {

        #region Member variables
        private Vector2 _worldPosition;
        protected Vector2 _previousWorldPosition;
        private Sprite _sprite;
        private bool _isActive;
        private bool _isVisible;
        private Statistic _stats;
        #endregion Member variables

        #region Properties
        public Vector2 WorldPosition
        {
            get { return _worldPosition; }
        }

        public int Id
        {
            get; private set;
        }
        #endregion Properties

        #region Constructor

        /// <summary>
        /// Constructor of a basic Entity.
        /// </summary>
        /// <param name="worldPosition">The world position</param>
        /// <param name="texture">The default sprite</param>
        protected AEntity(int id, Vector2 worldPosition, Texture2D texture)
        {
            _sprite = new Sprite(texture);
            _sprite.Origin = new Vector2(0, 0);
            BaseLoading(id, worldPosition);
        }

        protected AEntity(int id, Vector2 worldPosition, TextureRegion2D texture)
        {
            _sprite = new Sprite(texture);
            _sprite.Origin = new Vector2(0, 0);
            BaseLoading(id, worldPosition);
        }
        #endregion Constructor

        #region Public methods

        /// <summary>
        /// Change the visibility of the current Entity. An invisible Entity will still be updated but not displayed.
        /// </summary>
        /// <param name="visibility">New Entity visibility.</param>
        public void SetVisibility(bool visibility)
        {
            _isVisible = visibility;
        }

        /// <summary>
        /// Change the status of the current Entity. An inactive Entity won't be drawn and updated.
        /// </summary>
        /// <param name="active">New Entity status.</param>
        public void SetActive(bool active)
        {
            _isActive = active;
        }

        /// <summary>
        /// Change the current entity to a new position.
        /// </summary>
        /// <param name="newPosition">The new position of the current entity.</param>
        public void SetWorldPosition(Vector2 newPosition)
        {
            _previousWorldPosition = _worldPosition;
            _worldPosition = newPosition;
            _sprite.Position = _worldPosition;
        }

        /// <summary>
        /// Change the current entity position to a tile system position.
        /// </summary>
        /// <param name="tileX">The new X position</param>
        /// <param name="tileY">The new Y position</param>
        public void SetTilePosition(int tileX, int tileY)
        {
            SetWorldPosition(Helpers.GraphicHelper.ConvertTileCoordinateToGraphic(tileX, tileY));
        }

        /// <summary>
        /// Render the current Entity on a given SpriteBatch.
        /// </summary>
        /// <param name="spriteBatch">The SpriteBatch that will draw the Entity.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            if (_isVisible && _isActive)
            {
                _sprite.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Update the physics of the current Entity. Does nothing in this abstract implementation.
        /// </summary>
        public virtual void Update(double totalSeconds) { }

        /// <summary>
        /// Get the statistics of the current entity
        /// </summary>
        /// <returns>The statistics</returns>
        public Statistic GetStatistics()
        {
            return _stats;
        }

        /// <summary>
        /// Destroy the entity and hide it from being rendered
        /// </summary>
        public virtual void Destroy()
        {
            SetActive(false);
            SetVisibility(false);
            _worldPosition = Vector2.Zero;
            Datas.GameDatas.AllEntities.Remove(Id);
        }



        #endregion Public methods

        #region Private methods

        private void BaseLoading(int id, Vector2 worldPosition)
        {
            Id = id;
            SetWorldPosition(worldPosition);
            _previousWorldPosition = _worldPosition;
            SetVisibility(true);
            SetActive(true);
        }

        #endregion Private methods

        #region Static methods

        /// <summary>
        /// Overload the default == operator to test two Entity
        /// </summary>
        /// <param name="c1">Entity 1</param>
        /// <param name="c2">Entity 2</param>
        /// <returns>True if both entity are equals or false if they aren't. Two entities can be similar if they are both null.</returns>
        public static bool operator ==(AEntity c1, AEntity c2)
        {
            if (((object)c1 != null && (object)c2 != null) ||
               ((object)c1 == null && (object)c2 == null))
            {
                return c1.Id == c2.Id;
            }
            return false;
        }

        /// <summary>
        /// Overload the default != operator to test two Entity
        /// </summary>
        /// <param name="c1">Entity 1</param>
        /// <param name="c2">Entity 2</param>
        /// <returns>True if both entity are non equals or false if they aren't. Two entities cannot be similar if they are both null.</returns>
        public static bool operator !=(AEntity c1, AEntity c2)
        {
            return !(c1 == c2);
        }
        #endregion Static methods
    }
}
