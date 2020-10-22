﻿using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using LegendOfZelda.Link.CollisionHandler.WithBlock;
using LegendOfZelda.Link.CollisionHandler.WithItem;
using System;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    class CollisionHandlerDictionary
    {
        // IPlayer Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<IPlayer, INpc>> playerNpcDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>> playerProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IItem>> playerItemDictionary;
        private Dictionary<Type, ICollisionHandler<IPlayer, IBlock>> playerBlockDictionary;

        // INpc Collision Dictionaries
        private Dictionary<Type, ICollisionHandler<INpc, IProjectile>> npcProjectileDictionary;
        private Dictionary<Type, ICollisionHandler<INpc, IBlock>> npcBlockDictionary;

        // IProjectile Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IProjectile, IBlock>> projectileBlockDictionary;

        // IItem Collision Dictionary
        private Dictionary<Type, ICollisionHandler<IItem, IBlock>> itemBlockDictionary;

        public CollisionHandlerDictionary()
        {
            InitializePlayerCollisionDictionaries();
            InitializeNpcCollisionDictionaries();
            InitializeProjectileCollisionDictionaries();
            InitializeItemCollisionDictionaries();
        }

        public ICollisionHandler<IPlayer, INpc> GetPlayerNpcHandler(Type type)
        {
            return playerNpcDictionary[type];
        }

        public ICollisionHandler<IPlayer, IProjectile> GetPlayerProjectileHandler(Type type)
        {
            return playerProjectileDictionary[type];
        }

        public ICollisionHandler<IPlayer, IItem> GetPlayerItemHandler(Type type)
        {
            return playerItemDictionary[type];
        }

        public ICollisionHandler<IPlayer, IBlock> GetPlayerBlockHandler(Type type)
        {
            return playerBlockDictionary[type];
        }

        public ICollisionHandler<INpc, IProjectile> GetNpcProjectileHandler(Type type)
        {
            return npcProjectileDictionary[type];
        }

        public ICollisionHandler<INpc, IBlock> GetNpcBlockHandler(Type type)
        {
            return npcBlockDictionary[type];
        }

        public ICollisionHandler<IProjectile, IBlock> GetProjectileBlockHandler(Type type)
        {
            return projectileBlockDictionary[type];
        }

        public ICollisionHandler<IItem, IBlock> GetItemBlockHandler(Type type)
        {
            return itemBlockDictionary[type];
        }

        private void InitializePlayerCollisionDictionaries()
        {
            playerNpcDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, INpc>>()
            {
                // TODO: initialize here
            };

            playerProjectileDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IProjectile>>()
            {
                // TODO: initialize here
            };

            playerItemDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IItem>>()
            {
                {typeof(BombItem), new LinkBombItemCollisionHandler() },
                {typeof(BoomerangItem), new LinkBoomerangItemCollisionHandler() },
                {typeof(BowItem), new LinkBowItemCollisionHandler() },
                {typeof(ClockItem), new LinkClockItemCollisionHandler() },
                {typeof(CompassItem), new LinkCompassItemCollisionHandler() },
                {typeof(FairyItem), new LinkFairyItemCollisionHandler() },
                {typeof(HeartContainerItem), new LinkHeartContainerItemCollisionHandler() },
                {typeof(HeartItem), new LinkHeartItemCollisionHandler() },
                {typeof(KeyItem), new LinkKeyItemCollisionHandler() },
                {typeof(MapItem), new LinkMapItemCollisionHandler() },
                {typeof(RupeeItem), new LinkRupeeItemCollision() },
                {typeof(TriforceItem), new LinkTriforceItemCollisionHandler() }
            };

            playerBlockDictionary = new Dictionary<Type, ICollisionHandler<IPlayer, IBlock>>()
            {
                // TODO: initialize here
                // fire
                // unmovable block
                    // water
                    // wall
                    // gap tile
                    // statue
                // movable block
            };
        }

        private void InitializeNpcCollisionDictionaries()
        {
            npcProjectileDictionary = new Dictionary<Type, ICollisionHandler<INpc, IProjectile>>
            {
                // TODO: initialize here
            };

            npcBlockDictionary = new Dictionary<Type, ICollisionHandler<INpc, IBlock>>()
            {
                // TODO: initialize here
            };
        }

        private void InitializeProjectileCollisionDictionaries()
        {
            projectileBlockDictionary = new Dictionary<Type, ICollisionHandler<IProjectile, IBlock>>
            {
                // TODO: initialize here
            };
        }

        private void InitializeItemCollisionDictionaries()
        {
            itemBlockDictionary = new Dictionary<Type, ICollisionHandler<IItem, IBlock>>()
            {
                // TODO: initialize me here
            };
        }
    }
}
