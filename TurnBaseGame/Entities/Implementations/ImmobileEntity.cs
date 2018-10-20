using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.TextureAtlases;

namespace TurnBaseGame.Entities.Implementations
{
    public class ImmobileEntity : AEntity
    {

        #region Constructor
        /// <summary>
        /// Create an immobile entity non-collidable
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="position">The world position</param>
        /// <param name="texture">The 2D texture</param>
        public ImmobileEntity(int id, Vector2 position, Texture2D texture) : base(id, position, texture)
        {
        }

        /// <summary>
        /// Create an immobile entity non-collidable
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="position">The world position</param>
        /// <param name="texture">The 2D texture</param>
        public ImmobileEntity(int id, Vector2 position, TextureRegion2D texture) : base(id, position, texture)
        {
        }
        #endregion Constructor

    }
}
