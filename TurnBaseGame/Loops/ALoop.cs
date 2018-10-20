using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnBaseGame.Loops
{
    public abstract class ALoop
    {

        #region Member variables
        private readonly int _refreshingRate;
        protected int RefreshingRate
        {
            get { return _refreshingRate; }
        }
        #endregion Member variables

        #region Constructor
        protected ALoop(int refreshingRate)
        {
            _refreshingRate = refreshingRate;
        }
        #endregion Constructor

        #region Overridable methods
        public abstract void Initialize();
        public abstract void Update();
        #endregion Overridable methods

    }
}
