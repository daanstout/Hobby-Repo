using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour {
    public class ClassicConnect {
        /// <summary>
        /// The different possible pieces
        /// </summary>
        protected enum Pieces {
            clear = 0x0,
            red = 0x1,
            yellow = 0x2,
            green = 0x3,
            draw = 0x4
        }

        /// <summary>
        /// The default square size if the board is 7x6
        /// <para>This is used to calculate the square size of the board</para>
        /// </summary>
        protected static readonly int defaultSquareSize = 60;
        /// <summary>
        /// The default grid size
        /// <para>This is used to calculate the square size of the board</para>
        /// </summary>
        protected static readonly Size defaultGridSize = new Size(7, 6);

        /// <summary>
        /// The size of a square, both width and height
        /// </summary>
        protected int squareSize = defaultSquareSize;
        /// <summary>
        /// The offset from the edge to where the hole begins
        /// </summary>
        protected int squareOffset;

        /// <summary>
        /// The brush to use for the field
        /// </summary>
        protected readonly Brush fieldBrush = Brushes.Blue;
        /// <summary>
        /// The brush to use for the background
        /// </summary>
        protected readonly Brush backgroundBrush = new SolidBrush(Color.FromArgb(70, 70, 70));

        protected Bitmap boardSprite;

        /// <summary>
        /// The playing field
        /// </summary>
        protected Pieces[,] field;
        /// <summary>
        /// The size of the field
        /// </summary>
        public Size fieldSize { get; protected set; }
        /// <summary>
        /// How many connected pieces there must be in a line to win
        /// </summary>
        protected int winLength = 4;

        /// <summary>
        /// How many squares a piece falls per second
        /// </summary>
        protected float fallSpeed;
        /// <summary>
        /// The current x-position of the falling piece
        /// </summary>
        protected int xPos;
        /// <summary>
        /// The current y-position of the falling piece
        /// </summary>
        protected float yPos;
        /// <summary>
        /// The target y-position of the falling piece
        /// </summary>
        protected int targetY;
        /// <summary>
        /// The color of the falling piece
        /// </summary>
        protected Pieces pieceColor;
        /// <summary>
        /// If true, new pieces cannot be placed on the board
        /// <para>Is typically true if a piece is currently falling</para>
        /// </summary>
        protected bool lockBoard;

        /// <summary>
        /// The total number of pieces on the board
        /// </summary>
        public int numPiecesOnBoard { get; protected set; }
        /// <summary>
        /// The maximum number of pieces that fit on the board
        /// </summary>
        protected int maxPieces => fieldSize.Width * fieldSize.Height;

        /// <summary>
        /// Indicates whether the game is over
        /// </summary>
        public bool isGameOver { get; protected set; } = false;
        /// <summary>
        /// The 4 x-positions of the winning pieces
        /// </summary>
        protected int[] wonXpos;
        /// <summary>
        /// The 4 y-positions of the winning pieces
        /// </summary>
        protected int[] wonYpos;

        /// <summary>
        /// The color of the current player
        /// </summary>
        protected Pieces currentPlayer;
        /// <summary>
        /// The next player's color
        /// </summary>
        protected virtual Pieces nextPlayer => currentPlayer == Pieces.red ? Pieces.yellow : Pieces.red;

        /// <summary>
        /// An instance of the random class for random values
        /// </summary>
        protected Random random;

        /// <summary>
        /// Instantiates a new game
        /// </summary>
        /// <param name="width">How many pieces can be placed in the horizontally</param>
        /// <param name="height">How many pieces can be placed vertically</param>
        public ClassicConnect() {
            Reset(true);
        }

        /// <summary>
        /// Constructs the image we use for the board.
        /// </summary>
        protected virtual void ConstructBoardImage() {
            boardSprite = new Bitmap(fieldSize.Width * squareSize, fieldSize.Height * squareSize);

            using Graphics g = Graphics.FromImage(boardSprite);

            g.FillRectangle(fieldBrush, 0, 0, boardSprite.Width, boardSprite.Height);

            // we are going to use a small trick to create holes in the board for the pieces
            // We are going to draw purple circles where we want the holes
            // Then, when we have all the purple circles, we are going to have all purple bits become transparent at the end

            using SolidBrush brush = new SolidBrush(Color.Purple);
            Point location;
            // The size of a square is equal to the square size, minus twice the offset, as the offset has to be removed on both sides.
            Size size = new Size(squareSize - (squareOffset * 2), squareSize - (squareOffset * 2));

            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y < fieldSize.Height; y++) {
                    // The location is X square sizes + the offset, and the same for the Y
                    location = new Point {
                        X = x * squareSize + squareOffset,
                        Y = y * squareSize + squareOffset
                    };

                    g.FillEllipse(brush, new Rectangle(location, size));
                }
            }

            boardSprite.MakeTransparent(Color.Purple);
        }

        /// <summary>
        /// Resets the playing field
        /// </summary>
        public virtual void Reset(bool createBoard = false) {
            if (Settings.currentFieldSize != fieldSize || createBoard) {
                fieldSize = Settings.currentFieldSize;

                squareSize = CalculateSquareSize();

                squareOffset = (int)(squareSize * 0.1f);
                fallSpeed = squareSize * (fieldSize.Height / 1.5f);

                ConstructBoardImage();
            }
            if(Settings.currentWinLength != winLength) {
                winLength = Settings.currentWinLength;

                if(fieldSize.Height < winLength || fieldSize.Width < winLength) {
                    winLength = Math.Min(fieldSize.Height, fieldSize.Width);

                    ConnectFour.instance.ShowMessage($"You cannot have a win length of {Settings.currentWinLength} on this board! Set to {winLength}", Color.White);
                }
            }

            field = new Pieces[fieldSize.Width, fieldSize.Height];
            wonXpos = new int[winLength];
            wonYpos = new int[winLength];
            for (int i = 0; i < winLength; i++)
                wonXpos[i] = wonYpos[i] = -1;

            numPiecesOnBoard = 0;

            isGameOver = false;

            random = new Random();

            currentPlayer = random.Next(0, 2) == 0 ? Pieces.red : Pieces.yellow;
        }

        private int CalculateSquareSize() {
            float verticalFactor = (float)defaultGridSize.Height / fieldSize.Height;
            float horizontalFactor = (float)defaultGridSize.Width / fieldSize.Width;

            float smallestFactor = Math.Min(verticalFactor, horizontalFactor);

            int newSquareSize = (int)(defaultSquareSize * smallestFactor);

            return newSquareSize;
        }

        public virtual void Update(float deltaTime) {
            if (!lockBoard)
                return;

            yPos += fallSpeed * deltaTime;

            if (yPos >= targetY) {
                yPos = targetY;

                field[xPos / squareSize, (int)(yPos / squareSize)] = pieceColor;

                isGameOver = CheckForWin();

                numPiecesOnBoard++;

                lockBoard = false;

                // If a player won, we don't want to update the current player
                if (isGameOver)
                    return;

                currentPlayer = nextPlayer;
            }
        }

        /// <summary>
        /// Draws the playing board
        /// </summary>
        /// <param name="g">The instance of the graphics class</param>
        /// <param name="fieldSize">The size of the playing field in pixels</param>
        public virtual void Draw(Graphics g) {
            if (g == null || field == null)
                return;

            //g.FillRectangle(fieldBrush, new Rectangle(new Point(0, 0), fieldSize));

            Brush squareBrush;
            Point location;
            // The size of a square is equal to the square size, minus twice the offset, as the offset has to be removed on both sides.
            Size size = new Size(squareSize - (squareOffset * 2), squareSize - (squareOffset * 2));

            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y < fieldSize.Height; y++) {
                    if (field[x, y] == Pieces.clear)
                        continue;

                    // The location is X square sizes + the offset, and the same for the Y
                    location = new Point {
                        X = x * squareSize + squareOffset,
                        Y = y * squareSize + squareOffset
                    };

                    squareBrush = field[x, y] switch
                    {
                        Pieces.red => Brushes.Red,
                        Pieces.yellow => Brushes.Yellow,
                        Pieces.green => Brushes.Green,
                        _ => backgroundBrush,
                    };

                    g.FillEllipse(squareBrush, new Rectangle(location, size));
                }
            }

            if (lockBoard) {
                squareBrush = pieceColor switch
                {
                    Pieces.red => Brushes.Red,
                    Pieces.yellow => Brushes.Yellow,
                    Pieces.green => Brushes.Green,
                    _ => backgroundBrush,
                };

                size = new Size((int)(size.Width * 1.1f), (int)(size.Height * 1.1f));

                g.FillEllipse(squareBrush, new RectangleF(new PointF(xPos + (squareOffset * 0.5f), yPos + (squareOffset * 0.5f)), size));
            }

            g.DrawImage(boardSprite, new Point(0, 0));

            // If the game is over, draw dots on the winning pieces and connect them with a line
            if (isGameOver) {
                Size dotSize = new Size((int)(squareSize * 0.2f), (int)(squareSize * 0.2f));

                for (int i = 0; i < winLength; i++) {
                    location = new Point {
                        X = wonXpos[i] * squareSize + (int)(squareSize * 0.4f),
                        Y = wonYpos[i] * squareSize + (int)(squareSize * 0.4f)
                    };

                    g.FillEllipse(Brushes.Black, new Rectangle(location, dotSize));
                }

                using Pen pen = new Pen(Color.Black, squareSize / 15.0f);


                location = new Point {
                    X = wonXpos[0] * squareSize + (int)(squareSize * 0.5f),
                    Y = wonYpos[0] * squareSize + (int)(squareSize * 0.5f)
                };

                Point location2 = new Point {
                    X = wonXpos[winLength - 1] * squareSize + (int)(squareSize * 0.5f),
                    Y = wonYpos[winLength - 1] * squareSize + (int)(squareSize * 0.5f)
                };

                g.DrawLine(pen, location, location2);

            }
        }

        /// <summary>
        /// Draws the current player's turn to the panel
        /// </summary>
        /// <param name="g">The graphics instance to draw too</param>
        /// <param name="panel">The panel we draw in</param>
        public virtual void DrawCurrentPlayer(Graphics g, Panel panel) {
            if (g == null || panel == null)
                return;

            string textToDraw;

            string currentPlayerString = currentPlayer.ToString().First().ToString().ToUpper() + currentPlayer.ToString().Substring(1);

            // Set the text depending on whether the game is over or not
            if (isGameOver)
                textToDraw = $"{currentPlayerString} has won!";
            else if (numPiecesOnBoard == maxPieces) {
                textToDraw = "It is a draw!";
                currentPlayer = Pieces.draw;
            } else
                textToDraw = $"It is {currentPlayerString}'s turn";

            SizeF textSize = g.MeasureString(textToDraw, panel.Font);

            PointF location = new PointF {
                X = (panel.Width - textSize.Width) / 2,
                Y = (panel.Height - textSize.Height) / 2
            };

            Brush textColor = currentPlayer switch
            {
                Pieces.red => Brushes.Red,
                Pieces.yellow => Brushes.Yellow,
                Pieces.draw => Brushes.White,
                Pieces.green => Brushes.Green,
                _ => Brushes.White,
            };

            g.DrawString(textToDraw, panel.Font, textColor, location);
        }

        /// <summary>
        /// Attempts to place a piece on the board
        /// </summary>
        /// <param name="location">The location to place a piece. (Only the X-value is really relevant)</param>
        /// <returns>True if a piece was placed, false if a piece could not be placed</returns>
        public virtual bool PlacePiece(Point location) {
            if (location.X < 0 || location.X >= fieldSize.Width * squareSize ||
                location.Y < 0 || location.Y >= fieldSize.Height * squareSize)
                return false;

            if (isGameOver || lockBoard)
                return true;

            // Get the column the piece was placed in
            // We don't have to check if it fits because the first if-statement makes sure we are not out of bounds
            int column = location.X / squareSize;
            int availableY = -1;

            // Look where we can place a piece
            for (int y = 0; y < fieldSize.Height; y++) {
                if (field[column, y] == Pieces.clear)
                    availableY = y;
                else
                    break;
            }

            // If there are no available spaces in the column, we can't place a piece
            if (availableY == -1)
                return false;

            //            private int xPos;
            //private float yPos;
            //private int targetY;
            //private Pieces pieceColor;
            //private bool lockBoard;

            xPos = column * squareSize;
            yPos = -squareSize;
            targetY = availableY * squareSize;
            pieceColor = currentPlayer;
            lockBoard = true;

            //field[column, availableY] = currentPlayer;

            // Check whether there is a win for either player


            return true;
        }

        /// <summary>
        /// Checks for a win, for all players
        /// </summary>
        /// <returns>True if ANY player has 4 connected pieces</returns>
        protected virtual bool CheckForWin() => CheckHorizontal() || CheckVertical() || CheckDiagonalLeft() || CheckDiagonalRight();

        /// <summary>
        /// Checks if there is a horizontal win
        /// </summary>
        /// <returns>True if ANY player has 4 horizontally-connected pieces</returns>
        protected virtual bool CheckHorizontal() {
            for (int y = fieldSize.Height - 1; y >= 0; y--) {
                for (int x = 0; x <= fieldSize.Width - winLength; x++) {
                    Pieces color = field[x, y];

                    if (color == Pieces.clear)
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
        /// <returns>True if ANY player has 4 vertically-connected pieces</returns>
        protected virtual bool CheckVertical() {
            for (int x = 0; x < fieldSize.Width; x++) {
                for (int y = 0; y <= fieldSize.Height - winLength; y++) {
                    Pieces color = field[x, y];

                    if (color == Pieces.clear)
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
        /// <returns>True if ANY player has 4 diagonally-connected pieces</returns>
        protected virtual bool CheckDiagonalRight() {
            int x = 0, y = 0;
            // Loop through the three possible right-wards diagonals from the left most line
            for (; y <= fieldSize.Height - winLength; y++) {
                // The 4-long line we look for has up to 3 starting positions, depending on the currentY we start at
                // To get that value, we take 3 (the max number of positions) and substract the current Y value
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    // The color of the top-left most piece we are looking at
                    Pieces currentColor = field[x + offset, y + offset];

                    // If the current color is clear (no piece present), we don't have to look
                    if (currentColor == Pieces.clear)
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
                    Pieces currentColor = field[x + offset, y + offset];

                    if (currentColor == Pieces.clear)
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
        /// <returns>True if ANY player has 4 diagonally-connected pieces</returns>
        protected virtual bool CheckDiagonalLeft() {
            int x = fieldSize.Width - 1, y = 0;

            for (; y <= fieldSize.Height - winLength; y++) {
                for (int offset = 0; y + offset <= fieldSize.Height - winLength; offset++) {
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor == Pieces.clear)
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
                    Pieces currentColor = field[x - offset, y + offset];

                    if (currentColor == Pieces.clear)
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
