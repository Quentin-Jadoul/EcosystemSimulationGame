using EcosystemSimulation.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public class Plant : Living
    {
        private const int TEXTURE_COORDS_X = 162;
        private const int TEXTURE_COORDS_Y = 42;

        private const int SPRITE_WIDTH = 24;
        private const int SPRITE_HEIGHT = 24;

        public int GROWTH_TIME_MAX = 1000;
        public int GROWTH_TIME;

        public const int PLANT_ROOT_RADIUS = 200;
        public const int PLANT_SEED_RADIUS = 200;

        public Vector2 _position;

        private Sprite _sprite;

        public Plant(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(position, entityManager)
        {
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, Position);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            GROWTH_TIME++;
            if (GROWTH_TIME > GROWTH_TIME_MAX)
            {
                GROWTH_TIME = 0;
            }

            CheckForFood();
        }
        private void CheckForFood()
        {
            foreach (Poop _poop in EntityManager.GetEntitiesOfType<Poop>())
            {
                if (Vector2.Distance(_poop.Position, Position) < PLANT_ROOT_RADIUS)
                {
                    EntityManager.RemoveEntity(_poop);
                }
            }
        }
    }
}
