using EcosystemSimulation.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public class Animal : Living
    {
        private const int TEXTURE_COORDS_X = 84;
        private const int TEXTURE_COORDS_Y = 30;

        private const int SPRITE_WIDTH = 39;
        private const int SPRITE_HEIGHT = 36;

        Random _random = new Random();

        public Vector2 NEXT_OBJECTIVE;

        private Sprite _sprite;

        public Animal(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(position, entityManager)
        {
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);
            NEXT_OBJECTIVE = new Vector2(_random.Next(0, 1680 - 39), _random.Next(0, 1000 - 36));
        }

        
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, Position);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            foreach (Plant _living in EntityManager.GetEntitiesOfType<Plant>())
            {
                if (Vector2.Distance(_living.Position,Position) < 100)
                {
                    EntityManager.RemoveEntity(_living);
                }
            }

            if (Vector2.Subtract(NEXT_OBJECTIVE, Position) != new Vector2(0,0))
            {
                if (NEXT_OBJECTIVE.X - Position.X > 0)
                {
                    Position = new Vector2(Position.X +1, Position.Y);
                }
                else if (NEXT_OBJECTIVE.X - Position.X < 0)
                {
                    Position = new Vector2(Position.X - 1, Position.Y);
                }
                if (NEXT_OBJECTIVE.Y - Position.Y > 0)
                {
                    Position = new Vector2(Position.X, Position.Y + 1);
                }
                else if (NEXT_OBJECTIVE.Y - Position.Y < 0)
                {
                    Position = new Vector2(Position.X, Position.Y -1);
                }
            }
            else
            {
                NEXT_OBJECTIVE.X = _random.Next(0, 1680 - 39);
                NEXT_OBJECTIVE.Y = _random.Next(0, 1000 - 36);
                NEXT_OBJECTIVE = new Vector2(NEXT_OBJECTIVE.X, NEXT_OBJECTIVE.Y);
            }
        }

    }
}
