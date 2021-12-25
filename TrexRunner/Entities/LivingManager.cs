using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public class LivingManager : IGameEntity
    {
        public int DrawOrder { get; set; }

        public Random _random;

        public const int PLANT_SEED_RADIUS = 50;

        public int PLANT_START_POS_X;
        public int PLANT_START_POS_Y;

        public Plant _plant;

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        public int i = 0;

        public LivingManager(EntityManager entityManager, Plant plant, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _plant = plant;
            _random = new Random();
            _spriteSheet = spriteSheet;
        }

        public void Initialize()
        {
            SpawnLiving();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (Living _plant in _entityManager.GetEntitiesOfType<Living>())
            {
                if (_plant.growth == 50)
                {
                    SpawnLiving();
                }
            }
        }

        private void SpawnLiving()
        {
            //create instance of living and add it to entityManager

            
            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _plant = new Plant(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y));
            _entityManager.AddEntity(_plant);
        }
    }
}
