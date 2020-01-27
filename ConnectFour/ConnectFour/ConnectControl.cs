using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ConnectFour {
    /// <summary>
    /// The control to play Connect Four in
    /// </summary>
    public partial class ConnectControl : UserControl {
        #region Handle Double Buffering
        /// <summary>
        /// Override the Create Params property to allow double buffering
        /// </summary>
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        /// <summary>
        /// The instance of this control
        /// </summary>
        private static readonly ConnectControl _instance = new ConnectControl();

        /// <summary>
        /// The instance of this control
        /// </summary>
        public static ConnectControl instance {
            get {
                // Make sure the game is reset
                _instance.game.Reset();
                return _instance;
            }
        }

        /// <summary>
        /// The game the user is playing
        /// </summary>
        public AConnect game;

        /// <summary>
        /// Instantiates a new Connect Control
        /// </summary>
        protected ConnectControl() {
            InitializeComponent();

            game = new ClassicConnect();

            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }

        /// <summary>
        /// Draws the game to the panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel))
                return;

            if (game == null)
                return;

            game.Draw(e.Graphics);
        }

        /// <summary>
        /// Displays the turn number
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentTurnPanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            if (game == null)
                return;

            game.DrawCurrentPlayer(e.Graphics, panel);

            turnLabel.Text = $"Turn: {game.numPiecesOnBoard + 1}";
        }

        /// <summary>
        /// Allows the user to place pieces
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gamePanel_MouseClick(object sender, MouseEventArgs e) {
            if (!(sender is Panel))
                return;

            if (game == null)
                return;

            if (game.isGameOver)
                return;

            if (game.PlacePiece(e.Location)) {
                gamePanel.Invalidate();
                currentTurnPanel.Invalidate();
            }
        }

        /// <summary>
        /// Allows the user to play again
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void playAgainButton_Click(object sender, EventArgs e) {
            if (!(sender is Button))
                return;

            if (game == null)
                return;

            //game.Reset();
            game.Restart();

            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }

        /// <summary>
        /// Allows the user to go back to the main menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainMenuButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(MainMenu.instance);
        }

        /// <summary>
        /// Provides a tick to update the game, for animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animationTimer_Tick(object sender, EventArgs e) {
            if (!(sender is Timer timer))
                return;

            float deltaTime = timer.Interval / 1000.0f;

            game.Update(deltaTime);

            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }
    }
}
