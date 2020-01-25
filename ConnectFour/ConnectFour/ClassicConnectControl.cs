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
    public partial class ClassicConnectControl : UserControl {
        private static readonly ClassicConnectControl _instance = new ClassicConnectControl();

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

        public static ClassicConnectControl instance {
            get {
                _instance.game.Reset();
                //_instance.mainMenuButton.Visible = false;
                //_instance.playAgainButton.Visible = false;
                return _instance;
            }
        }

        public ClassicConnect game;

        protected ClassicConnectControl() {
            InitializeComponent();

            game = new ClassicConnect();

            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel))
                return;

            if (game == null)
                return;

            game.Draw(e.Graphics);
        }

        private void currentTurnPanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            if (game == null)
                return;

            game.DrawCurrentPlayer(e.Graphics, panel);

            turnLabel.Text = $"Turn: {game.numPiecesOnBoard + 1}";
        }

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

                if (game.isGameOver) {
                    //playAgainButton.Visible = true;
                    //mainMenuButton.Visible = true;
                }
            }
        }

        private void playAgainButton_Click(object sender, EventArgs e) {
            if (!(sender is Button))
                return;

            if (game == null)
                return;

            game.Reset();
            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }

        private void mainMenuButton_Click(object sender, EventArgs e) {
            ConnectFour.instance.SetViewControl(MainMenu.instance);
        }

        private void animationTimer_Tick(object sender, EventArgs e) {
            //long time = stopwatch.ElapsedMilliseconds;
            //long deltaLong = time - previousTime;
            //previousTime = time;

            //float deltaTime = deltaLong * 1000f;

            if (!(sender is Timer timer))
                return;

            float deltaTime = timer.Interval / 1000.0f;

            game.Update(deltaTime);

            gamePanel.Invalidate();
            currentTurnPanel.Invalidate();
        }
    }
}
