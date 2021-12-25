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

        private Sprite _sprite;

        public int i = 0;

        public Plant(Texture2D spriteSheet, Vector2 position) : base(position)
        {
            _sprite = new Sprite(spriteSheet, TEXTURE_COORDS_X, TEXTURE_COORDS_Y, SPRITE_WIDTH, SPRITE_HEIGHT);

        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            _sprite.Draw(spriteBatch, Position);
        }
    }
}
