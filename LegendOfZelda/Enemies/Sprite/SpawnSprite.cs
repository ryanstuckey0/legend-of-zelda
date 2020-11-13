﻿using LegendOfZelda.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendOfZelda.Utility;

namespace LegendOfZelda.Enemies.Sprite
{
    class SpawnSprite : ISprite
    {
        private readonly Texture2D sprite;
        private int bufferFrame;
        private int frameDelay = 5;
        private int numRows = 1;
        private int numColumns = 3;
        private int currentFrame;
        private readonly int totalFrames;
        private readonly int width;
        private readonly int height;
        private bool animationDone;

        public SpawnSprite(Texture2D sprite)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = (numRows * numColumns) + 1;
            width = sprite.Width / numColumns;
            height = sprite.Height / numRows;
            animationDone = false;
        }
        public void Update()
        {
            bufferFrame++;
            if(bufferFrame == frameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if(currentFrame == totalFrames)
            {
                animationDone = true;
                currentFrame = 0;
            }
            
        }

        public void Draw(SpriteBatch spriteBatch, Point position, float layer)
        {
            int row = (int)(currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(position.X, position.Y, (int)(Constants.GameScaler * width), (int)(Constants.GameScaler * height));
            SimpleDraw.Draw(spriteBatch, sprite, destinationRectangle, sourceRectangle, Color.White, layer);
        }

        public Rectangle GetPositionRectangle()
        {
            return new Rectangle(0, 0, (int)(width * Constants.GameScaler), (int)(height * Constants.GameScaler));
        }
        public bool AnimationDone()
        {
            bool currentState = animationDone;
            animationDone = false;
            return currentState;
        }
    }
}