using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour {
    /// <summary>
    /// A class to contain most of the application-wide settings
    /// </summary>
    public static class Settings {
        /// <summary>
        /// The possible sizes a field can have
        /// </summary>
        private static readonly Size[] fieldSizes = new Size[] { new Size(5, 4), new Size(7, 6), new Size(9, 8), new Size(11, 10) };

        /// <summary>
        /// The index of the currently used field
        /// </summary>
        private static int _currentFieldSizeIndex = 1;

        /// <summary>
        /// The index of the currently used field
        /// </summary>
        public static int currentFieldSizeIndex {
            get => _currentFieldSizeIndex;
            // Make sure to truncate the index to be within the bounds of the array
            set => _currentFieldSizeIndex = Math.Min(fieldSizes.Length - 1, Math.Max(0, value));
        }

        /// <summary>
        /// The current field size
        /// </summary>
        public static Size currentFieldSize => fieldSizes[_currentFieldSizeIndex];

        /// <summary>
        /// The number of connected pieces a player needs in order to win
        /// </summary>
        private static int _currentWinLength = 4;

        /// <summary>
        /// The number of connected pieces a player needs in order to win
        /// </summary>
        public static int currentWinLength {
            get => _currentWinLength;
            // Make sure to truncate the length
            set => _currentWinLength = Math.Min(5, Math.Max(3, value));
        }

        /// <summary>
        /// The brush to use for the background
        /// </summary>
        public static readonly Brush backgroundBrush = new SolidBrush(Color.FromArgb(70, 70, 70));
    }
}
