using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerDefense.Entities {
    /// <summary>
    /// A tickable object
    /// </summary>
    interface ITickable {
        /// <summary>
        /// Initializes the object
        /// </summary>
        void Initialize();
        /// <summary>
        /// Updates the object
        /// </summary>
        /// <param name="deltaTime">The delta time between updates</param>
        void Update(float deltaTime);
        /// <summary>
        /// Pauses the object
        /// </summary>
        void Pause();
        /// <summary>
        /// Awakes the object
        /// </summary>
        void Awake();
        /// <summary>
        /// Destroys the object
        /// </summary>
        void Destroy();
        /// <summary>
        /// Renders the object
        /// </summary>
        /// <param name="g">The graphics instance to draw too</param>
        void Render(Graphics g);
    }
}
