using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    /// <summary>
    /// An AI that can play Connect
    /// <para>The AI uses a Minimax algorithm to look for moves</para>
    /// </summary>
    public class ConnectAI : AConnect {
        /// <summary>
        /// How deep the AI will search for a move (higher is deeper)
        /// </summary>
        public static int searchDepth = 2;
        /// <summary>
        /// The chance in percentage that the AI will do a random move
        /// </summary>
        public static int randomMoveChance = 15;

        /// <summary>
        /// The piece the AI plays as
        /// </summary>
        protected static Pieces aiPiece = Pieces.yellow;

        /// <summary>
        /// If the AI should check for a move
        /// </summary>
        public bool checkForMove = false;

        /// <summary>
        /// Instantiates a new AI
        /// </summary>
        public ConnectAI() : base() {

        }

        /// <summary>
        /// Updates the AI
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Update(float deltaTime) {
            base.Update(deltaTime);

            // If the board is not locked, the AI is the current player, and the game is not over, find your move
            if (!lockBoard && currentPlayer == aiPiece && !isGameOver) {
                // Though we first wait 1 tick so everything finishes nicely
                if (checkForMove) {
                    PlaceBestMove();
                    checkForMove = false;
                } else
                    checkForMove = true;
            }
        }

        /// <summary>
        /// Find the best move
        /// </summary>
        /// <returns>The x-position of the best move for the AI</returns>
        public int FindBestMove() {
            int move = GetBestMove(field, fieldSize, winLength, currentPlayer, nextPlayer);

            return move;
        }

        /// <summary>
        /// Places the best move in the grid
        /// </summary>
        /// <returns></returns>
        public bool PlaceBestMove() {
            int index = FindBestMove();

            Point location = new Point(index * squareSize + squareOffset, 0);

            return base.PlacePiece(location);
        }

        /// <summary>
        /// Copies the field to a new array
        /// </summary>
        /// <param name="field">The field to copy</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <returns>A copy of the field</returns>
        protected static Pieces[,] CopyField(Pieces[,] field, Size fieldSize) {
            Pieces[,] newField = new Pieces[fieldSize.Width, fieldSize.Height];

            for (int x = 0; x < fieldSize.Width; x++)
                for (int y = 0; y < fieldSize.Height; y++)
                    newField[x, y] = field[x, y];

            return newField;
        }

        /// <summary>
        /// Gets the best move for the AI
        /// </summary>
        /// <param name="field">The field to place a piece on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The length needed to win a game</param>
        /// <param name="currentPiece">The current piece to look for (the AI piece)</param>
        /// <param name="opponentPiece">The piece the opponent uses</param>
        /// <returns>The x-position of the best move</returns>
        protected static int GetBestMove(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece) {
            int[] moves = new int[fieldSize.Width];
            Pieces[,] testField;

            // Go through each x-position
            for (int x = 0; x < fieldSize.Width; x++) {
                // Find the y-position the piece will fall to
                int y = ProbeY(field, fieldSize, x);

                // If the piece is out-of-bounds, we can't place a piece here
                if (y <= -1 || y >= fieldSize.Height) {
                    moves[x] = int.MinValue;
                    continue;
                }

                // Makes a copy of the field
                testField = CopyField(field, fieldSize);

                // Places the current piece at the place
                testField[x, y] = currentPiece;

                // If that placement is a winning move, that means it is a move we really want to make, and that we won't have to look further after this move
                if (WinChecker.CheckForWin(testField, fieldSize, winLength)) {
                    moves[x] = int.MaxValue;
                    continue;
                }

                // If it is not a winning move, look at all the possible moves after this and see how well they hold up
                moves[x] = GetBestMove(testField, fieldSize, winLength, opponentPiece, currentPiece, searchDepth - 1, false);
            }

            // Here, we look for the best index/indeces
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

            // After we have a list of indeces (which will be at least 1), we either get the best move if there is 1 move, or a random one of the best moves if there are more
            if (bestIndeces.Count == 1)
                bestIndex = bestIndeces[0];
            else if (bestIndeces.Count >= 2)
                bestIndex = bestIndeces[random.Next(0, bestIndeces.Count)];

            // There is a random chance the AI will make a random move
            // We do this at the end so that the AI will always seem to think, even when it will make a random move
            // We make a random move to give the opponent a more fair chance, otherwhise you would have to "trick" the AI in order to win
            if (random.Next(0, 100) <= randomMoveChance) {
                List<int> availableColumns = new List<int>();
                for (int x = 0; x < fieldSize.Width; x++)
                    if (ProbeY(field, fieldSize, x) != -1)
                        availableColumns.Add(x);

                bestIndex = availableColumns[random.Next(0, availableColumns.Count)];
            }

            return bestIndex;
        }

        /// <summary>
        /// Gets the best move for the AI
        /// </summary>
        /// <param name="field">The field to look in</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The length needed to win</param>
        /// <param name="currentPiece">The piece we are currently looking for</param>
        /// <param name="opponentPiece">The piece of the opponent, when looking from the current piece</param>
        /// <param name="depth">How deep we want to look</param>
        /// <param name="isMax">Whether the player we are looking for is the AI or not (true for AI, false for not AI)</param>
        /// <returns>The x-position of the best move</returns>
        protected static int GetBestMove(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece, int depth, bool isMax) {
            // If we are at max depth, we are going to score the field
            if (depth <= 0) {
                // If the current move is a winning move, give it the best value (relative to the current player)
                // We also add 100 to the min value, so there is a (small) difference between a losing move for the AI, and "you can't put a piece here" when probing for the y-position
                if (WinChecker.CheckForWin(field, fieldSize, winLength))
                    return isMax ? (int.MaxValue - searchDepth) : (int.MinValue + searchDepth + 100);
                else {
                    int value = GetFieldValue(field, fieldSize, winLength, currentPiece, opponentPiece);
                    return value;
                }
            }
            
            int[] moves = new int[fieldSize.Width];
            Pieces[,] testField;

            // Look through each x-position
            for (int x = 0; x < fieldSize.Width; x++) {
                // Find the y-position to put the piece at
                int y = ProbeY(field, fieldSize, x);

                // If that position is out of bounds, set it as least desirable for the current player
                if (y <= 1 || y >= fieldSize.Height) {
                    moves[x] = isMax ? int.MinValue : int.MaxValue;
                    continue;
                }

                // Copy the field
                testField = CopyField(field, fieldSize);

                // Place a piece at the location found
                testField[x, y] = currentPiece;

                // Check if that move was a win, if it is, we can set it as desirable
                // In order to give a difference in how many moves it takes to get to that win, we lower (or increase for the Min-player) the value by how many layers we are deep
                if (WinChecker.CheckForWin(testField, fieldSize, winLength)) {
                    moves[x] = isMax ? (int.MaxValue - searchDepth + depth) : (int.MinValue + searchDepth - depth + 100);
                    continue;
                }

                // If it was not a winning move, look deeper
                moves[x] = GetBestMove(testField, fieldSize, winLength, opponentPiece, currentPiece, depth - 1, !isMax);
            }

            // Then, after looking at all the moves, the max player returns the maximum value, and the min player the minimum value
            return isMax ? moves.Max() : moves.Min();
        }

        /// <summary>
        /// Looks for the y-position to put a piece for a given column
        /// </summary>
        /// <param name="field">The field to look in</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="x">The column to look in</param>
        /// <returns>The y-position to look at (-1 if the column is full)</returns>
        protected static int ProbeY(Pieces[,] field, Size fieldSize, int x) {
            int availableY = -1;

            while (availableY < fieldSize.Height - 1 && field[x, availableY + 1] == Pieces.clear)
                availableY++;

            return availableY;
        }

        /// <summary>
        /// Gets the value of a specific field
        /// </summary>
        /// <param name="field">The field asses</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The length needed to win</param>
        /// <param name="currentPiece">The player to measure the field value for</param>
        /// <param name="opponentPiece">The opponent of the player</param>
        /// <returns>The value of the field</returns>
        protected static int GetFieldValue(Pieces[,] field, Size fieldSize, int winLength, Pieces currentPiece, Pieces opponentPiece) {
            int fieldValue = 0;

            // We look at the field and try to find all the 2-pieces, up to 1 less than the win length, and use the same algorithm that looks for a win
            for (int length = 2; length < winLength; length++) {
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

        /// <summary>
        /// Gets the horizontal value of the field for a piece
        /// </summary>
        /// <param name="field">The field to look in</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="checkLength">The length to check for</param>
        /// <param name="piece">The piece to look for</param>
        /// <returns></returns>
        protected static int HorizontalValue(Pieces[,] field, Size fieldSize, int checkLength, Pieces piece) {
            int horizontalValue = 0;

            for (int y = fieldSize.Height - 1; y >= 0; y--) {
                for (int x = 0; x <= fieldSize.Width - checkLength; x++) {
                    Pieces color = field[x, y];

                    if (color != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x + length, y] != color)
                            uninterrupted = false;

                    if (uninterrupted)
                        horizontalValue += checkLength * checkLength;
                }
            }

            return horizontalValue;
        }

        /// <summary>
        /// Checks if there is a vertical win
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="checkLength">The number of connected pieces to look for</param>
        /// <returns>True if ANY player has 4 vertically-connected pieces</returns>
        protected static int VerticalValue(Pieces[,] field, Size fieldSize, int checkLength, Pieces piece) {
            int verticalValue = 0;

            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y <= fieldSize.Height - checkLength; y++) {
                    Pieces color = field[x, y];

                    if (color != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x, y + length] != color)
                            uninterrupted = false;

                    if (uninterrupted)
                        verticalValue += checkLength * checkLength;
                }
            }

            return verticalValue;
        }

        /// <summary>
        /// Checks if there is a diagonal win that goes from top-left to bottom-right
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="checkLength">The number of connected pieces to look for</param>
        /// <returns>True if ANY player has 4 diagonally-connected pieces</returns>
        protected static int DiagonalRightValue(Pieces[,] field, Size fieldSize, int checkLength, Pieces piece) {
            int diagonalValue = 0;

            int x = 0, y = 0;
            // Loop through the three possible right-wards diagonals from the left most line
            for (; y <= fieldSize.Height - checkLength; y++) {
                // The 4-long line we look for has up to 3 starting positions, depending on the currentY we start at
                // To get that value, we take 3 (the max number of positions) and substract the current Y value
                for (int offset = 0; y + offset <= fieldSize.Height - checkLength; offset++) {
                    // The color of the top-left most piece we are looking at
                    Pieces currentColor = field[x + offset, y + offset];

                    // If the current color is clear (no piece present), we don't have to look
                    if (currentColor != piece)
                        continue;

                    // Look if the four tiles have the same color
                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += checkLength * checkLength;
                }
            }

            y = 0;
            x = 1;

            for (; x <= fieldSize.Width - checkLength; x++) {
                for (int offset = 0; x + offset <= fieldSize.Width - checkLength; offset++) {
                    Pieces currentColor = field[x + offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        diagonalValue += checkLength * checkLength;
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
        /// <param name="checkLength">The number of connected pieces to look for</param>
        /// <returns></returns>
        protected static int DiagonalLeftValue(Pieces[,] field, Size fieldSize, int checkLength, Pieces piece) {
            int diagonalValue = 0;

            int x = fieldSize.Width - 1, y = 0;

            for (; y <= fieldSize.Height - checkLength; y++) {
                for (int offset = 0; y + offset <= fieldSize.Height - checkLength; offset++) {
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += checkLength * checkLength;
                }
            }

            y = 0;
            // We go 2 back, 1 because the last column has an index of width - 1, and another 1 becuase we already checked the diagonal that starts in the last column
            x = fieldSize.Width - 2;

            for (; x > checkLength - 2; x--) {
                for (int offset = 0; x - offset > checkLength - 2; offset++) {
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor != piece)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < checkLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted)
                        diagonalValue += checkLength * checkLength;
                }
            }

            return diagonalValue;
        }
    }
}
