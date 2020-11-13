﻿using LegendOfZelda.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace LegendOfZelda.Environment
{
    internal class DragonStatues : IBlock
    {
        private readonly ISprite statueSprite;
        private readonly SpriteBatch sB;
        private bool safeToDespawn;

        private Point position;
        public Point Position { get => new Point(position.X, position.Y); set => position = new Point(value.X, value.Y); }

        public DragonStatues(SpriteBatch spriteBatch, Point position)
        {
            statueSprite = EnvironmentSpriteFactory.Instance.CreateDragonStatueSprite();
            sB = spriteBatch;
            Position = position;
            safeToDespawn = false;
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void Draw()
        {
            statueSprite.Draw(sB, Position, Constants.DrawLayer.Block);
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(Position.X, Position.Y, statueSprite.GetPositionRectangle().Width, statueSprite.GetPositionRectangle().Height);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public void Update()
        {
            statueSprite.Update();
        }
    }
}