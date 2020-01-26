using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    public class ClassicConnect : AConnect {
        protected override Pieces nextPlayer => currentPlayer == Pieces.red ? Pieces.yellow : Pieces.red;

        public ClassicConnect() : base() { }
    }
}
