﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Item
{
    class HeartItem : GenericItem
    {
        public HeartItem(SpriteBatch spriteBatch, Point spawnPosition) : base(spriteBatch, spawnPosition)
        {
            sprite = ItemSpriteFactory.Instance.CreateHeartSprite();
        }

        protected override void CheckItemIsExpired()
        {
            itemIsExpired = !itemIsExpired && false;
        }
    }
}
