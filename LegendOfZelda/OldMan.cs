﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    class OldMan : IEnemy
    {
        private ISprite sprite;
        private SpriteBatch spriteBatch;

        public OldMan(SpriteBatch spriteBatch)
        {
            sprite = SpriteFactory.Instance.CreateOldManSprite();

        }
        public void Draw()
        {
            sprite.Draw(spriteBatch, Sprint2.enemyNPCX, Sprint2.enemyNPCY);
        }

        public void Update()
        {
        }
    }
}