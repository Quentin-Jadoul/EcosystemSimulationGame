using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    class PlantManager : IGameEntity
    {
        public int DrawOrder { get; set; }

        public Random _random;

        public const int PLANT_SEED_RADIUS = 50;

        public int PLANT_START_POS_X;
        public int PLANT_START_POS_Y;

        public Living _living;

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        public PlantManager(EntityManager entityManager, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _random = new Random();
            _spriteSheet = spriteSheet;
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnPlant();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (Living _living in _entityManager.GetEntitiesOfType<Plant>())
            {
                if (_living.growth == 101)
                {
                    SpawnPlant();
                }
            }
        }
        private void SpawnPlant()
        {
            //create instance of living and add it to entityManager
            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Plant(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y), _entityManager);
            _entityManager.AddEntity(_living);
        }
    }
}
