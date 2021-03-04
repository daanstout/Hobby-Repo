using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.States {
    /// <summary>
    /// A state the state machine can be in
    /// </summary>
    /// <typeparam name="T">The type of object the state operates on</typeparam>
    public interface IState<T> where T : new() {
        /// <summary>
        /// Activates when the state becomes the active state
        /// </summary>
        /// <param name="obj">The object to operate on</param>
        void Enter(T obj);

        /// <summary>
        /// Activates once per update
        /// </summary>
        /// <param name="obj">The object to operate on</param>
        void Execute(T obj);

        /// <summary>
        /// Activates when the state becomes an inactive state
        /// </summary>
        /// <param name="obj">The object to operate on</param>
        void Exit(T obj);
    }
}
