using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DaanLib.Grid;
using System.Diagnostics;

namespace HobbyProjects.Projects.GameOfLife {
    public partial class GameOfLife : UserControl {
        protected override CreateParams CreateParams {
            get {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private Grid<Cell> grid;
        private Size cellSize = new Size(5, 5);
        private Stopwatch stopwatch;
        private long previous = 0;

        public GameOfLife() {
            InitializeComponent();

            grid = new Grid<Cell>(gamePanel.Width / cellSize.Width, gamePanel.Height / cellSize.Height);

            Point currentLocation = new Point(0, 0);

            for (int i = 0; i < grid.size; i++) {
                grid[i] = new Cell(currentLocation, cellSize);

                currentLocation.X += cellSize.Width;

                if (currentLocation.X >= gamePanel.Width) {
                    currentLocation.X = 0;
                    currentLocation.Y += cellSize.Height;
                }
            }

            Initialisers();

            stopwatch = new Stopwatch();
        }

        private void Initialisers() {
            grid[11, 5].currentState = State.Alive;
            grid[12, 5].currentState = State.Alive;
            grid[13, 5].currentState = State.Alive;

            grid[0, 2].currentState = State.Alive;
            grid[1, 2].currentState = State.Alive;
            grid[2, 2].currentState = State.Alive;
            grid[2, 1].currentState = State.Alive;
            grid[1, 0].currentState = State.Alive;
        }

        private Task AssessCell(int index) {
            List<Cell> neighbours = grid.GetAllNeighbours(index);

            var count = neighbours.Count(neighbour => neighbour.currentState == State.Alive);

            if (grid[index].currentState == State.Alive && (count == 2 || count == 3))
                grid[index].newState = State.Alive;
            else if (grid[index].currentState == State.Dead && count == 3)
                grid[index].newState = State.Alive;
            else
                grid[index].newState = State.Dead;

            return Task.CompletedTask;
        }

        private Task UpdateCell(Cell cell) {
            cell.currentState = cell.newState;

            return Task.CompletedTask;
        }

        private async void Iterate() {
            var sw = new Stopwatch();
            sw.Start();

            List<Task> assessList = new List<Task>();

            for (int i = 0; i < grid.size; i++) {
                assessList.Add(AssessCell(i));
            }

            await Task.WhenAll(assessList);

            List<Task> updateList = new List<Task>();

            foreach (var cell in grid.grid)
                updateList.Add(UpdateCell(cell));

            await Task.WhenAll(updateList);

            gamePanel.Invalidate();

            Console.WriteLine(sw.ElapsedMilliseconds);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawRectangle(Pens.Gray, 0, 0, gamePanel.Width - 1, gamePanel.Height - 1);

            for (int i = 1; i < grid.width; i++)
                e.Graphics.DrawLine(Pens.Gray, i * cellSize.Width, 0, i * cellSize.Width, gamePanel.Height);

            for (int i = 1; i < grid.height; i++)
                e.Graphics.DrawLine(Pens.Gray, 0, i * cellSize.Height, gamePanel.Width, i * cellSize.Height);

            foreach (var cell in grid.grid) {
                if (cell.currentState == State.Alive)
                    e.Graphics.FillRectangle(Brushes.Green, new Rectangle(cell.location, cell.size));
            }
        }

        private void iterateButton_Click(object sender, EventArgs e) {
            Iterate();
        }

        private void runTimer_Tick(object sender, EventArgs e) {
            Iterate();
        }

        private void runButton_Click(object sender, EventArgs e) {
            runTimer.Enabled = true;

            stopwatch.Start();
        }

        private void pauseButton_Click(object sender, EventArgs e) {
            runTimer.Enabled = false;
            
            stopwatch.Stop();
            stopwatch.Reset();
        }

        private void clearButton_Click(object sender, EventArgs e) {
            runTimer.Enabled = false;

            for(int i = 0; i < grid.size; i++) {
                var cell = grid[i];
                cell.currentState = State.Dead;
                grid[i] = cell;
            }

            gamePanel.Invalidate();
        }

        private void randomizeButton_Click(object sender, EventArgs e) {
            runTimer.Enabled = false;

            var rand = new Random();

            for(int i = 0; i < grid.size; i++) {
                var cell = grid[i];
                cell.currentState = rand.Next(0, 2) == 0 ? State.Alive : State.Dead;
                grid[i] = cell;
            }

            gamePanel.Invalidate();
        }
    }
}
