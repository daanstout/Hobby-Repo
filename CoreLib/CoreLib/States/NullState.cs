using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.States {
    /// <summary>A Null state that does nothing. Can be useful if an object shouldn't do anything for a while and just wait</summary>
    /// <typeparam name="T">The type of object the state operates on</typeparam>
    public struct NullState<T> : IState<T> where T : new() {
        /// <inheritdoc/>
        public void Enter(T obj) { }
        /// <inheritdoc/>
        public void Execute(T obj) { }
        /// <inheritdoc/>
        public void Exit(T obj) { }
    }
}
