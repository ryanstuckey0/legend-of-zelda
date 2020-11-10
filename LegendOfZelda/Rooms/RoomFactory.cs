using LegendOfZelda.Link.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace LegendOfZelda.Rooms
{
    internal static class RoomFactory
    {
        private const int startingRoomNumber = 2;
        private const string roomDataDirectory = "Content\\RoomData\\";

        public static Room BuildMapAndGetStartRoom(SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            List<Room> roomsList = new List<Room>();
            InitRoomsList(roomsList, spriteBatch, playerList);
            ConnectRooms(roomsList);
            return roomsList[startingRoomNumber];
        }

        private static void InitRoomsList(List<Room> roomsList, SpriteBatch spriteBatch, List<IPlayer> playerList)
        {
            roomsList.Add(null); // room files start at 1
            for (int i = 1; i <= RoomConstants.NumberRooms; i++)
            {
                roomsList.Add(new Room(spriteBatch, roomDataDirectory + "Room" + i + ".csv", playerList));
            }
        }

        private static void ConnectRooms(List<Room> roomsList)
        {
            int row, column;

            // Connect Columns
            // Row 0
            row = 0;
            roomsList[1].ConnectRoom(roomsList[2], Constants.Direction.Right); // connect 1-2
            roomsList[2].ConnectRoom(roomsList[3], Constants.Direction.Right); // connect 2-3

            column = 1;
            roomsList[1].LocationOnMap = new Point(column++, row);
            roomsList[2].LocationOnMap = new Point(column++, row);
            roomsList[3].LocationOnMap = new Point(column, row);

            // Row 1
            row++;
            
            column = 2;
            roomsList[4].LocationOnMap = new Point(column, row);

            // Row 2
            row++;
            roomsList[6].ConnectRoom(roomsList[7], Constants.Direction.Right); // connect 6-7
            roomsList[5].ConnectRoom(roomsList[6], Constants.Direction.Right); // connect 5-6

            column = 1;
            roomsList[5].LocationOnMap = new Point(column++, row);
            roomsList[6].LocationOnMap = new Point(column++, row);
            roomsList[7].LocationOnMap = new Point(column, row);

            // Row 3
            row++;
            roomsList[8].ConnectRoom(roomsList[9], Constants.Direction.Right); // connect 8-9
            roomsList[9].ConnectRoom(roomsList[10], Constants.Direction.Right); // connect 9-10
            roomsList[10].ConnectRoom(roomsList[11], Constants.Direction.Right); // connect 10-11
            roomsList[11].ConnectRoom(roomsList[12], Constants.Direction.Right); // connect 11-12

            column = 0;
            roomsList[8].LocationOnMap = new Point(column++, row);
            roomsList[9].LocationOnMap = new Point(column++, row);
            roomsList[10].LocationOnMap = new Point(column++, row);
            roomsList[11].LocationOnMap = new Point(column++, row);
            roomsList[12].LocationOnMap = new Point(column, row);

            // Row 4
            row++;
            roomsList[14].ConnectRoom(roomsList[15], Constants.Direction.Right); // connect 14-15

            column = 2;
            roomsList[13].LocationOnMap = new Point(column, row);

            column = 4;
            roomsList[14].LocationOnMap = new Point(column++, row);
            roomsList[15].LocationOnMap = new Point(column, row);

            // Row 5
            row++;
            roomsList[16].ConnectRoom(roomsList[17], Constants.Direction.Right); // connect 16-17
            
            column = 1;
            roomsList[16].LocationOnMap = new Point(column++, row);
            roomsList[17].LocationOnMap = new Point(column, row);

            // Connect Rows

            // Row 1 <-> Row 2
            roomsList[2].ConnectRoom(roomsList[4], Constants.Direction.Up); // connect 2-4

            // Row 2 <-> Row 3
            roomsList[4].ConnectRoom(roomsList[6], Constants.Direction.Up); // connect 4-6

            // Row 3 <-> 4
            roomsList[5].ConnectRoom(roomsList[9], Constants.Direction.Up); // connect 5-9
            roomsList[6].ConnectRoom(roomsList[10], Constants.Direction.Up); // connect 6-10
            roomsList[7].ConnectRoom(roomsList[11], Constants.Direction.Up); // connect 7-11

            // Row 4 <-> 5
            roomsList[10].ConnectRoom(roomsList[13], Constants.Direction.Up); // connect 10-13
            roomsList[12].ConnectRoom(roomsList[14], Constants.Direction.Up); // connect 12-14

            // Row 5 <-> 6
            roomsList[13].ConnectRoom(roomsList[17], Constants.Direction.Up); // connect 15-17
        }
    }
}
