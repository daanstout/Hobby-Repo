using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    /// <summary>
    /// Can check a board for a winning set of pieces by 1 player
    /// </summary>
    public static class WinChecker {
        /// <summary>
        /// Whether the pieces can be horizontally connected
        /// </summary>
        public static bool checkHorizontal = true;
        /// <summary>
        /// Whether the pieces can be vertically connected
        /// </summary>
        public static bool checkVertical = true;
        /// <summary>
        /// Whether the pieces can be diagonally connected
        /// </summary>
        public static bool checkDiagonal = true;

        /// <summary>
        /// Checks for a win, for all players
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The number of connected pieces to look for</param>
        /// <param name="wonXpos">If a win was found, contains the x-positions of the winning pieces</param>
        /// <param name="wonYpos">If a win was found, contains the y-positions of the winning pieces</param>
        /// <returns>True if ANY player has 4 connected pieces</returns>
        public static bool CheckForWin(AConnect.Pieces[,] field, Size fieldSize, int winLength, ref int[] wonXpos, ref int[] wonYpos) {
            bool result = CheckHorizontal(field, fieldSize, winLength, ref wonXpos, ref wonYpos);
            result |= CheckVertical(field, fieldSize, winLength, ref wonXpos, ref wonYpos);
            result |= CheckDiagonalLeft(field, fieldSize, winLength, ref wonXpos, ref wonYpos);
            result |= CheckDiagonalRight(field, fieldSize, winLength, ref wonXpos, ref wonYpos);

            return result;
        }

        /// <summary>
        /// Checks if there is a horizontal win
        /// </summary>
        /// <param name="field">The field to perform the check on</param>
        /// <param name="fieldSize">The size of the field</param>
        /// <param name="winLength">The number of connected pieces to look for</param>
        /// <param name="wonXpos">If a win was found, contains the x-positions of the winning pieces</param>
        /// <param name="wonYpos">If a win was found, contains the y-positions of the winning pieces</param>
        /// <returns>True if ANY player has 4 horizontally-connected pieces</returns>
        private static bool CheckHorizontal(AConnect.Pieces[,] field, Size fieldSize, int winLength, ref int[] wonXpos, ref int[] wonYpos) {
            if (!checkHorizontal)
                return false;

            for (int y = fieldSize.Height - 1; y >= 0; y--) {
                for (int x = 0; x <= fieldSize.Width - winLength; x++) {
                    AConnect.Pieces color = field[x, y];

                    if (color == AConnect.Pieces.clear)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + length, y] != color)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];
                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x + i;
                            wonYpos[i] = y;
                        }

                        return true;
                    }
                }
            }

            return false;
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
        private static bool CheckVertical(AConnect.Pieces[,] field, Size fieldSize, int winLength, ref int[] wonXpos, ref int[] wonYpos) {
            if (!checkVertical)
                return false;

            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y <= fieldSize.Height - winLength; y++) {
                    AConnect.Pieces color = field[x, y];

                    if (color == AConnect.Pieces.clear)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x, y + length] != color)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];

                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x;
                            wonYpos[i] = y + i;
                        }

                        return true;
                    }
                }
            }

            return false;
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
        private static bool CheckDiagonalRight(AConnect.Pieces[,] field, Size fieldSize, int winLength, ref int[] wonXpos, ref int[] wonYpos) {
            if (!checkDiagonal)
                return false;

            int x = 0, y = 0;
            // Loop through the three possible right-wards diagonals from the left most line
            for (; y <= fieldSize.Height - winLength; y++) {
                // The 4-long line we look for has up to 3 starting positions, depending on the currentY we start at
                // To get that value, we take 3 (the max number of positions) and substract the current Y value
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    // The color of the top-left most piece we are looking at
                    AConnect.Pieces currentColor = field[x + offset, y + offset];

                    // If the current color is clear (no piece present), we don't have to look
                    if (currentColor == AConnect.Pieces.clear)
                        continue;

                    // Look if the four tiles have the same color
                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];
                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x + offset + i;
                            wonYpos[i] = y + offset + i;
                        }

                        return true;
                    }
                }
            }

            y = 0;
            x = 1;

            for (; x <= fieldSize.Width - winLength; x++) {
                for (int offset = 0; x + offset <= fieldSize.Width - winLength; offset++) {
                    AConnect.Pieces currentColor = field[x + offset, y + offset];

                    if (currentColor == AConnect.Pieces.clear)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x + offset + length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];
                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x + offset + i;
                            wonYpos[i] = y + offset + i;
                        }

                        return true;
                    }
                }
            }

            return false;
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
        private static bool CheckDiagonalLeft(AConnect.Pieces[,] field, Size fieldSize, int winLength, ref int[] wonXpos, ref int[] wonYpos) {
            if (!checkDiagonal)
                return false;

            int x = fieldSize.Width - 1, y = 0;

            for (; y <= fieldSize.Height - winLength; y++) {
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    AConnect.Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor == AConnect.Pieces.clear)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];
                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x - offset - i;
                            wonYpos[i] = y + offset + i;
                        }

                        return true;
                    }
                }
            }

            y = 0;
            // We go 2 back, 1 because the last column has an index of width - 1, and another 1 becuase we already checked the diagonal that starts in the last column
            x = fieldSize.Width - 2;

            for (; x > winLength - 2; x--) {
                for (int offset = 0; x - offset > winLength - 2; offset++) {
                    AConnect.Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor == AConnect.Pieces.clear)
                        continue;

                    bool uninterrupted = true;
                    for (int length = 1; length < winLength; length++)
                        if (field[x - offset - length, y + offset + length] != currentColor)
                            uninterrupted = false;

                    if (uninterrupted) {
                        wonXpos = new int[winLength];
                        wonYpos = new int[winLength];
                        for (int i = 0; i < winLength; i++) {
                            wonXpos[i] = x - offset - i;
                            wonYpos[i] = y + offset + i;
                        }

                        return true;
                    }
                }
            }

            return false;
        }
    }
}
