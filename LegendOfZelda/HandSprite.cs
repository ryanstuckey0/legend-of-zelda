﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0
{
    class HandSprite : ISprite
    {
        private Texture2D sprite;
        private int Rows { get; set; }
        private int Columns { get; set; }
        private int currentFrame;
        private int bufferFrame;
        private bool currentDir;
        private int rightRow;
        private int leftRow;
        public HandSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            Rows = 2;
            Columns = 2;
            currentFrame = 0;
            bufferFrame = 0;
            currentDir = true;
        }
        public void Update()
        {
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == 2)
            {
                currentFrame = 0;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, int XValue, int YValue)
        {
            int width = sprite.Width / Columns;
            int height = sprite.Height / Rows;
            int row;
            if (currentDir)
            {
                row = rightRow;
            }
            else
            {
                row = leftRow;
            }
            
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(XValue, YValue, 2 * sprite.Width, 2 * sprite.Height);

            spriteBatch.Begin();
            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
