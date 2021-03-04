using System;

namespace ChessMetal {
    public class Board {
        public const string ROW_NAME = "rank";
        public const string COLUMN_NAME = "file";
        private const string PIECE_CHAR_CODES = "RNBQKPrnbqkp";
        private const char TURN_WHITE_CHAR = 'w';
        private const char TURN_BLACK_CHAR = 'b';
        private const string CASTLING_CHAR_CODES = "KQkq";

        #region Static Variables
        private static uint maxPieces = 32;
        private static uint maxPawns = 8;
        private static uint maxRooks = 2 + 8;
        private static uint maxKnights = 2 + 8;
        private static uint maxBishops = 2 + 8;
        private static uint maxQueens = 1 + 8;
        private static uint maxKings = 1 + 8;

        public static uint MaxPawns {
            get => maxPawns;
            set {
                var dif = value - maxPawns;
                maxPawns = value;

                maxPieces += dif * 2;
                maxRooks += dif;
                maxKnights += dif;
                maxBishops += dif;
                maxQueens += dif;
                maxKings += dif;
            }
        }

        public static uint MaxRooks {
            get => maxRooks - maxPawns;
            set {
                var dif = value - (maxRooks - maxPawns);
                maxRooks = value + maxPawns;

                maxPieces += dif * 2;
            }
        }

        public static uint MaxKnights {
            get => maxKnights - maxPawns;
            set {
                var dif = value - (maxKnights - maxPawns);
                maxKnights = value + maxPawns;

                maxPieces += dif * 2;
            }
        }

        public static uint MaxBishops {
            get => maxBishops - maxPawns;
            set {
                var dif = value - (maxBishops - maxPawns);
                maxBishops = value + maxPawns;

                maxPieces += dif * 2;
            }
        }

        public static uint MaxQueens {
            get => maxQueens - maxPawns;
            set {
                var dif = value - (maxQueens - maxPawns);
                maxQueens = value + maxPawns;

                maxPawns += dif * 2;
            }
        }

        public static uint MaxKings {
            get => maxKings - maxPawns;
            set {
                var dif = value - (maxKings - maxPawns);
                maxKings = value + maxKings;

                maxPawns += dif * 2;
            }
        }
        #endregion

        #region Variables
        private readonly Piece[] board;
        private readonly Piece[] pieces;
        private readonly Piece[] pawns;
        private readonly Piece[] rooks;
        private readonly Piece[] knights;
        private readonly Piece[] bishops;
        private readonly Piece[] queens;
        private readonly Piece[] kings;
        private readonly Piece[] whitePieces;
        private readonly Piece[] blackPieces;

        private int pieceCount;
        private int pawnCount;
        private int rookCount;
        private int knightcount;
        private int bishopCount;
        private int queenCount;
        private int kingCount;
        private int whitePieceCount;
        private int blackPieceCount;

        private byte castlingRights;

        public BoardTiles EnPassantTile { get; private set; } = BoardTiles.None;
        public uint HalfmoveClock { get; private set; }
        public uint FullmoveCounter { get; private set; }
        public bool WhiteTurn { get; private set; }
        public GenerationReturnCodes GenerationStatus { get; private set; }
        #endregion

        public Piece this[int i] => board[i];

        public Board() {
            board = new Piece[64];
            pieces = new Piece[maxPieces];
            pawns = new Piece[maxPawns * 2];
            rooks = new Piece[maxRooks * 2];
            knights = new Piece[maxKnights * 2];
            bishops = new Piece[maxBishops * 2];
            queens = new Piece[maxQueens * 2];
            kings = new Piece[maxKings * 2];
            whitePieces = new Piece[maxPieces / 2];
            blackPieces = new Piece[maxPieces / 2];

            pieceCount = pawnCount = rookCount = knightcount = bishopCount = queenCount = kingCount = whitePieceCount = blackPieceCount = 0;

            for (int i = 0; i < 64; i++) {
                board[i] = new Piece();
            }
        }

        public static Board GenerateFromFEN(string code) {
            var board = new Board();

            var fields = code.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            board.GenerationStatus = GeneratePiecePlacement(board, fields[0]);

            if (board.GenerationStatus != GenerationReturnCodes.Success)
                return board;

            board.GenerationStatus = GenerateCurrentPlayerTurn(board, fields[1]);

            if (board.GenerationStatus != GenerationReturnCodes.Success)
                return board;

            board.GenerationStatus = GenerateCastlingRights(board, fields[2]);

            if (board.GenerationStatus != GenerationReturnCodes.Success)
                return board;

            board.GenerationStatus = GenerateEnPassantSqure(board, fields[3]);

            if (board.GenerationStatus != GenerationReturnCodes.Success)
                return board;

            board.GenerationStatus = GenerateHalfmoveClock(board, fields[4]);

            if (board.GenerationStatus != GenerationReturnCodes.Success)
                return board;

            board.GenerationStatus = GenerateFullmoveCounter(board, fields[5]);

            return board;
        }

        private static GenerationReturnCodes GeneratePiecePlacement(Board board, string code) {
            var index = 0;

            foreach (var c in code) {
                if (c == '/')
                    continue;

                if (char.IsDigit(c)) {
                    index += (int)char.GetNumericValue(c);
                    continue;
                }

                if (!PIECE_CHAR_CODES.Contains(c))
                    return GenerationReturnCodes.InvalidPieceChar; // Illegal code

                if (c == PieceDataValues.BLACK_PAWN) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.pawnCount >= maxPawns * 2)
                        return GenerationReturnCodes.PawnOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.PAWN_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.pawns[board.pawnCount] = board[index];
                    board.pawnCount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.BLACK_ROOK) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.rookCount >= maxRooks * 2)
                        return GenerationReturnCodes.RookOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.ROOK_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.rooks[board.rookCount] = board[index];
                    board.rookCount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.BLACK_KNIGHT) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.knightcount >= maxKnights * 2)
                        return GenerationReturnCodes.KnightOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.KNIGHT_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.knights[board.knightcount] = board[index];
                    board.knightcount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.BLACK_BISHOP) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.bishopCount >= maxBishops * 2)
                        return GenerationReturnCodes.BishopOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.BISHOP_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.bishops[board.bishopCount] = board[index];
                    board.bishopCount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.BLACK_QUEEN) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.queenCount >= maxQueens * 2)
                        return GenerationReturnCodes.QueenOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.QUEEN_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.queens[board.queenCount] = board[index];
                    board.queenCount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.BLACK_KING) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.kingCount >= maxKings * 2)
                        return GenerationReturnCodes.KingOverflow; // Too many pawns

                    if (board.blackPieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.BlackOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.KING_PIECE, PieceDataValues.BLACK_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.kings[board.kingCount] = board[index];
                    board.kingCount++;

                    board.blackPieces[board.blackPieceCount] = board[index];
                    board.blackPieceCount++;
                } else if (c == PieceDataValues.WHITE_PAWN) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.pawnCount >= maxPawns * 2)
                        return GenerationReturnCodes.PawnOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.PAWN_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.pawns[board.pawnCount] = board[index];
                    board.pawnCount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                } else if (c == PieceDataValues.WHITE_ROOK) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.rookCount >= maxRooks * 2)
                        return GenerationReturnCodes.RookOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.ROOK_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.rooks[board.rookCount] = board[index];
                    board.rookCount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                } else if (c == PieceDataValues.WHITE_KNIGHT) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.knightcount >= maxKnights * 2)
                        return GenerationReturnCodes.KnightOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.KNIGHT_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.knights[board.knightcount] = board[index];
                    board.knightcount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                } else if (c == PieceDataValues.WHITE_BISHOP) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.bishopCount >= maxBishops * 2)
                        return GenerationReturnCodes.BishopOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.BISHOP_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.bishops[board.bishopCount] = board[index];
                    board.bishopCount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                } else if (c == PieceDataValues.WHITE_QUEEN) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.queenCount >= maxQueens * 2)
                        return GenerationReturnCodes.QueenOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.QUEEN_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.queens[board.queenCount] = board[index];
                    board.queenCount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                } else if (c == PieceDataValues.WHITE_KING) {
                    if (board.pieceCount >= maxPieces)
                        return GenerationReturnCodes.PieceOverflow; // Too many pieces

                    if (board.kingCount >= maxKings * 2)
                        return GenerationReturnCodes.KingOverflow; // Too many pawns

                    if (board.whitePieceCount * 2 >= maxPieces)
                        return GenerationReturnCodes.WhiteOverflow; // Too many black pieces;

                    board.board[index] = new Piece(PieceDataValues.KING_PIECE, PieceDataValues.WHITE_COLOR) {
                        CurrentTile = (BoardTiles)(index + 1)
                    };

                    board.pieces[board.pieceCount] = board[index];
                    board.pieceCount++;

                    board.kings[board.kingCount] = board[index];
                    board.kingCount++;

                    board.whitePieces[board.whitePieceCount] = board[index];
                    board.whitePieceCount++;
                }

                index++;
            }

            return GenerationReturnCodes.Success;
        }
        private static GenerationReturnCodes GenerateCurrentPlayerTurn(Board board, string code) {
            if (code[0] == TURN_WHITE_CHAR)
                board.WhiteTurn = true;
            else if (code[0] == TURN_BLACK_CHAR)
                board.WhiteTurn = false;
            else
                return GenerationReturnCodes.InvalidPlayerTurnChar;

            return GenerationReturnCodes.Success;
        }
        private static GenerationReturnCodes GenerateCastlingRights(Board board, string code) {
            if (code == "-") {
                board.castlingRights = 0;
                return GenerationReturnCodes.Success;
            }

            foreach(var c in code) {
                if (!CASTLING_CHAR_CODES.Contains(c))
                    return GenerationReturnCodes.InvalidCastlingChar;

                byte mask = c switch {
                    PieceDataValues.WHITE_KING => PieceDataValues.CASTLING_WHITE_KING_MASK,
                    PieceDataValues.WHITE_QUEEN => PieceDataValues.CASTLING_WHITE_QUEEN_MASK,
                    PieceDataValues.BLACK_KING => PieceDataValues.CASTLING_BLACK_KING_MASK,
                    PieceDataValues.BLACK_QUEEN => PieceDataValues.CASTLING_BLACK_QUEEN_MASK,
                    _ => 0
                };

                board.castlingRights |= mask;
            }

            return GenerationReturnCodes.Success;
        }
        private static GenerationReturnCodes GenerateEnPassantSqure(Board board, string code) {
            if (code == "-") {
                board.EnPassantTile = BoardTiles.None;
                return GenerationReturnCodes.Success;
            }

            if (code.Length != 2)
                return GenerationReturnCodes.InvalidEnPassantString;

            var file = code[0];
            var rank = code[1];

            if (file < 'a' || file > 'h')
                return GenerationReturnCodes.InvalidEnPassantString;
            if (rank < '1' || rank > '8')
                return GenerationReturnCodes.InvalidEnPassantString;

            var filePos = file - 'a';
            var rankPos = (int)char.GetNumericValue(rank);

            var index = (8 - rankPos) * 8 + filePos;

            board.EnPassantTile = (BoardTiles)index + 1;

            return GenerationReturnCodes.Success;
        }
        private static GenerationReturnCodes GenerateHalfmoveClock(Board board, string code) {
            if (!uint.TryParse(code, out uint clock))
                return GenerationReturnCodes.InvalidHalfmoveClockString;

            board.HalfmoveClock = clock;

            return GenerationReturnCodes.Success;
        }
        private static GenerationReturnCodes GenerateFullmoveCounter(Board board, string code) {
            if (!uint.TryParse(code, out uint counter))
                return GenerationReturnCodes.InvalidFullmoveCounterString;

            board.FullmoveCounter = counter;

            return GenerationReturnCodes.Success;
        }

        public enum GenerationReturnCodes {
            Success = 0,

            InvalidPieceChar = -1,
            InvalidPlayerTurnChar = -2,
            InvalidCastlingChar = -3,
            InvalidEnPassantString = -4,
            InvalidHalfmoveClockString = -5,
            InvalidFullmoveCounterString = -6,

            PieceOverflow = 1,
            PawnOverflow,
            RookOverflow,
            KnightOverflow,
            BishopOverflow,
            QueenOverflow,
            KingOverflow,

            WhiteOverflow,
            BlackOverflow,
        }
    }
}
