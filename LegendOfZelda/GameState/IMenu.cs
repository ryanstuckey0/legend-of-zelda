﻿using LegendOfZelda.GameState.Button;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace LegendOfZelda.GameState
{
    interface IMenu
    {
        Point Position { get; set; }
        void Update();
        void Draw();
        Rectangle GetRectangle();
    }
}