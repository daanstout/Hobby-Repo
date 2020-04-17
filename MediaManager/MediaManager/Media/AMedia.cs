using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Shell;

namespace MediaManager.Media {
    public abstract class AMedia : IMedia, IEquatable<AMedia> {
        protected readonly Size iconSize = new Size(100, 50);

        public string path { get; protected set; }
        public string name => fileInfo.Name;
        public string extension => fileInfo.Extension;
        public int year { get; protected set; }
        public Icon icon => Icon.ExtractAssociatedIcon(path);
        public List<string> tags { get; protected set; }
        public int rating { get; protected set; }

        protected FileInfo fileInfo { get; set; }

        protected AMedia(string filePath) {
            path = filePath;

            fileInfo = new FileInfo(path);
        }

        ~AMedia() {
            icon.Dispose();
        }

        public void Draw(Graphics g, Point drawLocation, Size drawSize, Font nameFont) {
            //g.FillRectangle(Brushes.Red, new Rectangle(drawLocation, drawSize));
            //g.DrawImage(icon.ToBitmap(), new Rectangle(drawLocation, drawSize));

            Bitmap image = ShellFile.FromFilePath(path).Thumbnail.LargeBitmap;
            g.DrawImage(image, new Rectangle(drawLocation, iconSize));
            //g.DrawString(name, nameFont, Brushes.White, drawLocation.X, drawLocation.Y + iconSize.Height + 10);
            TextRenderer.DrawText(g, name, nameFont, new Rectangle(drawLocation.X, drawLocation.Y + iconSize.Height + 10, drawSize.Width, drawSize.Height - iconSize.Height - 10), Color.White, TextFormatFlags.WordBreak);
        }

        public override bool Equals(object obj) => Equals(obj as AMedia);
        public bool Equals(AMedia other) => other != null && path == other.path;
        public override int GetHashCode() => -1757656154 + EqualityComparer<string>.Default.GetHashCode(path);
        public int CompareTo(object obj) => CompareTo(obj as AMedia);
        public int CompareTo(IMedia other) => path.CompareTo(other.path);
    }
}
