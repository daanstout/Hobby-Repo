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
    public struct StateMachine<T> : IStateMachine<T> where T : new() {
        /// <summary>
        /// The owner of this state machine
        /// </summary>
        private T owner;
        /// <summary>
        /// The current state of this state machine
        /// </summary>
        private IState<T> currentState;

        /// <summary>
        /// Instantiates a new State Machine with a given owner
        /// </summary>
        /// <param name="owner">The owner of this state machine</param>
        public StateMachine(T owner) : this(owner, null) { }
        /// <summary>
        /// Instantiates a new State Machine with a given owner and a starting state
        /// </summary>
        /// <param name="owner">THe owner of this state machine</param>
        /// <param name="startingState">The starting state of this state machine</param>
        public StateMachine(T owner, IState<T> startingState) {
            this.owner = owner;
            currentState = startingState;

            currentState?.Enter(owner);
        }

        /// <summary>
        /// Changes the state of the state machine
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void ChangeState(IState<T> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            currentState?.Exit(owner);
            currentState = newState ?? throw new ArgumentNullException("New state is null");
            currentState.Enter(owner);
        }

        /// <summary>
        /// Sets the state of the state machine without properly exiting the previous state
        /// </summary>
        /// <param name="newState">The new state of the state machine</param>
        public void SetState(IState<T> newState) {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            currentState = newState ?? throw new ArgumentNullException("New state is null");
            currentState.Enter(owner);
        }

        /// <summary>
        /// Sets the owner of the state machine
        /// </summary>
        /// <param name="newOwner">The owner of the state machine</param>
        public void SetOwner(T newOwner) => owner = newOwner ?? throw new ArgumentNullException("New owner is null");

        /// <summary>
        /// Updates the state machine
        /// </summary>
        public void Update() {
            if (owner == null)
                throw new NullReferenceException("This state machine does not have an owner, please make sure the state machine has an owner");

            currentState.Execute(owner);
        }

        /// <summary>
        /// Updates the state machine on a specific object
        /// </summary>
        /// <param name="obj">The object to operate on</param>
        public void Update(T obj) {
            if (obj == null)
                throw new ArgumentNullException("Obj to operate on is null");

            currentState.Execute(obj);
        }
    }
}
