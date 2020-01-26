using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour {
    public abstract class AConnect {
        /// <summary>
        /// The different possible pieces
        /// </summary>
        public enum Pieces {
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
        /// The typically blue field the pieces exist in
        /// </summary>
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
        /// The piece that will fall down when a player places his piece
        /// </summary>
        FallingPiece fallingPiece;

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
        protected int maxPiecesOnBoard => fieldSize.Width * fieldSize.Height;

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
        protected abstract Pieces nextPlayer { get; }// => currentPlayer == Pieces.red ? Pieces.yellow : Pieces.red;

        /// <summary>
        /// An instance of the random class for random values
        /// </summary>
        protected Random random;

        /// <summary>
        /// Instantiates a new game
        /// </summary>
        protected AConnect() {
            Reset(true);
        }

        /// <summary>
        /// Resets the playing field
        /// </summary>
        /// <param name="createBoard">An override whether to recreate the board [DEFAULT = FALSE]</param>
        public virtual void Reset(bool createBoard = false) {
            // If the board size changed, or we want to, we create a new board
            if (Settings.currentFieldSize != fieldSize || createBoard) {
                // First we calculate the new sizes and adjust stuff based on those calculations

                fieldSize = Settings.currentFieldSize;

                squareSize = CalculateSquareSize();

                squareOffset = (int)(squareSize * 0.1f);

                FallingPiece.fallSpeed = squareSize * (fieldSize.Height / 1.5f);

                // Then we are ready to construct the board image
                ConstructBoardImage();
            }

            // If the win-length needed to win changed, we need to check whether that win-length is possible in both axes
            if (Settings.currentWinLength != winLength) {
                winLength = Settings.currentWinLength;

                // Make sure the win-length is reachable both horizontally and vertically
                if (fieldSize.Height < winLength || fieldSize.Width < winLength) {
                    winLength = Math.Min(fieldSize.Height, fieldSize.Width);

                    ConnectFour.instance.ShowMessage($"You cannot have a win length of {Settings.currentWinLength} on this board! Set to {winLength}", Color.White);
                }
            }

            // Create the new field and reset all important values
            field = new Pieces[fieldSize.Width, fieldSize.Height];

            wonXpos = new int[winLength];
            wonYpos = new int[winLength];

            for (int i = 0; i < winLength; i++)
                wonXpos[i] = wonYpos[i] = -1;

            numPiecesOnBoard = 0;

            isGameOver = false;

            random = new Random();

            currentPlayer = random.Next(0, 2) switch
            {
                0 => Pieces.red,
                1 => Pieces.yellow,
                _ => Pieces.red,
            };
        }

        /// <summary>
        /// Constructs the image we use for the board.
        /// </summary>
        protected virtual void ConstructBoardImage() {
            // Create a new bitmap for our board sprite and fill it blue
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
                    // The x-location is X times the square size + the offset, and the same for the Y
                    location = new Point {
                        X = x * squareSize + squareOffset,
                        Y = y * squareSize + squareOffset
                    };

                    g.FillEllipse(brush, new Rectangle(location, size));
                }
            }

            // With this, every purple pixel in the bitmap will become transparent, creating the holes we want in the board
            boardSprite.MakeTransparent(Color.Purple);
        }

        /// <summary>
        /// Gets the brush based on the piece given
        /// </summary>
        /// <param name="piece">The piece to get a brush for</param>
        /// <returns>The brush with the same color as the piece</returns>
        protected virtual Brush GetBrushFromPiece(Pieces piece) => GetBrushFromPiece(piece, Settings.backgroundBrush);

        /// <summary>
        /// Gets the brush based on the piece given
        /// </summary>
        /// <param name="piece">The piece to get a brush for</param>
        /// <param name="defaultBrush">The color to return if none of the pieces match the case</param>
        /// <returns>The brush with the same color as the piece</returns>
        protected virtual Brush GetBrushFromPiece(Pieces piece, Brush defaultBrush) {
            return piece switch
            {
                Pieces.red => Brushes.Red,
                Pieces.yellow => Brushes.Yellow,
                Pieces.draw => Brushes.White,
                Pieces.green => Brushes.Green,
                _ => defaultBrush,
            };
        }

        /// <summary>
        /// Calculates the size of the squares based the current and default field size
        /// </summary>
        /// <returns>The size of a square</returns>
        private int CalculateSquareSize() {
            // The default square size of 60 is used on a 7x6 board
            // Larger boards will decrease and smaller boards will increase in square size, so they always fill in at least 1 axis

            // Calculate both factors for the two axes
            float verticalFactor = (float)defaultGridSize.Height / fieldSize.Height;
            float horizontalFactor = (float)defaultGridSize.Width / fieldSize.Width;

            // Get the smallest factor, this way we always see the whole board
            float smallestFactor = Math.Min(verticalFactor, horizontalFactor);

            // Calculate the square size based on the default square size
            int newSquareSize = (int)(defaultSquareSize * smallestFactor);

            return newSquareSize;
        }

        /// <summary>
        /// Updates the game to allow animations
        /// </summary>
        /// <param name="deltaTime">The time since the last call</param>
        public virtual void Update(float deltaTime) {
            // We only want to animate if the board is locked, as that means there is a piece currently falling
            if (!lockBoard)
                return;

            if (fallingPiece == null)
                return;

            fallingPiece.Update(deltaTime);

            // If the piece arrives at the desired location, we want to permanently put it in its place
            if (fallingPiece.atTargetY) {
                field[fallingPiece.xPos / squareSize, (int)(fallingPiece.yPos / squareSize)] = fallingPiece.pieceColor;

                // Check whether a player won the game with this move
                isGameOver = WinChecker.CheckForWin(field, fieldSize, winLength, ref wonXpos, ref wonYpos);

                // The piece has arrived at its spot, so we no longer want to lock the board
                lockBoard = false;

                // If a player won, we don't want to update the current player
                if (isGameOver)
                    return;

                numPiecesOnBoard++;

                currentPlayer = nextPlayer;
            }
        }

        /// <summary>
        /// Draws the playing board
        /// </summary>
        /// <param name="g">The instance of the graphics class</param>
        public virtual void Draw(Graphics g) {
            if (g == null || field == null)
                return;

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

                    squareBrush = GetBrushFromPiece(field[x, y]);

                    g.FillEllipse(squareBrush, new Rectangle(location, size));
                }
            }

            // If the board is locked, draw the falling piece
            if (lockBoard) {
                squareBrush = GetBrushFromPiece(fallingPiece.pieceColor);

                fallingPiece?.Draw(g, squareBrush, size, squareOffset);
            }

            // Draw the board over what we've drawn so far
            // This also makes it so the falling pieces are behind the board
            g.DrawImage(boardSprite, new Point(0, 0));

            // If the game is over, draw dots on the winning pieces and connect them with a line
            if (isGameOver) {
                // Drawing the dots on every winning piece

                Size dotSize = new Size((int)(squareSize * 0.2f), (int)(squareSize * 0.2f));

                for (int i = 0; i < winLength; i++) {
                    location = new Point {
                        X = wonXpos[i] * squareSize + (int)(squareSize * 0.4f),
                        Y = wonYpos[i] * squareSize + (int)(squareSize * 0.4f)
                    };

                    g.FillEllipse(Brushes.Black, new Rectangle(location, dotSize));
                }

                // Drawing the line through the pieces

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

            // Get the current player as a string, and capitalize it
            string currentPlayerString = currentPlayer.ToString().First().ToString().ToUpper() + currentPlayer.ToString().Substring(1);

            string textToDraw;

            // Set the text depending on whether the game is over or not
            if (isGameOver)
                textToDraw = $"{currentPlayerString} has won!";
            else if (numPiecesOnBoard == maxPiecesOnBoard) {
                textToDraw = "It is a draw!";
                currentPlayer = Pieces.draw;
            } else
                textToDraw = $"It is {currentPlayerString}'s turn";

            SizeF textSize = g.MeasureString(textToDraw, panel.Font);

            PointF location = new PointF {
                X = (panel.Width - textSize.Width) / 2,
                Y = (panel.Height - textSize.Height) / 2
            };

            Brush textColor = GetBrushFromPiece(currentPlayer, Brushes.White);

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

            // If there is a spot, create a new falling piece that will fall to there
            fallingPiece = new FallingPiece(column * squareSize, -squareSize, availableY * squareSize, currentPlayer);
            lockBoard = true;
            return true;
        }

        /// <summary>
        /// A piece that will fall down
        /// </summary>
        protected class FallingPiece {
            /// <summary>
            /// How many squares a piece falls per second
            /// </summary>
            public static float fallSpeed;
            /// <summary>
            /// The current x-position of the falling piece
            /// </summary>
            public int xPos { get; private set; }
            /// <summary>
            /// The current y-position of the falling piece
            /// </summary>
            public float yPos { get; private set; }
            /// <summary>
            /// The target y-position of the falling piece
            /// </summary>
            public int targetY { get; private set; }
            /// <summary>
            /// The color of the falling piece
            /// </summary>
            public Pieces pieceColor { get; private set; }
            /// <summary>
            /// Indicates whether the piece has arrived at the target y-position
            /// </summary>
            public bool atTargetY => yPos >= targetY;

            /// <summary>
            /// Instantiates a new piece that will fall down
            /// </summary>
            /// <param name="xPos">The x-position of the piece</param>
            /// <param name="yPos">The starting y-position of the piece</param>
            /// <param name="targetY">The target y-position of the piece</param>
            /// <param name="pieceColor">The color of the piece</param>
            public FallingPiece(int xPos, float yPos, int targetY, Pieces pieceColor) {
                this.xPos = xPos;
                this.yPos = yPos;
                this.targetY = targetY;
                this.pieceColor = pieceColor;
            }

            /// <summary>
            /// Updates the piece
            /// </summary>
            /// <param name="deltaTime">The elapsed time in seconds since the previous call</param>
            public void Update(float deltaTime) {
                yPos += fallSpeed * deltaTime;
            }

            /// <summary>
            /// Draws the piece
            /// </summary>
            /// <param name="g">The graphics instance to draw to</param>
            /// <param name="squareBrush">The brush used to draw with</param>
            /// <param name="drawSize">The size of the piece</param>
            /// <param name="squareOffset">The offset from the sides</param>
            public void Draw(Graphics g, Brush squareBrush, Size drawSize, int squareOffset) {
                // We make the piece a bit bigger to give the illusion that the piece is larger than the holes
                Size size = new Size((drawSize.Width + (squareOffset / 2)), (drawSize.Height + (squareOffset / 2)));

                // We draw the piece, and to offset for a bigger piece, we draw at a smaller offset
                g.FillEllipse(squareBrush, new RectangleF(new PointF(xPos + (squareOffset * 0.5f), yPos + (squareOffset * 0.5f)), size));
            }
        }
    }
}
