using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.States {
    /// <summary>A state the state machine can be in</summary>
    /// <typeparam name="T">The type of object the state operates on</typeparam>
    public interface IState<T> where T: new() {
        /// <summary>Is called when the state becomes the activate state</summary>
        /// <param name="obj">The object to operate on</param>
        void Enter(T obj);
        /// <summary>Is called when the state should execute 1 cycle, typically called once per update</summary>
        /// <param name="obj">The object to operate on</param>
        void Execute(T obj);
        /// <summary>Is called when the state is switched out for a different state</summary>
        /// <param name="obj">The object to operate on</param>
        void Exit(T obj);
    }
}
