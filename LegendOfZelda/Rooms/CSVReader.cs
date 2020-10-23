﻿using LegendOfZelda.Enemies;
using LegendOfZelda.Environment;
using LegendOfZelda.GameLogic;
using LegendOfZelda.Interface;
using LegendOfZelda.Item;
using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace LegendOfZelda.Rooms
{
    class CSVReader
    {
        public ISpawnableManager allObjects;
        private SpriteBatch spriteBatch;

        public CSVReader(SpriteBatch spriteBatch, ISpawnableManager allObjects, string fileName)
        {
            this.allObjects = allObjects;
            this.spriteBatch = spriteBatch;
            TextFieldParser parser = new TextFieldParser(Directory.GetCurrentDirectory() + "\\" + fileName);
            parser.Delimiters = new string[] { "," }; //Delimiters are like separators in NextWordOrSeparator
            int j = 0;
            //Read each line of the file
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if (j == 0)
                {
                    for (int i = 0; i < fields.Length; i++)
                    {
                        IBlock roomBorder = new RoomBorder(spriteBatch, new Point(RoomConstants.roomBorderX, RoomConstants.roomBorderY));
                        allObjects.Spawn(roomBorder);
                        spawnWallsAndBackground(fields[i], i);
                    }
                }
                else
                {
                    for(int i = 0; i < fields.Length; i++)
                    {
                        spawnFromString(fields[i], i, j);
                    }
                }
                j++;
            }
        }

        private void spawnFromString(string spawnType, int gridX, int gridY)
        {
            int posX = RoomConstants.backgroundX + gridX * RoomConstants.tileLength;
            int posY = RoomConstants.backgroundY + gridY * RoomConstants.tileLength;
            Point position = new Point(posX, posY);
            IBlock blockType;
            INpc npcType;
            IItem itemType;

            switch (spawnType)
            {
                //Blocks
                case RoomConstants.Block:
                    break;
                case RoomConstants.BrickTile:
                    blockType = new BrickTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.GapTile:
                    blockType = new GapTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.Fire:
                    blockType = new Fire(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.LadderTile:
                    blockType = new LadderTile(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.Stairs:
                    blockType = new Stairs(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.Statue:
                    blockType = new Statues(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.BlueGrass:
                    blockType = new TileBlueGrass(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.Water:
                    blockType = new TileWater(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;

                //Npcs
                case RoomConstants.Aquamentus:
                    npcType = new Aquamentus(spriteBatch, position, allObjects);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.Bat:
                    npcType = new Bat(spriteBatch, position);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.Goriya:
                    npcType = new Goriya(spriteBatch, position, allObjects);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.Hand:
                    npcType = new Hand(spriteBatch, position);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.Jelly:
                    npcType = new Jelly(spriteBatch, position);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.OldMan:
                    npcType = new OldMan(spriteBatch, position);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.Skeleton:
                    npcType = new Skeleton(spriteBatch, position);
                    allObjects.Spawn(npcType);
                    break;
                case RoomConstants.SpikeTrap:
                    npcType = new SpikeTrap(spriteBatch, position, allObjects.GetPlayer(0));
                    allObjects.Spawn(npcType);
                    break;

                //Items
                case RoomConstants.Compass:
                    itemType = new CompassItem(spriteBatch, position);
                    allObjects.Spawn(itemType);
                    break;
                case RoomConstants.Heart:
                    itemType = new HeartItem(spriteBatch, position);
                    allObjects.Spawn(itemType);
                    break;
                case RoomConstants.Key:
                    itemType = new KeyItem(spriteBatch, position);
                    allObjects.Spawn(itemType);
                    break;
                case RoomConstants.Map:
                    itemType = new MapItem(spriteBatch, position);
                    allObjects.Spawn(itemType);
                    break;
                case RoomConstants.Triforce:
                    itemType = new TriforceItem(spriteBatch, position);
                    allObjects.Spawn(itemType);
                    break;

                default:
                    break;

            }
        }

        private void spawnWallsAndBackground(string spawnType, int i)
        {
            IBlock blockType;
            Point position;

            if (i == 0)
                position = new Point(RoomConstants.backgroundX, RoomConstants.backgroundY);
            else if (i == 1)
                position = new Point(RoomConstants.topDoorX, RoomConstants.topDoorY);
            else if (i == 2)
                position = new Point(RoomConstants.rightDoorX, RoomConstants.rightDoorY);
            else if (i == 3)
                position = new Point(RoomConstants.bottomDoorX, RoomConstants.bottomDoorY);
            else if (i == 4)
                position = new Point(RoomConstants.leftDoorX, RoomConstants.leftDoorY);
            else
                position = Point.Zero;

            switch (spawnType)
            {
                case RoomConstants.TileBackground:
                    blockType = new TileBackground(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.BlackBackground:
                    blockType = new BlackBackground(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.WallPiece:
                    blockType = new Walls(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.OpenDoor:
                    blockType = new OpenDoor(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.LockedDoor:
                    blockType = new LockedDoor(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.ShutDoor:
                    blockType = new ShutDoor(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                case RoomConstants.BombableWall:
                    blockType = new Walls(spriteBatch, position);
                    allObjects.Spawn(blockType);
                    break;
                default:
                    break;

            }
      
        }

    }
}
