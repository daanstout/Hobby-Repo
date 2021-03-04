using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.States {
    /// <summary>A state machine that can hold different <see cref="IState{T}"/></summary>
    /// <typeparam name="T">The type of object The state machine operates on</typeparam>
    public interface IStateMachine<T> where T : new() {
        /// <summary>Changes the <see cref="IState{T}"/> of the state machine to the NULL-State</summary>
        void ChangeState();
        /// <summary>Changes the <see cref="IState{T}"/> of the state machine</summary>
        /// <param name="newState">The new <see cref="IState{T}"/> the state machine should adopt</param>
        void ChangeState(IState<T> newState);
        /// <summary>Sets the owner of the state machine</summary>
        /// <param name="newOwner">The new owner of the state machine</param>
        /// <param name="callExitEnter">Whether or not to call the exit and enter functions on the current <see cref="IState{T}"/> with the old and new owners respectively</param>
        void SetOwner(T newOwner, bool callExitEnter);
        /// <summary>Sets the <see cref="IState{T}"/> of the state machine to the NULL-State. This does not call the <see cref="IState{T}.Exit(T)"/> function on the old state</summary>
        void SetState();
        /// <summary>Sets the <see cref="IState{T}"/> of the state machine. This does not call the <see cref="IState{T}.Exit(T)"/> function on the old state</summary>
        /// <param name="newState">The new state the state machine should adopt</param>
        void SetState(IState<T> newState);
        /// <summary>Executes 1 cycle of the <see cref="IState{T}"/></summary>
        void Execute();
        /// <summary>Executes 1 cycle of the <see cref="IState{T}"/> on the target</summary>
        /// <param name="target">The target to execute the <see cref="IState{T}"/> on</param>
        void Execute(T target);
    }
}
