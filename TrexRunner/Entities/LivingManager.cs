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

        public Living _living;

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        public int i = 0;

        public LivingManager(EntityManager entityManager, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _random = new Random();
            _spriteSheet = spriteSheet;
        }

        public void Initialize()
        {
            for (int i = 0 ; i <30 ; i++)
            {
                SpawnAnimal();
            }
            

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (Living _living in _entityManager.GetEntitiesOfType<Plant>())
            {
                if (_living.growth == 50)
                {
                    SpawnPlant();
                }
            }

            foreach (Living _living in _entityManager.GetEntitiesOfType<Animal>())
            {
                
            }
        }

        private void MoveAnimal()
        {
            //_living.Position = new Vector2(_living.Position.X + _random.Next(-5, 6), _living.Position.Y + _random.Next(-5, 6));

        }
        private void SpawnPlant()
        {
            //create instance of living and add it to entityManager

            
            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Plant(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y));
            _entityManager.AddEntity(_living);
        }

        private void SpawnAnimal()
        {
            //create instance of living and add it to entityManager


            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Animal(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y));
            _entityManager.AddEntity(_living);
        }
    }
}
