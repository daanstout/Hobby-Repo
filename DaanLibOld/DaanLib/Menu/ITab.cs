using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// Displays a tab inside of the menu
    /// </summary>
    /// <typeparam name="T">The data that the tab stores</typeparam>
    public interface ITab<T> {
        /// <summary>
        /// The name of the tab
        /// </summary>
        string tabName { get; }
        /// <summary>
        /// The data that the tab contains
        /// </summary>
        T data { get; }
        /// <summary>
        /// Indicates whether the tab is currently selected
        /// </summary>
        bool selected { get; }

        /// <summary>
        /// Selects the tab
        /// </summary>
        /// <returns>The data the tab stores</returns>
        T Select();
        /// <summary>
        /// Deselects the tab
        /// </summary>
        void Deselect();

        /// <summary>
        /// Sets the tab information
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data that the tab contains</param>
        void SetInformation(string tabName, T data);
    }
}
