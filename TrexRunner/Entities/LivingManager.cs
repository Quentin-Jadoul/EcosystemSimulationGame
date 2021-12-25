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

        public List<Vector2> animalPos = new List<Vector2>();
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
            for (int i = 0 ; i <2 ; i++)
            {
                SpawnAnimal();
                SpawnPlant();
            }
            

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            animalPos.Clear();
            plantPos.Clear();

            foreach (Living _living in _entityManager.GetEntitiesOfType<Plant>())
            {
                plantPos.Add(_living.Position);
                if (_living.growth == 2000)
                {
                    SpawnPlant();
                }
            }

            foreach (Living _living in _entityManager.GetEntitiesOfType<Animal>())
            {
                animalPos.Add(_living.Position);
            }

            for (int i = 0; i < animalPos.Count - 1; i++)
            {
                for (int j = i + 1; j < animalPos.Count; j++)
                {
                    // Use list[i] and list[j]
                    if (i != j)
                    {
                        //Debug.WriteLine(Vector2.Distance(new Vector2(10,10), new Vector2(19,20)));
                        if (Vector2.Distance(animalPos[i], animalPos[j]) < 100 & animalPos.Count < 30)
                        {
                            SpawnAnimal();
                        }
                    }
                }
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
