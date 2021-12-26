using EcosystemSimulation.Entities;
using EcosystemSimulation.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TrexRunner
{
    public class EcosystemSimulationGame : Game
    {
        private const string ASSET_NAME_SPRITESHEET = "SpriteBatch";

        public const int WINDOW_WIDTH = 1680;
        public const int WINDOW_HEIGHT = 1000;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Texture2D _spriteSheetTexture;
        private PlantManager _plantManager;
        private AnimalManager _animalManager;

        private EntityManager _entityManager;
        public EcosystemSimulationGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _entityManager = new EntityManager();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            base.Initialize();

            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteSheetTexture = Content.Load<Texture2D>(ASSET_NAME_SPRITESHEET);

            _animalManager = new AnimalManager(_entityManager, _spriteSheetTexture);
            _animalManager.Initialize();

            _entityManager.AddEntity(_animalManager);

            _plantManager = new PlantManager(_entityManager, _spriteSheetTexture);
            _plantManager.Initialize();

            _entityManager.AddEntity(_plantManager);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            _entityManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);

            _spriteBatch.Begin();

            _entityManager.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
