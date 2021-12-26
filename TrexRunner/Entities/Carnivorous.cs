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

        private Sprite _sprite;

        public Carnivorous(Texture2D spriteSheet, Vector2 position, EntityManager entityManager) : base(spriteSheet, position, entityManager)
        {   
            _sprite = new Sprite(spriteSheet, CARNIVOROUS_TEXTURE_COORDS_X, CARNIVOROUS_TEXTURE_COORDS_Y, CARNIVOROUS_SPRITE_WIDTH, CARNIVOROUS_SPRITE_HEIGHT);
        }

        public override void Update(GameTime gameTime)
        {
            this._carnivorous = true;
            base.Update(gameTime);
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
        }
    }
}
