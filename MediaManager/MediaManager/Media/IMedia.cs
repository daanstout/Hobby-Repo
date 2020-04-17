using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaManager.Media {
    public interface IMedia : IComparable, IComparable<IMedia> {
        string path { get; }
        string name { get; }
        string extension { get; }
        int year { get; }
        Icon icon { get; }
        List<string> tags { get; }
        int rating { get; }

        public void Draw(Graphics g, Point drawLocation, Size drawSize, Font nameFont);
    }
}
