using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    class AnimalManager : IGameEntity
    {
        public int DrawOrder { get; set; }

        public Random _random;

        public Living _living;
        public Food _food;

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        private int START_POS_X;
        private int START_POS_Y;

        public AnimalManager(EntityManager entityManager, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _random = new Random();
            _spriteSheet = spriteSheet;
        }

        public void Initialize()
        {
            for (int i = 0; i < 5; i++)
            {
                SpawnAnimal();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach (Animal _animal in _entityManager.GetEntitiesOfType<Animal>())
            {
                if (_animal.DIGESTION_TIME_MAX == _animal.DIGESTION_TIME)
                {
                    SpawnPoop(_animal);
                }

                if (_animal.PREGNANT)
                {
                    _animal.GESTATION_TIME++;
                    if (_animal.GESTATION_TIME == _animal.GESTATION_TIME_MAX)
                    {
                        _animal.GESTATION_TIME = 0;
                        _animal.PREGNANT = false;
                        GiveBirth(_animal.Position);
                    }
                }

                foreach (Animal _animal2 in _entityManager.GetEntitiesOfType<Animal>())
                {
                    if (Vector2.Distance(_animal.Position, _animal2.Position) < 100 & (_entityManager._entities.Count < 30) & (_animal.gender != _animal2.gender))
                    {
                        if (_animal.gender == 1)
                        {
                            _animal.PREGNANT = true;
                        }
                        else if (_animal.gender == 1)
                        {
                            _animal2.PREGNANT = true;
                        }
                    }
                }
            }
        }

        private void SpawnPoop(Animal _animal)
        {
            //create instance of food and add it to entityManager
            _food = new Poop(_spriteSheet, _animal.Position);
            _entityManager.AddEntity(_food);
        }

        private void GiveBirth(Vector2 position)
        {
            _living = new Animal(_spriteSheet, position, _entityManager);
            _entityManager.AddEntity(_living);
        }
        private void SpawnAnimal()
        {
            //create instance of animal and add it to entityManager


            START_POS_X = _random.Next(0, 1680 - 24);
            START_POS_Y = _random.Next(0, 1000 - 24);
            _living = new Animal(_spriteSheet, new Vector2(START_POS_X, START_POS_Y), _entityManager);
            _entityManager.AddEntity(_living);
        }
    }
}
