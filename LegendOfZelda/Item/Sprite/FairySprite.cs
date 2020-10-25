﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace LegendOfZelda.Item.Sprite
{
    class FairySprite : ISprite
    {
        private const int numRows = 1;
        private const int numColumns = 2;
        private Texture2D sprite;
        private int totalFrames;
        private int frameWidth;
        private int frameHeight;
        private int currentFrame;
        private int bufferFrame;
        private Point position;
        private int movementBuffer = 0;
        private int xDir = 0;
        private int yDir = 0;
        private Rectangle destinationRectangle;

        public FairySprite(Texture2D sprite, Point spawnPosition)
        {
            this.sprite = sprite;
            currentFrame = 0;
            bufferFrame = 0;
            totalFrames = numRows * numColumns;
            frameWidth = sprite.Width / numColumns;
            frameHeight = sprite.Height / numRows;
            destinationRectangle = new Rectangle(position.X, position.Y, frameWidth, frameHeight);

            position = spawnPosition;
        }
        public void Update()
        {
            movementBuffer++;
            CheckBounds();
            //Move based on current chosen direction for some time.
            if (xDir == 0 && yDir == 0)
            {
                position.X--;
                position.Y--;
            }
            else if (xDir == 0 && yDir == 1)
            {
                position.X--;
                position.Y++;
            }
            else if (xDir == 1 && yDir == 0)
            {
                position.X++;
                position.Y--;
            }
            else
            {
                position.X++;
                position.Y++;
            }

            if (movementBuffer > 10)
            {
                movementBuffer = 0;
                ChooseDirection();
            }
            bufferFrame++;
            if (bufferFrame == 6)
            {
                currentFrame++;
                bufferFrame = 0;
            }
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Point position)
        {
            int row = (int)((float)currentFrame / (float)numColumns);
            int column = currentFrame % numColumns;

            Rectangle sourceRectangle = new Rectangle(frameWidth * column, frameHeight * row, frameWidth, frameHeight);
            destinationRectangle = new Rectangle(position.X, position.Y, Constants.SpriteScaler * sprite.Width, Constants.SpriteScaler * sprite.Height);

            spriteBatch.Draw(sprite, destinationRectangle, sourceRectangle, Color.White);
        }
        private void CheckBounds()
        {
            if (position.X <= Constants.MinXPos + (Constants.GameScaler * 32))
            {
                position.X += 5;
            }
            else if (position.X >= Constants.MaxXPos - (Constants.GameScaler * 32))
            {
                position.X -= 5; ;
            }
            else if (position.Y <= Constants.MinYPos + (Constants.GameScaler * 32))
            {
                position.Y += 5; ;
            }
            else if (position.Y >= Constants.MaxYPos - (Constants.GameScaler * 32))
            {
                position.Y -= 5;
            }
        }
        private void ChooseDirection()
        {
            Random rand = new Random();
            xDir = rand.Next(0, 2); // 0 for x, 1 for y
            yDir = rand.Next(0, 2); // 0 right/down. 1 for left/up
        }

        public Rectangle GetPositionRectangle()
        {
            return destinationRectangle;
        }

        public bool FinishedAnimation()
        {
            return false; // animation never finishes
        }
    }
}
