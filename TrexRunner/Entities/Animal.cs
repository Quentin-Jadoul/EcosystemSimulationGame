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
        private const int HERBIVOROUS_TEXTURE_COORDS_X = 84;
        private const int HERBIVOROUS_TEXTURE_COORDS_Y = 30;

        private const int HERBIVOROUS_SPRITE_WIDTH = 39;
        private const int HERBIVOROUS_SPRITE_HEIGHT = 36;

        private const int STAT_TEXTURE_COORDS_X = 213;

        private const int STAT_SPRITE_WIDTH = 30;
        private const int STAT_SPRITE_HEIGHT = 3;

        private const int HEALTH_TEXTURE_COORDS_Y = 57;
        private const int ENERGY_TEXTURE_COORDS_Y = 51;

        public int DIGESTION_TIME = 0;
        public int DIGESTION_TIME_MAX = 500;
        public int GESTATION_TIME_MAX = 500;
        public int GESTATION_TIME;
        public bool PREGNANT;

        public const int VIEW_RADIUS = 300;
        public const int ACTION_RADIUS = 100;

        Random _random = new Random();

        public Vector2 NEXT_OBJECTIVE;

        public int gender { get; } //0 = male , 1 = female

        public Sprite _sprite { get; set; }
        public Sprite _energySprite;
        public Sprite _healthSprite;

        public bool _carnivorous { get; set; }

        public Animal(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(position, entityManager)
        {
            _carnivorous = false;
            _sprite = new Sprite(spriteSheet, HERBIVOROUS_TEXTURE_COORDS_X, HERBIVOROUS_TEXTURE_COORDS_Y, HERBIVOROUS_SPRITE_WIDTH, HERBIVOROUS_SPRITE_HEIGHT);
            

            _energySprite = new Sprite(spriteSheet, STAT_TEXTURE_COORDS_X, ENERGY_TEXTURE_COORDS_Y, STAT_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
            _healthSprite = new Sprite(spriteSheet, STAT_TEXTURE_COORDS_X, HEALTH_TEXTURE_COORDS_Y, STAT_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
            NEXT_OBJECTIVE = new Vector2(_random.Next(0, 1680 - 39), _random.Next(0, 1000 - 36));
            gender = _random.Next(0, 2);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (gender == 1)
            {
                _sprite.TintColor = Color.Pink;
            }
            else if (gender == 0)
            {
                _sprite.TintColor = Color.LightBlue;
            }
            _sprite.Draw(spriteBatch, Position);
            _energySprite.Draw(spriteBatch, new Vector2(Position.X,Position.Y + 42));
            _healthSprite.Draw(spriteBatch, new Vector2(Position.X,Position.Y + 48));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            DIGESTION_TIME++;
            if (DIGESTION_TIME > DIGESTION_TIME_MAX)
            {
                DIGESTION_TIME = 0;
            }

            CheckForFood();

            MoveAnimal();
        }
        private void CheckForFood()
        {
            if (_carnivorous)
            {
                foreach (Animal _animal in EntityManager.GetEntitiesOfType<Animal>())
                {
                    if (Vector2.Distance(_animal.Position, Position) < ACTION_RADIUS & !_animal._carnivorous)
                    {
                        EntityManager.RemoveEntity(_animal);
                    }
                }
            }
            else
            {
                foreach (Plant _living in EntityManager.GetEntitiesOfType<Plant>())
                {
                    if (Vector2.Distance(_living.Position, Position) < ACTION_RADIUS)
                    {
                        EntityManager.RemoveEntity(_living);
                    }
                }
            }
        }
        private void MoveAnimal()
        {
            if (Vector2.Subtract(NEXT_OBJECTIVE, Position) != new Vector2(0, 0))
            {
                if (NEXT_OBJECTIVE.X - Position.X > 0)
                {
                    Position = new Vector2(Position.X + 1, Position.Y);
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
                    Position = new Vector2(Position.X, Position.Y - 1);
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
