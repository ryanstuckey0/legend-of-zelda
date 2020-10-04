using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Link.Interface;
using System;

namespace Sprint0.Link.Sprite
{
    class SwordBeamExplodingSprite : ILinkItemSprite
    {
        private Texture2D upLeftSprite, upRightSprite, downLeftSprite, downRightSprite;
        private bool animationIsFinished;
        private int xOffset;
        private int yOffset;
        private int bufferFrame;
        private int currentFrame;
        private const int totalFrames = 4;
        private const int numRows = 1;
        private const int numColumns = 2;

        public SwordBeamExplodingSprite(Texture2D upLeftSprite, Texture2D upRightSprite, Texture2D downLeftSprite, Texture2D downRightSprite)
        {
            this.upLeftSprite = upLeftSprite;
            this.upRightSprite = upRightSprite;
            this.downLeftSprite = downLeftSprite;
            this.downRightSprite = downRightSprite;
            animationIsFinished = false;
            bufferFrame = 0;
            currentFrame = 0;
            xOffset = 0;
            yOffset = 0;
        }

        public void Update()
        {
            if (FinishedAnimation()) return;
            if (++bufferFrame == Constants.FrameDelay)
            {
                currentFrame++;
                bufferFrame = 0;
            }

            xOffset += Constants.SwordBeamExplodingDistanceInterval;
            yOffset += Constants.SwordBeamExplodingDistanceInterval;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width, height;
            int currentRow = 1;
            int currentColumn = currentFrame;

            animationIsFinished = Math.Sqrt(Math.Pow(xOffset, 2) + Math.Pow(yOffset, 2)) > Constants.SwordBeamExplodingRange;

            width = upLeftSprite.Width / numColumns;
            height = upLeftSprite.Height / numRows;
            spriteBatch.Draw(upLeftSprite, new Rectangle((int)position.X - xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = downLeftSprite.Width / numColumns;
            height = downLeftSprite.Height / numRows;
            spriteBatch.Draw(downLeftSprite, new Rectangle((int)position.X - xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = upRightSprite.Width / numColumns;
            height = upRightSprite.Height / numRows;
            spriteBatch.Draw(upRightSprite, new Rectangle((int)position.X + xOffset, (int)position.Y - yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);

            width = downRightSprite.Width / numColumns;
            height = downRightSprite.Height / numRows;
            spriteBatch.Draw(downRightSprite, new Rectangle((int)position.X + xOffset, (int)position.Y + yOffset, (int)(width * Constants.SpriteScaler), (int)(height * Constants.SpriteScaler)), new Rectangle(width * currentColumn, height * currentRow, width, height), Color.White);
        }

        public bool FinishedAnimation()
        {
            return animationIsFinished;
        }
    }
}