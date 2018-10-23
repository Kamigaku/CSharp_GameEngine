using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.ViewportAdapters;
using TurnBaseGame.Loops;
using TurnBaseGame.Datas;
using TurnBaseGame.Cameras;
using TurnBaseGame.Levels;
using TurnBaseGame.Entities.Implementations;
using TurnBaseGame.Logging;

namespace TurnBaseGame.Screens
{

    public class LevelScreen : Game
    {

        #region Private variables
        private readonly GraphicsDeviceManager _graphics;
        private readonly BoxingViewportAdapter _adapter;
        private readonly PhysicsLoop _physicLoop;
        private readonly GraphicsLoop _graphicsLoop;
        private readonly ILevel _level;
        #endregion Private variables

        #region Constructor

        /// <summary>
        /// A gaming screen which consists of a single Camera and multiple entities
        /// </summary>
        public LevelScreen()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.SynchronizeWithVerticalRetrace = false;
            _graphics.PreparingDeviceSettings += (sender, e) =>
            {
                e.GraphicsDeviceInformation.PresentationParameters.PresentationInterval = PresentInterval.Immediate;
            };
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            GameDatas.AssetManager = Content;

            // Setting properties
            IsMouseVisible = true;
            //Window.Position = Point.Zero;


            _adapter = new BoxingViewportAdapter(Window, GraphicsDevice,
                                                 GameSettings.Width, GameSettings.Height);
            GameDatas.MainCamera = new ControllableCamera2D(_adapter, 100);

            // Launch the GameLogic thread
            _physicLoop = new PhysicsLoop(GameSettings.PhysicRefreshingRate);
            //_graphicsLoop = new GraphicsLoop(GameSettings.GraphicRefreshingRate, this);
            _graphicsLoop = new GraphicsLoop(0, this);

            _level = new ALevel("Content/Map/map_test.json");
        }

        #endregion Constructor

        #region Overrided methods

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            Console.WriteLine("Initialize");            
            _graphicsLoop.Initialize();
            _physicLoop.Initialize();

            // Later on that will be done by a Level Instance
            int id = 0;
            GameDatas.AllEntities.Add(id, new CollidableEntity(id, Vector2.Zero, Content.Load<Texture2D>("Graphics\\player"), 60, 2));
            GameDatas.MainEntity = GameDatas.AllEntities[id] as MobileEntity;
            id++;
            GameDatas.CharacterFreeModeController.ChangeState(true);
            GameDatas.CharacterBattleModeController.ChangeState(true);

            GameDatas.AllEntities.Add(id, new CollidableEntity(id++, Helpers.GraphicHelper.ConvertTileCoordinateToGraphic(3, 3),
                                                    Content.Load<Texture2D>("Graphics\\enemy"), 60, 2));
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            base.LoadContent();
            Console.WriteLine("LoadContent");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            base.UnloadContent();
            Console.WriteLine("UnloadContent");
            _physicLoop.Stop();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameDatas.KeyboardListener.Update();
            ((ControllableCamera2D)GameDatas.MainCamera).Update(gameTime);
            _graphicsLoop.Update();
            Logger.Log(Logger.LogLevel.DEBUG, "Updating GraphicsLoop took " + gameTime.ElapsedGameTime.Milliseconds + "ms.");
        }

        #endregion Overrided methods

        #region Private methods

        #endregion Private methods

    }
}
