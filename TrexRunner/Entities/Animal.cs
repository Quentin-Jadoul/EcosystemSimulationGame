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

        public Vector2 _position;

        private Sprite _sprite;

        public Animal(Texture2D spriteSheet, Vector2 position) : base(position)
        {
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, Position);
        }
    }
}
