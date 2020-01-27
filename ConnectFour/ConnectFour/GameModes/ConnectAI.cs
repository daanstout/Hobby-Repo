using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    /// <summary>
    /// An AI that can play Connect
    /// </summary>
    public class ConnectAI : AConnect{
        public static int searchDepth = 2;

        protected static Pieces aiPiece = Pieces.yellow;

        protected override Pieces nextPlayer => currentPlayer == Pieces.red ? Pieces.yellow : Pieces.red;

        public ConnectAI() : base() {

        }

        public override void Update(float deltaTime) {
            base.Update(deltaTime);

            if (!lockBoard && currentPlayer == aiPiece && !isGameOver)
                PlaceBestMove();
        }

        public int FindBestMove() {
            int move = GetBestMove(field, fieldSize, winLength, currentPlayer, nextPlayer);

            return move;
        }

        public bool PlaceBestMove() {
            int index = FindBestMove();

            Point location = new Point(index * squareSize + squareOffset, 0);

            return base.PlacePiece(location);
        }

        protected static Pieces[,] CopyField(Pieces[,] field, Size fieldSize) {
            Pieces[,] newField = new Pieces[fieldSize.Width, fieldSize.Height];

            for (int x = 0; x < fieldSize.Width; x++)
                for (int y = 0; y < fieldSize.Height; y++)
                    newField[x, y] = field[x, y];

            return newField;
        }

        protected static int GetBestMove(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece) {
            int[] moves = new int[fieldSize.Width];
            Pieces[,] testField;

            for(int x = 0; x < fieldSize.Width; x++) {
                int y = ProbeBestY(field, fieldSize, x);

                if(y <= 1 || y >= fieldSize.Height) {
                    moves[x] = int.MinValue;
                    continue;
                }

                testField = CopyField(field, fieldSize);

                testField[x, y] = currentPiece;

                if(WinChecker.CheckForWin(testField, fieldSize, winLength)) {
                    moves[x] = int.MaxValue;
                    continue;
                }

                moves[x] = GetBestMove(testField, fieldSize, winLength, opponentPiece, currentPiece, searchDepth - 1, false);
            }

            List<int> bestIndeces = new List<int>();
            int bestValue = int.MinValue;

            for (int i = 0; i < fieldSize.Width; i++) {
                if (moves[i] > bestValue) {
                    bestIndeces.Clear();
                    bestIndeces.Add(i);
                    bestValue = moves[i];
                } else if (moves[i] == bestValue)
                    bestIndeces.Add(i);
            }

            int bestIndex = 0;

            if (bestIndeces.Count == 1)
                bestIndex = bestIndeces[0];
            else if (bestIndeces.Count >= 2)
                bestIndex = bestIndeces[new Random().Next(0, bestIndeces.Count)];

            return bestIndex;
        }

        protected static int GetBestMove(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece, int depth, bool isMax) {
            if(depth <= 0) {
                if (WinChecker.CheckForWin(field, fieldSize, winLength))
                    return isMax ? int.MaxValue : int.MinValue;
                else {
                    int value = GetFieldValue(field, fieldSize, winLength, currentPiece, opponentPiece);
                    return value;
                }
            }

            int[] moves = new int[fieldSize.Width];
            Pieces[,] testField;

            for(int x = 0; x < fieldSize.Width; x++) {
                int y = ProbeBestY(field, fieldSize, x);

                if(y <= 1 || y >= fieldSize.Height) {
                    moves[x] = isMax ? int.MinValue : int.MaxValue;
                    continue;
                }

                testField = CopyField(field, fieldSize);

                testField[x, y] = currentPiece;

                if(WinChecker.CheckForWin(testField, fieldSize, winLength)) {
                    moves[x] = isMax ? int.MaxValue : int.MinValue;
                    continue;
                }

                moves[x] = GetBestMove(testField, fieldSize, winLength, opponentPiece, currentPiece, depth - 1, !isMax);
            }

            return isMax ? moves.Max() : moves.Min();
        }

        protected static int ProbeBestY(Pieces[,] field, Size fieldSize, int x) {
            int availableY = -1;

            while (availableY < fieldSize.Height - 1 && field[x, availableY + 1] == Pieces.clear)
                availableY++;

            return availableY;
        }

        protected static int GetFieldValue(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece) {
            int fieldValue = 0;

            for(int length = 2; length < winLength; length++) {
                fieldValue += HorizontalValue(field, fieldSize, length, currentPiece);
                fieldValue += VerticalValue(field, fieldSize, length, currentPiece);
                fieldValue += DiagonalLeftValue(field, fieldSize, length, currentPiece);
                fieldValue += DiagonalRightValue(field, fieldSize, length, currentPiece);

                fieldValue -= HorizontalValue(field, fieldSize, length, opponentPiece);
                fieldValue -= VerticalValue(field, fieldSize, length, opponentPiece);
                fieldValue -= DiagonalLeftValue(field, fieldSize, length, opponentPiece);
                fieldValue -= DiagonalRightValue(field, fieldSize, length, opponentPiece);
            }

            return fieldValue;
        }

        protected static int HorizontalValue(Pieces[,] field, Size fieldSize, int winLength, Pieces piece) {
            int horizontalValue = 0;

            for (int y = fieldSize.Height - 1; y >= 0; y--) {
                for (int x = 0; x <= fieldSize.Width - winLength; x++) {
                    Pieces color = field[x, y];

                    if (color != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + length, y] != color)
                            uninterrupted = false;

                    if (uninterrupted)
                        horizontalValue += winLength * winLength;
                }
            }

            return horizontalValue;
        }

        /// <summary>
        /// Checks if there is a vertical win
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The number of connected pieces to look for</param>
        /// <param name="wonXpos">If a win was found, contains the x-positions of the winning pieces</param>
        /// <param name="wonYpos">If a win was found, contains the y-positions of the winning pieces</param>
        /// <returns>True if ANY player has 4 vertically-connected pieces</returns>
        protected static int VerticalValue(Pieces[,] field, Size fieldSize, int winLength, Pieces piece) {
            int verticalValue = 0;

            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y <= fieldSize.Height - winLength; y++) {
                    Pieces color = field[x, y];

                    if (color != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x, y + length] != color)
                            uninterrupted = false;

                    if (uninterrupted)
                        verticalValue += winLength * winLength;
                }
            }

            return verticalValue;
        }

        /// <summary>
        /// Checks if there is a diagonal win that goes from top-left to bottom-right
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The number of connected pieces to look for</param>
        /// <param name="wonXpos">If a win was found, contains the x-positions of the winning pieces</param>
        /// <param name="wonYpos">If a win was found, contains the y-positions of the winning pieces</param>
        /// <returns>True if ANY player has 4 diagonally-connected pieces</returns>
        protected static int DiagonalRightValue(Pieces[,] field, Size fieldSize, int winLength, Pieces piece) {
            int diagonalValue = 0;

            int x = 0, y = 0;
            // Loop through the three possible right-wards diagonals from the left most line
            for (; y <= fieldSize.Height - winLength; y++) {
                // The 4-long line we look for has up to 3 starting positions, depending on the currentY we start at
                // To get that value, we take 3 (the max number of positions) and substract the current Y value
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    // The color of the top-left most piece we are looking at
                    Pieces currentColor = field[x + offset, y + offset];

                    // If the current color is clear (no piece present), we don't have to look
                    if (currentColor != piece)
                        continue;

                    // Look if the four tiles have the same color
                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += winLength * winLength;
                }
            }

            y = 0;
            x = 1;

            for (; x <= fieldSize.Width - winLength; x++) {
                for (int offset = 0; x + offset <= fieldSize.Width - winLength; offset++) {
                    Pieces currentColor = field[x + offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        diagonalValue += winLength * winLength;
                    }
                }
            }

            return diagonalValue;
        }

        /// <summary>
        /// Checks if there is a diagonal win that goes from top-right to bottom-left
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The number of connected pieces to look for</param>
        /// <param name="wonXpos">If a win was found, contains the x-positions of the winning pieces</param>
        /// <param name="wonYpos">If a win was found, contains the y-positions of the winning pieces</param>
        /// <returns>True if ANY player has 4 diagonally-connected pieces</returns>
        protected static int DiagonalLeftValue(Pieces[,] field, Size fieldSize, int winLength, Pieces piece) {
            int diagonalValue = 0;

            int x = fieldSize.Width - 1, y = 0;

            for (; y <= fieldSize.Height - winLength; y++) {
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += winLength * winLength;
                }
            }

            y = 0;
            // We go 2 back, 1 because the last column has an index of width - 1, and another 1 becuase we already checked the diagonal that starts in the last column
            x = fieldSize.Width - 2;

            for (; x > winLength - 2; x--) {
                for (int offset = 0; x - offset > winLength - 2; offset++) {
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += winLength * winLength;
                }
            }

            return diagonalValue;
        }

        protected struct Pair<T> {
            public T first;
            public T second;

            public T this[int index] {
                get {
                    return index switch
                    {
                        0 => first,
                        1 => second,
                        _ => throw new IndexOutOfRangeException(),
                    };
                }
                set {
                    if (index == 1)
                        first = value;
                    else if (index == 2)
                        second = value;
                    else
                        throw new IndexOutOfRangeException();
                }
            }

            public Pair(T first, T second) {
                this.first = first;
                this.second = second;
            }
        }
    }
}
