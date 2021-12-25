using EcosystemSimulation.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace EcosystemSimulation.Entities
{
    public class Meat : Food
    {
        private const int TEXTURE_COORDS_X = 126;
        private const int TEXTURE_COORDS_Y = 36;

        private const int SPRITE_WIDTH = 33;
        private const int SPRITE_HEIGHT = 30;

        private Sprite _sprite;

        public Meat(Texture2D spriteSheet, Vector2 position) : base(position)
        {
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, Position);
        }
    }
}
