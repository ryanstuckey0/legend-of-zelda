﻿using LegendOfZelda.GameState;
using LegendOfZelda.GameState.Button;
using LegendOfZelda.GameState.ItemSelectionState;
using LegendOfZelda.Interface;
using LegendOfZelda.Link;
using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.HUDClasses
{
    internal class HUD : IMenu
    {
        private SpriteBatch spriteBatch;
        private List<IPlayer> players;
        private HeartManager heartManager;
        private NumberManager numberManager;
        private ISprite hudSprite;
        
        private HUDNumber levelNum;
        private ISprite minimapSprite;
        private bool displayMinimap;
        private LinkConstants.ItemType primaryItem;
        private LinkConstants.ItemType secondaryItem;
        private IButton primaryButton;
        private IButton secondaryButton;

        private Dictionary<LinkConstants.ItemType, IButton> secondaryItemDictionary;

        private bool safeToDespawn = false;
        
        private Point position;
        public Point Position { get => position; set => position = new Point(value.X, value.Y); }

        public List<IButton> Buttons
        {
            get
            {
                List<IButton> list = new List<IButton>();
                return list;
            }
        }

        public HUD(SpriteBatch spriteBatch, List<IPlayer> players)
        {
            this.spriteBatch = spriteBatch;
            this.players = players;
            heartManager = new HeartManager((LinkPlayer)players[0]);
            numberManager = new NumberManager((LinkPlayer)players[0]);
            primaryItem = players[0].PrimaryItem;
            secondaryItem = players[0].SecondaryItem;
            fillSecondaryItemDictionary();
            primaryButton = new SwordInventoryButton(spriteBatch, this, HUDConstants.PrimaryItemLocation);
            secondaryButton = secondaryItemDictionary[secondaryItem];
            hudSprite = HUDSpriteFactory.Instance.CreateHUDSprite();
            minimapSprite = HUDSpriteFactory.Instance.CreateMiniMapSprite();
            levelNum = new HUDNumber(1);
            displayMinimap = false;
            Position = new Point(HUDConstants.hudx, HUDConstants.hudy);
        }

        public void Update()
        {
            if (players[0].GetQuantityInInventory(LinkConstants.ItemType.Map) != 0)
                displayMinimap = true;
            if (players[0].SecondaryItem != secondaryItem)
                UpdateSecondaryItem();
            numberManager.Update();
            heartManager.Update();
        }

        private void UpdateSecondaryItem()
        {
            secondaryItem = players[0].SecondaryItem;
            secondaryButton = secondaryItemDictionary[secondaryItem];
        }

        public void Draw()
        {
            hudSprite.Draw(spriteBatch, position);
            levelNum.Draw(spriteBatch, Position + HUDConstants.LevelNumberLocation);
            if (displayMinimap)
                minimapSprite.Draw(spriteBatch, Position + HUDConstants.MinimapLocation);
            foreach (IButton button in Buttons){
                button.Draw();
            }
            primaryButton.Draw();
            secondaryButton.Draw();
            numberManager.Draw(spriteBatch, Position);
            heartManager.Draw(spriteBatch, Position);
        }

        public bool SafeToDespawn()
        {
            return safeToDespawn;
        }

        public Rectangle GetRectangle()
        {
            return hudSprite.GetPositionRectangle();
        }

        public void Despawn()
        {
            safeToDespawn = true;
        }

        public void fillSecondaryItemDictionary()
        {
            secondaryItemDictionary = new Dictionary<LinkConstants.ItemType, IButton>
            {
                { LinkConstants.ItemType.Boomerang, new BoomerangWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bomb, new BombInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Rupee, new ArrowWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Bow, new ArrowWoodInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.Candle, new CandleBlueInventoryButton(spriteBatch, this, HUDConstants.SecondaryItemLocation)},
                { LinkConstants.ItemType.None, GetEmptyButton() }
            };
        }

        private IButton GetEmptyButton()
        {
            return new EmptyButton((IMenu)this, new Rectangle(HUDConstants.SecondaryItemLocation.X, HUDConstants.SecondaryItemLocation.Y, (int)GameStateConstants.StandardItemSpriteSize.X, (int)GameStateConstants.StandardItemSpriteSize.Y));
        }
    }
}
