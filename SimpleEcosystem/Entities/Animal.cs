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

        private const int STAT_TEXTURE_COORDS_X = 213;

        
        private const int STAT_SPRITE_HEIGHT = 3;

        private int HEALTH_SPRITE_WIDTH = 30;
        private int ENERGY_SPRITE_WIDTH = 30;
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
        public Sprite _energySprite { get; set; }
        public Sprite _healthSprite { get; set; }

        public bool _carnivorous { get; set; }

        private Texture2D _spriteSheet;

        public Animal(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(position, entityManager)
        {
            _carnivorous = false;
            _spriteSheet = spriteSheet;
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);

            _energySprite = new Sprite(spriteSheet, STAT_TEXTURE_COORDS_X, ENERGY_TEXTURE_COORDS_Y, ENERGY_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
            _healthSprite = new Sprite(spriteSheet, STAT_TEXTURE_COORDS_X, HEALTH_TEXTURE_COORDS_Y, HEALTH_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
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
            if (_carnivorous)
            {
                _energySprite.Draw(spriteBatch, new Vector2(Position.X + 15, Position.Y + 48));
                _healthSprite.Draw(spriteBatch, new Vector2(Position.X + 15, Position.Y + 54));
            }
            else
            {
                _energySprite.Draw(spriteBatch, new Vector2(Position.X +5, Position.Y + 42));
                _healthSprite.Draw(spriteBatch, new Vector2(Position.X +5, Position.Y + 48));
            }
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            DIGESTION_TIME++;
            if (DIGESTION_TIME > DIGESTION_TIME_MAX)
            {
                DIGESTION_TIME = 0;
            }
            UpdateHUD();

            CheckForFood();

            MoveAnimal();
        }
        private void UpdateHUD()
        {
            HEALTH_SPRITE_WIDTH = 3 * Health / 100;
            _healthSprite = new Sprite(_spriteSheet, STAT_TEXTURE_COORDS_X, HEALTH_TEXTURE_COORDS_Y, HEALTH_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
            ENERGY_SPRITE_WIDTH = 3 * Energy / 100;
            _energySprite = new Sprite(_spriteSheet, STAT_TEXTURE_COORDS_X, ENERGY_TEXTURE_COORDS_Y, ENERGY_SPRITE_WIDTH, STAT_SPRITE_HEIGHT);
        }
        public virtual void CheckForFood()
        {
            foreach (Plant _living in EntityManager.GetEntitiesOfType<Plant>())
            {
                if (Vector2.Distance(_living.Position, Position) < ACTION_RADIUS)
                {
                    Energy += 1000;
                    EntityManager.RemoveEntity(_living);
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
