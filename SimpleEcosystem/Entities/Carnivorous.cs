using EcosystemSimulation.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public class Carnivorous : Animal
    {
        private const int CARNIVOROUS_TEXTURE_COORDS_X = 21;
        private const int CARNIVOROUS_TEXTURE_COORDS_Y = 21;

        private const int CARNIVOROUS_SPRITE_WIDTH = 60;
        private const int CARNIVOROUS_SPRITE_HEIGHT = 45;

        public Carnivorous(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(spriteSheet, position, entityManager)
        {   
            _sprite = new Sprite(spriteSheet, CARNIVOROUS_TEXTURE_COORDS_X, CARNIVOROUS_TEXTURE_COORDS_Y, CARNIVOROUS_SPRITE_WIDTH, CARNIVOROUS_SPRITE_HEIGHT);
            _carnivorous = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            CheckForFood();
        }
        public override void CheckForFood()
        {
            foreach (Animal _animal in EntityManager.GetEntitiesOfType<Animal>())
            {
                if (Vector2.Distance(_animal.Position, Position) < ACTION_RADIUS & !_animal._carnivorous)
                {
                    _animal.Health -= 10;
                }
            }
            foreach (Meat _meat in EntityManager.GetEntitiesOfType<Meat>())
            {
                if (Vector2.Distance(_meat.Position, Position) < ACTION_RADIUS)
                {
                    Energy += 1000;
                    EntityManager.RemoveEntity(_meat);
                }
            }
        }
    }
}
