using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// The event args for when the tab has changed
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tabs</typeparam>
    public class TabChangedEventArgs<T> {
        /// <summary>
        /// Empty event args
        /// </summary>
        public static TabChangedEventArgs<T> empty => new TabChangedEventArgs<T>(default, 0);

        /// <summary>
        /// The data is stored in the new tab
        /// </summary>
        public T data { get; private set; }
        /// <summary>
        /// The index of the new tab
        /// </summary>
        public int tabIndex { get; private set; }

        /// <summary>
        /// Instantiates new event args
        /// </summary>
        /// <param name="data">The data of the new tab</param>
        /// <param name="tabIndex">The index of the new tab</param>
        public TabChangedEventArgs(T data, int tabIndex) {
            this.data = data;
            this.tabIndex = tabIndex;
        }
    }
}
