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

        public int growth = 0;
        public int digestion = 0;

        private Random _random = new Random();
        public Vector2 Position { get; set; }
        public EntityManager EntityManager { get; }

        protected Living(Vector2 position, EntityManager entityManager)
        {
            Position = position;
            EntityManager = entityManager;
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public virtual void Update(GameTime gameTime)
        {
            digestion++;
            if (digestion > 100)
            {
                digestion = 0;
            }
            growth++;
            if (growth > 100)
            {
                growth = 0;
            }

        }
    }
}
