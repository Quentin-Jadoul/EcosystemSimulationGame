using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public abstract class Living : IGameEntity
    {

        public int DrawOrder { get; set; }
        public Vector2 Position { get; set; }
        public EntityManager EntityManager { get; }

        public int Health { get; set; }
        public int Energy { get; set; }

        protected Living(Vector2 position, EntityManager entityManager)
        {
            Position = position;
            EntityManager = entityManager;
            Health = 1000;
            Energy = 1000;
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public virtual void Update(GameTime gameTime)
        {
            if (Energy > 0){
                Energy--;
            }
            else if (Energy == 0)
            {
                Health--;
            }
            
        }

        public void Test()
        {

        }
    }
}
