﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.Interface
{
    public interface ISprite
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Point position);
        Rectangle GetPositionRectangle();
    }
}
