using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    /// <summary>
    /// A game for three player connect
    /// </summary>
    public class ThreePlayerConnect : AConnect {
        /// <summary>
        /// Gets the next player
        /// </summary>
        protected override Pieces nextPlayer => currentPlayer == Pieces.red ? Pieces.yellow : currentPlayer == Pieces.yellow ? Pieces.green : Pieces.red;

        /// <summary>
        /// Instantiates a new game
        /// </summary>
        public ThreePlayerConnect() : base() { }

        /// <summary>
        /// Resets th eboard
        /// </summary>
        /// <param name="createBoard"></param>
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
