using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public abstract class Food : IGameEntity
    {
        public int DrawOrder { get; set; }

        public Vector2 Position { get; set; }
        protected Food(Vector2 position)
        {
            Position = position;
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public void Update(GameTime gameTime)
        {

        }

    }
}
