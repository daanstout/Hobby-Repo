using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMetal {
    public static class PieceDataValues {
        public const int SLIDING_PIECES = ROOK_PIECE | BISHOP_PIECE | QUEEN_PIECE;
        public const int MINOR_PIECES = KNIGHT_PIECE | BISHOP_PIECE;
        public const int MAJOR_PIECES = ROOK_PIECE | QUEEN_PIECE;

        public const int PIECE_MASK = 0xFF;
        public const int COLOR_MASK = 0xF00;

        public const int NULL_PIECE = 0X00;
        public const int PAWN_PIECE = 0X01;
        public const int ROOK_PIECE = 0X02;
        public const int KNIGHT_PIECE = 0X04;
        public const int BISHOP_PIECE = 0X08;
        public const int QUEEN_PIECE = 0X10;
        public const int KING_PIECE = 0X20;

        public const int NULL_COLOR = 0X000;
        public const int WHITE_COLOR = 0X100;
        public const int BLACK_COLOR = 0X200;
        public const int BOTH_COLOR = 0X300;

        public const char BLACK_PAWN = 'p';
        public const char BLACK_ROOK = 'r';
        public const char BLACK_KNIGHT = 'n';
        public const char BLACK_BISHOP = 'b';
        public const char BLACK_QUEEN = 'q';
        public const char BLACK_KING = 'k';

        public const char WHITE_PAWN = 'P';
        public const char WHITE_ROOK = 'R';
        public const char WHITE_KNIGHT = 'N';
        public const char WHITE_BISHOP = 'B';
        public const char WHITE_QUEEN = 'Q';
        public const char WHITE_KING = 'K';

        public const byte CASTLING_WHITE_KING_MASK = 0x01;
        public const byte CASTLING_WHITE_QUEEN_MASK = 0x02;
        public const byte CASTLING_BLACK_KING_MASK = 0x04;
        public const byte CASTLING_BLACK_QUEEN_MASK = 0x08;
    }
}
