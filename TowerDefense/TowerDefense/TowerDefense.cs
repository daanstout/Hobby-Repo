using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DaanLib;
using TowerDefense.Rendering.TileRenderer;
using TowerDefense.World;
using TowerDefense.World.Tiles;

namespace TowerDefense {
    /// <summary>
    /// The core of the Tower Defense game
    /// </summary>
    public partial class TowerDefense : Form {
        /// <summary>
        /// The instance of the game
        /// </summary>
        public static TowerDefense instance;

        /// <summary>
        /// Indicates whether the player has lost yet
        /// </summary>
        public bool gameOver = false;

        private bool showVerteces = false;

        /// <summary>
        /// The world instance
        /// </summary>
        GameWorld world;

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

        /// <summary>
        /// Creates a new Tower Defense game
        /// </summary>
        public TowerDefense() {
            // Set the public instance
            instance = this;

            // Initialize the WinForms components
            InitializeComponent();

            // Set the game panel to double buffering
            // see: https://stackoverflow.com/a/31562892
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, gamePanel, new object[] { true });

            // Create the game world
            world = new GameWorld(gamePanel.Width, gamePanel.Height);

            // Render the background for the first time
            RedrawBackground();

            // Start the game loop
            GameLoopWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Starts the game loop
        /// </summary>
        private void StartGameLoop() {
            const float tickInterval = 1f / 60f;
            float timeTillTick = tickInterval;
            // We loop untill the player has lost
            while (!gameOver) {
                // If the delta time is larger than the tick interval we have set, then something is eating up processing power, for now we throw an exception
                if (Time.deltaTimeMillis > tickInterval)
                    throw new TimeoutException("The tick time has become to long, do something about this");

                // We update the time till we tick
                timeTillTick -= Time.deltaTimeMillis;

                if (timeTillTick <= 0) {
                    // When we have reached our tick mark, we tick
                    world.Update();
                    gamePanel.Invalidate();
                    timeTillTick = tickInterval;
                }
            }
        }

        /// <summary>
        /// Redraws the background of the game
        /// <para>This can be quite intensive, so don't use this every frame</para>
        /// </summary>
        public void RedrawBackground() {
            // Create a new image
            Bitmap bm = new Bitmap(world.gameWidth, world.gameHeight);

            // Get a graphics instance from the image so we can draw to the image
            Graphics g = Graphics.FromImage(bm);

            // Draw the background to the image
            world.RenderBackground(g);

            // Dispose of the previous image and set the new image as the background
            gamePanel.BackgroundImage?.Dispose();
            gamePanel.BackgroundImage = bm;

            // Force the garbace collection to start collecting garbage
            GC.Collect();
        }

        /// <summary>
        /// Upon invalidating the game panel, it renders the world
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments of the event</param>
        private void GamePanel_Paint(object sender, PaintEventArgs e) => world.Render(e.Graphics);

        /// <summary>
        /// Allows the user to drag the window
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments of the event</param>
        private void BannerPanel_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left) {
                NativeMethods.HandleWindowDrag(Handle);
            }
        }

        /// <summary>
        /// Starts the game loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoopWorker_DoWork(object sender, DoWorkEventArgs e) => StartGameLoop();

        /// <summary>
        /// Stops the game loop when the worker is cancelled
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameLoopWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => gameOver = e.Cancelled;

        /// <summary>
        /// Toggles the Tile Renderer between VertexTileRendere and SimpleTileRenderer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToggleVertexButton_Click(object sender, EventArgs e) {
            showVerteces = !showVerteces;

            if (showVerteces) {
                BaseTile.SetRenderer(new VertexTileRenderer());
                (sender as Control).Text = "Hide Verteces";
            } else {
                BaseTile.SetRenderer(new SimpleTileRenderer());
                (sender as Control).Text = "Show Verteces";
            }

            RedrawBackground();
        }
    }
}
