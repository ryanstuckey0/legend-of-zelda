using LegendOfZelda.HUDClasses;
using Microsoft.Xna.Framework;
using System;

namespace LegendOfZelda
{
    public static class RoomConstants
    {
        //Room Constants
        public const double SpriteMultiplier = Constants.GameScaler;
        public const int RoomBorderX = 0;
        public const int RoomBorderY = HUDConstants.hudHeight;
        public const int RoomWidth = (int)(256 * SpriteMultiplier);
        public const int RoomHeight = (int)(176 * SpriteMultiplier);
        public const int TileLength = (int)(16 * SpriteMultiplier);
        public const int WallWidth = (int)(32 * SpriteMultiplier);
        public const int BottomOfScreen = RoomBorderY + RoomHeight;
        public const int RightOfScreen = RoomBorderX + RoomWidth;
        public const int BackgroundX = RoomBorderX + WallWidth;
        public const int BackgroundY = RoomBorderY + WallWidth;
        public const int TopDoorX = RoomBorderX + (RoomWidth - WallWidth) / 2;
        public const int TopDoorY = RoomBorderY;
        public const int RightDoorX = RoomBorderX + RoomWidth - WallWidth;
        public const int RightDoorY = RoomBorderY + (RoomHeight - WallWidth) / 2;
        public const int BottomDoorX = TopDoorX;
        public const int BottomDoorY = RoomBorderY + RoomHeight - WallWidth;
        public const int LeftDoorX = RoomBorderX;
        public const int LeftDoorY = RightDoorY;
        public const int NumberRooms = 17;
        public static Random RandomGenerator = new Random();

        // Wall Collision Rectangles
        private const int upDownWallBlockLength = RoomWidth - RoomWidth / 2 - WallWidth / 2 + (int)(5 * SpriteMultiplier);
        private const int rightLeftWallBlockLength = RoomHeight - RoomHeight / 2 - WallWidth / 2 + (int)(5 * SpriteMultiplier);
        private const int wallBlockWidth = WallWidth;
        private const int rightSideWallBlockX = RightOfScreen - WallWidth;
        private const int rightTopBottomWallBlockX = RightOfScreen - upDownWallBlockLength;
        private const int leftWallBlockX = 0;
        private const int upWallBlockY = HUDConstants.hudHeight;
        private const int downSideWallBlockY = BottomOfScreen - rightLeftWallBlockLength;
        private const int downBottomWallBlockY = BottomOfScreen - WallWidth;
        public static Rectangle LeftUpWallRectangle => new Rectangle(leftWallBlockX, upWallBlockY, wallBlockWidth, rightLeftWallBlockLength);
        public static Rectangle LeftDownWallRectangle => new Rectangle(leftWallBlockX, downSideWallBlockY, wallBlockWidth, rightLeftWallBlockLength);
        public static Rectangle RightUpWallRectangle => new Rectangle(rightSideWallBlockX, upWallBlockY, wallBlockWidth, rightLeftWallBlockLength);
        public static Rectangle RightDownWallRectangle => new Rectangle(rightSideWallBlockX, downSideWallBlockY, wallBlockWidth, rightLeftWallBlockLength);
        public static Rectangle UpLeftWallRectangle => new Rectangle(leftWallBlockX, upWallBlockY, upDownWallBlockLength, wallBlockWidth);
        public static Rectangle UpRightWallRectangle => new Rectangle(rightTopBottomWallBlockX, upWallBlockY, upDownWallBlockLength, wallBlockWidth);
        public static Rectangle DownLeftWallRectangle => new Rectangle(leftWallBlockX, downBottomWallBlockY, upDownWallBlockLength, wallBlockWidth);
        public static Rectangle DownRightWallRectangle => new Rectangle(rightTopBottomWallBlockX, downBottomWallBlockY, upDownWallBlockLength, wallBlockWidth);

        // Door Locations on Texture Atlas
        public const int OpenDoorColumn = 0;
        public const int LockedDoorColumn = 1;
        public const int CrackedDoorColumn = 2;
        public const int BombedDoorColumn = 3;
        public const int BombableDoorColumn = 4;
        public const int UpDoorRow = 0;
        public const int LeftDoorRow = 1;
        public const int RightDoorRow = 2;
        public const int DownDoorRow = 3;

        //String Abbreviations for Tiles in CSV File
        public const string Block = "block";
        public const string BrickTile = "brick";
        public const string Fire = "fire";
        public const string GapTile = "black";
        public const string LadderTile = "lad";
        public const string MovableBlock = "redblock";
        public const string Stairs = "stairs";
        public const string FishStatue = "fstat";
        public const string DragonStatue = "dstat";
        public const string BlueGrass = "bg";
        public const string Water = "water";
        //String Abbreviations for Border and Background in CSV File
        public const string TileBackground = "tealBack";
        public const string BlackBackground = "blackBack";
        public const string WallPiece = "wall";
        public const string OpenDoor = "open";
        public const string LockedDoor = "locked";
        public const string ShutDoor = "shut";
        public const string BombableWall = "wallBom";
        //String Abbreviations for Enemies in CSV File
        public const string Aquamentus = "aquamentus";
        public const string Bat = "bat";
        public const string Goriya = "goriya";
        public const string Hand = "hand";
        public const string Jelly = "jelly";
        public const string OldMan = "oldman";
        public const string Skeleton = "skeleton";
        public const string SpikeTrap = "spiketrap";
        //String Abbreviations for Items in CSV File
        public const string Compass = "compass";
        public const string Heart = "heart";
        public const string Key = "key";
        public const string Map = "map";
        public const string Triforce = "triforce";
    }
}
