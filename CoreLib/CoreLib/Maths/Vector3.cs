using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.Maths {
    /// <summary>A 3-dimensional vector</summary>
    public struct Vector3 {
        #region Variables
        #region Static Variables
        /// <summary>Returns a <see cref="Vector3"/> pointing up (0.0, 1.0, 0.0)</summary>
        public static Vector3 Up => new Vector3(0.0f, 1.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector3"/> pointing down (0.0f, -1.0, 0.0)</summary>
        public static Vector3 Down => new Vector3(0.0f, -1.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector3"/> pointing to the left (-1.0, 0.0, 0.0)</summary>
        public static Vector3 Left => new Vector3(-1.0f, 0.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector3"/> pointing to the right (1.0, 0.0, 0.0)</summary>
        public static Vector3 Right => new Vector3(1.0f, 0.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector3"/> pointing forwards (0.0, 0.0, 1.0)</summary>
        public static Vector3 Forward => new Vector3(0.0f, 0.0f, 1.0f);
        /// <summary>Returns a <see cref="Vector3"/> pointing backwards (0.0, 0.0, -1.0)</summary>
        public static Vector3 Back => new Vector3(0.0f, 0.0f - 1.0f);
        /// <summary>Returns a <see cref="Vector3"/> with all values set to 0.0</summary>
        public static Vector3 Zero => new Vector3(0.0f, 0.0f, 0.0f);
        /// <summary>Returns a <see cref="Vector3"/> with all values set to 1.0</summary>
        public static Vector3 One => new Vector3(1.0f, 1.0f, 1.0f);
        #endregion
        #region Member Variables
        /// <summary>The x-component of this <see cref="Vector2"/></summary>
        public float x;
        /// <summary>The y-component of this <see cref="Vector2"/></summary>
        public float y;
        /// <summary>The z-component of this <see cref="Vector2"/></summary>
        public float z;
        #endregion
        #region Properties
        #endregion
        #endregion
        #region Constructors
        /// <summary>Instantiates a new <see cref="Vector3"/> with the given value for the x, y, and z fields</summary>
        /// <param name="val">The value to initialize all components to</param>
        public Vector3(float val) => x = y = z = val;
        /// <summary>Instantiates a new <see cref="Vector3"/> with the given x and y values, and z to 0.0</summary>
        /// <param name="x">The x value</param>
        /// <param name="y">The y value</param>
        public Vector3(float x, float y) {
            this.x = x;
            this.y = y;
            z = 0.0f;
        }
        /// <summary>Instantiates a new <see cref="Vector3"/> with the given x, y, and z values</summary>
        /// <param name="x">The x value</param>
        /// <param name="y">The y value</param>
        /// <param name="z">The z value</param>
        public Vector3(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        /// <summary>Instantiates a new <see cref="Vector3"/> based on a given <see cref="Vector3"/></summary>
        /// <param name="vec">The vector to copy from</param>
        public Vector3(Vector3 vec) {
            x = vec.x;
            y = vec.y;
            z = vec.z;
        }
        /// <summary>Instantiates a new <see cref="Vector3"/> based on a given <see cref="Vector2"/></summary>
        /// <param name="vec">The vector to copy from</param>
        public Vector3(Vector2 vec) {
            x = vec.x;
            y = vec.y;
            z = 0.0f;
        }
        #endregion
    }
}
