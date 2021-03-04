using System;
using System.Collections.Generic;
using System.Text;

namespace ChessMetal {
    public class Piece {
        private readonly int pieceData;

        public BoardTiles CurrentTile { get; set; }

        public Piece() {
            pieceData = 0;
        }

        public Piece(int piece, int color) {
            pieceData = piece | color;
        }

        public bool IsColor(int colorMask) => (pieceData & colorMask) == colorMask;
        public bool IsPiece(int pieceMask) => (pieceData & PieceDataValues.PIECE_MASK) == pieceMask;
        public string ColorString() {
            if (IsColor(PieceDataValues.BOTH_COLOR))
                return "White/Black";
            if (IsColor(PieceDataValues.WHITE_COLOR))
                return "White";
            if (IsColor(PieceDataValues.BLACK_COLOR))
                return "Black";

            return "None";
        }

        public string PieceString() {
            if (IsPiece(PieceDataValues.PAWN_PIECE))
                return "Pawn";
            if (IsPiece(PieceDataValues.ROOK_PIECE))
                return "Rook";
            if (IsPiece(PieceDataValues.KNIGHT_PIECE))
                return "Knight";
            if (IsPiece(PieceDataValues.BISHOP_PIECE))
                return "Bishop";
            if (IsPiece(PieceDataValues.QUEEN_PIECE))
                return "Queen";
            if (IsPiece(PieceDataValues.KING_PIECE))
                return "King";

            return "None";
        }

        public override string ToString() => $"{ColorString()} {PieceString()}";
    }
}
