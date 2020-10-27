﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Environment.Sprite
{
    class SquareSprite : ISprite
    {
        private Texture2D sprite;

        public SquareSprite(Texture2D sprite)
        {
            this.sprite = sprite;
        }
        public void Update()
        {
            // nothing to do
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, RoomConstants.SpriteMultiplier * sprite.Width, RoomConstants.SpriteMultiplier * sprite.Height);
            Rectangle sourceRectangle = new Rectangle(0, 0, sprite.Width, sprite.Height);
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }

        public Rectangle GetPositionRectangle()
        {
            return sprite.Bounds;
        }
    }
}