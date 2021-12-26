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

        public int PLANT_START_POS_X;
        public int PLANT_START_POS_Y;

        Vector2 spawnAreaSize = new Vector2(1680 - 24, 1000 - 24);

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
                SpawnPlant(new Vector2(_random.Next(0, 1680 - 24), _random.Next(0, 1000 - 24)));
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (Plant _plant in _entityManager.GetEntitiesOfType<Plant>())
            {
                if (_plant.GROWTH_TIME == _plant.GROWTH_TIME_MAX)
                {
                    SpawnPlant(_plant.Position);
                }
            }
        }
        private void SpawnPlant(Vector2 motherPosition)
        {
            //create instance of living and add it to entityManager
            PLANT_START_POS_X = ((int)motherPosition.X) + _random.Next(-Plant.PLANT_SEED_RADIUS, Plant.PLANT_SEED_RADIUS);
            PLANT_START_POS_Y = ((int)motherPosition.Y) + _random.Next(-Plant.PLANT_SEED_RADIUS, Plant.PLANT_SEED_RADIUS);
            Vector2 spawnTryPosition = new Vector2(PLANT_START_POS_X,PLANT_START_POS_Y);
            _living = new Plant(_spriteSheet, Vector2.Clamp(spawnTryPosition, new Vector2(0, 0), spawnAreaSize), _entityManager);
            _entityManager.AddEntity(_living);
        }
    }
}
