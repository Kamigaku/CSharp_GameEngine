using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnBaseGame.Entities.Configurations;

namespace TurnBaseGame.Entities
{
    public interface IEntity
    {

        void Draw(SpriteBatch spriteBatch);
        void Update(double totalSeconds);
        void Destroy();
        void SetWorldPosition(Vector2 worldPosition);
        void SetTilePosition(int tileX, int tileY);
        Statistic GetStatistics();

    }
}
