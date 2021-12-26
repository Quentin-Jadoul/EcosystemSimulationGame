using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public Food _food;

        public List<Vector2> plantPos = new List<Vector2>();

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        public LivingManager(EntityManager entityManager, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _random = new Random();
            _spriteSheet = spriteSheet;
        }

        public void Initialize()
        {
            for (int i = 0 ; i <5 ; i++)
            {
                SpawnAnimal();
            }
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
            plantPos.Clear();

            foreach (Living _living in _entityManager.GetEntitiesOfType<Plant>())
            {
                plantPos.Add(_living.Position);
                if (_living.growth == 101)
                {
                    SpawnPlant();
                }
            }

            foreach (Living _living in _entityManager.GetEntitiesOfType<Animal>())
            {
                if (_living.digestion == 100)
                {
                    SpawnPoop(_living);
                }

                foreach (Living _living2 in _entityManager.GetEntitiesOfType<Animal>())
                {
                    if (Vector2.Distance(_living.Position, _living2.Position) < 100 & (_entityManager._entities.Count < 30) &  (_living.gender != _living2.gender))
                    {
                        SpawnAnimal();
                    }
                }
            }
        }

        private void SpawnPoop(Living _living)
        {
            //create instance of living and add it to entityManager
            _food = new Poop(_spriteSheet, _living.Position);
            _entityManager.AddEntity(_food);
        }
        private void SpawnPlant()
        {
            //create instance of living and add it to entityManager
            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Plant(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y), _entityManager);
            _entityManager.AddEntity(_living);
        }

        private void SpawnAnimal()
        {
            //create instance of living and add it to entityManager


            PLANT_START_POS_X = _random.Next(0, 1680 - 24);
            PLANT_START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Animal(_spriteSheet, new Vector2(PLANT_START_POS_X, PLANT_START_POS_Y), _entityManager);
            _entityManager.AddEntity(_living);
        }
    }
}
