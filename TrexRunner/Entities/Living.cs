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

        public Vector2 Position { get; set; }
        protected Living(Vector2 position)
        {
            Position = position;
        }

        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);

        public void Update(GameTime gameTime)
        {
            growth++;
            if (growth > 50)
            {
                growth = 0;
            }

        }
    }
}
