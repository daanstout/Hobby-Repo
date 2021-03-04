using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DnDDungeonGenerator {
    public partial class Form1 : Form {
        Dictionary<Vec2, Room> rooms;

        public Form1() {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e) {
            var min = (int)minRoomsNumeric.Value;
            var max = (int)maxRoomsNumeric.Value;

            var random = new Random();

            var roomCount = random.Next(min, max);

            var landingRoom = new Room(new Vec2(0, 0)) {
                RoomColor = Color.White
            };

            rooms = new Dictionary<Vec2, Room>() {
                { new Vec2(0, 0), landingRoom }
            };

            List<Room> openRooms = new List<Room> {
                landingRoom
            };

            Vec2[] directions = {
                new Vec2(0, -1),
                new Vec2(1, 0),
                new Vec2(0, 1),
                new Vec2(-1, 0),
            };

            (int weight, Color color, int left)[] weights = new[]{
                ((int)normalRoomWeightNumeric.Value, normalRoomWeightLabel.ForeColor, (int)maxRoomsNumeric.Value),
                ((int)treasureRoomWeightNumeric.Value, treasureRoomWeightLabel.ForeColor, (int)maxTreasureRoomNumeric.Value),
                ((int)shopRoomWeightNumeric.Value, shopRoomWeightLabel.ForeColor, (int)maxShopRoomNumeric.Value),
                ((int)miniBossWeightNumeric.Value, miniBossRoomWeightLabel.ForeColor, (int)maxMiniBossRoomNumeric.Value),
                ((int)pillarWeightNumeric.Value, pillarRoomWeightLabel.ForeColor, (int)maxPillarRoomNumeric.Value)
            };

            int totalRoomWeight = 0;

            foreach (var weight in weights)
                totalRoomWeight += weight.weight;
            //var totalRoomWeight = (int)(normalRoomWeightNumeric.Value + treasureRoomWeightNumeric.Value + shopRoomWeightNumeric.Value + miniBossWeightNumeric.Value);

            while (rooms.Count < roomCount) {
                var randomRoom = openRooms[random.Next(0, openRooms.Count)];

                var filledNeighbours = 0;

                foreach (var dir in directions) {
                    if (rooms.ContainsKey(randomRoom.RoomPosition + dir))
                        filledNeighbours++;
                }

                if (filledNeighbours == 4) {
                    openRooms.Remove(randomRoom);
                    continue;
                }

                var directionIndex = random.Next(0, directions.Length);
                var randomDirection = directions[directionIndex];
                var location = randomRoom.RoomPosition + randomDirection;

                if (rooms.ContainsKey(location)) {
                    var neighbour = rooms[location];

                    randomRoom.neighbours[directionIndex] = neighbour;
                    neighbour.neighbours[(directionIndex + 2) % 4] = randomRoom;

                    continue;
                }

                var newRoom = new Room(location);

                var randomRoomColor = random.Next(0, totalRoomWeight);

                for (int i = 0; i < weights.Length; i++) {
                    if (weights[i].weight == 0)
                        continue;

                    if (randomRoomColor < weights[i].weight) {
                        newRoom.RoomColor = weights[i].color;
                        weights[i].left--;

                        if (weights[i].left == 0) {
                            totalRoomWeight -= weights[i].weight;
                            weights[i].weight = 0;
                        }

                        break;
                    }

                    randomRoomColor -= weights[i].weight;
                }

                randomRoom.neighbours[directionIndex] = newRoom;
                newRoom.neighbours[(directionIndex + 2) % 4] = randomRoom;

                rooms.Add(newRoom.RoomPosition, newRoom);
                openRooms.Add(newRoom);
            }

            roomsGeneratedLabel.Text = $"Rooms Generated: {roomCount}";
            previewPanel.Invalidate();
        }

        private void previewPanel_Paint(object sender, PaintEventArgs e) {
            if (rooms == null || rooms.Count == 0)
                return;

            int lowestX = 0, lowestY = 0;

            foreach (var loc in rooms.Keys) {
                if (loc.x < lowestX)
                    lowestX = loc.x;
                if (loc.y < lowestY)
                    lowestY = loc.y;
            }
            Debug.WriteLine($"Lowest X: {lowestX} - Lowest Y: {lowestY}");
            foreach (var room in rooms.Values) {
                Debug.WriteLine($"X: {room.RoomPosition.x} - Y: {room.RoomPosition.y}");
                room.Draw(e.Graphics, lowestX, lowestY, previewPanel.Font);
            }
        }
    }
}
