using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DaanLib.Grid;

namespace HobbyProjects.Projects.GameOfLife {
    public class Cell : ICell{
        public State currentState;
        public State newState;

        public Point location;
        public Size size;

        public Cell(Point loc, Size size, State initialState = State.Dead) {
            location = loc;
            this.size = size;
            currentState = initialState;
            newState = State.Dead;
        }
    }

    public enum State {
        Dead,
        Alive
    }
}
