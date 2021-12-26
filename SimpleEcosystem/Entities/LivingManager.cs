using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    class LivingManager : IGameEntity
    {
        public int DrawOrder { get; set; }

        private readonly EntityManager _entityManager;

        private Texture2D _spriteSheet;

        public Food _food;

        public LivingManager(EntityManager entityManager, Texture2D spriteSheet)
        {
            _entityManager = entityManager;
            _spriteSheet = spriteSheet;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
        }

        public void Update(GameTime gameTime)
        {
            foreach (Living _living in _entityManager.GetEntitiesOfType<Living>())
            {
                if(_living.Health <= 0)
                {
                    if (_living is Animal)
                    {
                        _food = new Meat(_spriteSheet, _living.Position);
                        _entityManager.AddEntity(_food);
                    }
                    //_living.Energy--;
                    _entityManager.RemoveEntity(_living);
                    
                }
            }
        }
    }
}
