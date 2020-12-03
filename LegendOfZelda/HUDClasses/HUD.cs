﻿using LegendOfZelda.GameState.RoomsState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Menu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD : IMenu
    {
        public RoomGameState roomGameState;
        private readonly SpriteBatch spriteBatch;
        private readonly ISprite hudSprite;
        private readonly HeartManager heartManager;
        private readonly NumberManager numberManager;
        private readonly MinimapManager minimapManager;
        private readonly ItemsManager itemsManager;
        private readonly HUDNumber levelNum;
        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public HUD(RoomGameState gameState)
        {
            roomGameState = gameState;
            spriteBatch = gameState.Game.SpriteBatch;
            heartManager = new HeartManager((LinkPlayer)gameState.PlayerList[0]);
            numberManager = new NumberManager((LinkPlayer)gameState.PlayerList[0]);
            minimapManager = new MinimapManager(gameState);
            itemsManager = new ItemsManager(this);
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            levelNum = new HUDNumber(1);
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            numberManager.Update();
            heartManager.Update();
            minimapManager.Update();
            itemsManager.Update();
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position, Constants.DrawLayer.HUD);
            levelNum.Draw(spriteBatch, position + HUDConstants.LevelNumberLocation, Constants.DrawLayer.HUDMinimap);
            numberManager.Draw(spriteBatch, position);
            heartManager.Draw(spriteBatch, position);
            minimapManager.Draw(position);
            itemsManager.Draw();
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

    }
}
