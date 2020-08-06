using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.States {
    /// <summary>
    /// A state machine that can hold an active state and operate on it
    /// </summary>
    /// <typeparam name="T">The object to operate on</typeparam>
    public interface IStateMachine<T> where T : new() {
        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void ChangeState(IState<T> newState);
        /// <summary>
        /// Sets the owner of the state machine
        /// </summary>
        /// <param name="newOwner">The owner of the state machine</param>
        void SetOwner(T newOwner);
        /// <summary>
        /// Sets the state of the state machine without properly exiting the previous state
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        void SetState(IState<T> newState);
        /// <summary>
        /// Updates the state machine
        /// </summary>
        void Update();
        /// <summary>
        /// Updates the state machine on a specific object
        /// </summary>
        /// <param name="obj">The object to operate on</param>
        void Update(T obj);
    }
}
