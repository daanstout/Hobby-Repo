using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MediaManager.Media;

namespace MediaManager.ViewControls {
    public partial class MoviesUserControl : UserControl {
        #region Handle Double Buffering
        /// <summary>
        /// Override the Create Params property to allow double buffering
        /// <para>Simply setting the property to true in the designer only applies doublebuffering to the application, but not the child controls</para>
        /// <para>This also applies double buffering to the child controls</para>
        /// </summary>
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        #endregion

        public static readonly MoviesUserControl instance = new MoviesUserControl();

        private readonly List<IMedia> movies;

        private readonly Size drawSize = new Size(100, 100);

        public MoviesUserControl() {
            InitializeComponent();

            movies = new List<IMedia>();

            ReadMovies(MediaManager.moviesDir);
        }

        private bool ReadMovies(string path) {
            if (string.IsNullOrEmpty(path))
                return false;

            string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);

            foreach (string file in files)
                movies.Add(new Movie(file));

            movies.Sort();

            return true;
        }

        private void moviesPanel_Paint(object sender, PaintEventArgs e) {
            if (!(sender is Panel panel))
                return;

            if (movies == null)
                return;

            Point drawLocation = new Point(0, 0);
            

            foreach (IMedia movie in movies) {
                movie.Draw(e.Graphics, drawLocation, drawSize, panel.Font);

                drawLocation.X += drawSize.Width + 20;

                if(drawLocation.X >= panel.Width - drawSize.Width) {
                    drawLocation.X = 0;
                    drawLocation.Y += drawSize.Height + 20;
                }
            }
        }
    }
}
