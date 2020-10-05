﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendOfZelda
{
    class BrickTile : IInteractiveEnviornment
    {
        private BrickTileSprite brickTileSprite;
        private SpriteBatch sB;
        public BrickTile(SpriteBatch spriteBatch)
        {
            brickTileSprite = (BrickTileSprite)SpriteFactory.Instance.CreateBrickTileSprite();
            sB = spriteBatch;
        }

        public void Draw()
        {
            brickTileSprite.Draw(sB, Sprint2.ieX, Sprint2.ieY);
        }

        public void Interaction()
        {
            
        }
    }
}