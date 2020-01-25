using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    public class ThreePlayerConnect : ClassicConnect {
        protected override Pieces nextPlayer => currentPlayer == Pieces.red ? Pieces.yellow : currentPlayer == Pieces.yellow ? Pieces.green : Pieces.red;

        public ThreePlayerConnect() : base() { }

        public override void Reset(bool createBoard = false) {
            base.Reset(createBoard);

            currentPlayer = random.Next(0, 3) switch
            {
                0 => Pieces.red,
                1 => Pieces.yellow,
                2 => Pieces.green,
                _ => Pieces.red
            };
        }
    }
}
