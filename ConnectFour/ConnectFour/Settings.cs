using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    public static class Settings {
        private static readonly Size[] fieldSizes = new Size[] { new Size(5, 4), new Size(7, 6), new Size(9, 8), new Size(11, 10) };

        private static int _currentFieldSizeIndex = 1;

        public static int currentFieldSizeIndex {
            get => _currentFieldSizeIndex;
            set => _currentFieldSizeIndex = Math.Min(fieldSizes.Length - 1, Math.Max(0, value));
        }

        public static Size currentFieldSize => fieldSizes[_currentFieldSizeIndex];

        private static int _currentWinLength = 4;

        public static int currentWinLength {
            get => _currentWinLength;
            set => _currentWinLength = Math.Min(5, Math.Max(3, value));
        }
    }
}
