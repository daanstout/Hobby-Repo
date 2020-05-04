using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Menu {
    /// <summary>
    /// A tab that is part of the menu
    /// </summary>
    /// <typeparam name="T">The type of data stored in the tab</typeparam>
    public class Tab<T> : ITab<T> {
        /// <summary>
        /// The name of the tab
        /// </summary>
        public string tabName { get; private set; }
        /// <summary>
        /// The data this tab stores
        /// </summary>
        public T data { get; private set; }
        /// <summary>
        /// Whether this tab is currently selected or not
        /// </summary>
        public bool selected { get; internal set; }

        /// <summary>
        /// Deselects the tab
        /// </summary>
        public virtual void Deselect() => selected = false;

        /// <summary>
        /// Selects the tab and returns the data stored in the tab
        /// </summary>
        /// <returns>The data stored in the tab</returns>
        public virtual T Select() {
            selected = true;
            return data;
        }

        /// <summary>
        /// Sets the tab's information
        /// </summary>
        /// <param name="tabName">The name of the tab</param>
        /// <param name="data">The data this tab should store</param>
        public virtual void SetInformation(string tabName, T data) {
            this.tabName = tabName;
            this.data = data;
        }
    }
}
