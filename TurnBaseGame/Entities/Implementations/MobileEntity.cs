using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.TextureAtlases;

namespace TurnBaseGame.Entities.Implementations
{
    public class MobileEntity : AEntity
    {

        #region Class fields
        private Vector2 _translationVector;
        private int _speed;
        #endregion Class fields

        #region Properties
        public Vector2 TranslationVector
        {
            get { return _translationVector; }
        }
        #endregion Properties

        #region Constructor
        /// <summary>
        /// Create an Entity that is mobile
        /// </summary>
        /// <param name="worldPosition">The world position of the Entity</param>
        /// <param name="texture">The main sprite of the Entity</param>
        /// <param name="speed">The speed of the Entity</param>
        public MobileEntity(int id, Vector2 worldPosition, Texture2D texture, int speed) : base(id, worldPosition, texture)
        {
            BaseLoading(speed);
        }

        /// <summary>
        /// Create an Entity that is mobile
        /// </summary>
        /// <param name="worldPosition">The world position of the Entity</param>
        /// <param name="texture">The main sprite of the Entity</param>
        /// <param name="speed">The speed of the Entity</param>
        public MobileEntity(int id, Vector2 worldPosition, TextureRegion2D texture, int speed) : base(id, worldPosition, texture)
        {
            BaseLoading(speed);
        }
        #endregion Constructor

        #region Public methods

        public void SetTranslationVector(Vector2 translationVector)
        {
            _translationVector = translationVector * _speed;
        }

        public override void Update(double totalSeconds)
        {
            if (_translationVector != Vector2.Zero)
            {
                // cela signifie qu'il se déplace à 1px / seconds si speed n'était pas appliqué dans SetTranslation
                SetWorldPosition(new Vector2((float)(WorldPosition.X + (_translationVector.X * totalSeconds)),
                                             (float)(WorldPosition.Y + (_translationVector.Y * totalSeconds))));
            }
        }
        #endregion Public methods

        #region Private methods
        private void BaseLoading(int speed)
        {
            _speed = speed;
        }
        #endregion Private methods

    }
}
