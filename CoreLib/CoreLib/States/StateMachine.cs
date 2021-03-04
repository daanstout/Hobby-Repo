using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLib.States {
    /// <summary>A state machine that can hold an active state and operate on it</summary>
    /// <typeparam name="T">The type of object to operate on</typeparam>
    public class StateMachine<T> : IStateMachine<T> where T : new() {
        /// <summary>An instante of the null state so we don't have to keep creating it every time we need it</summary>
        private readonly NullState<T> nullState;

        /// <summary>The owner of this state machine</summary>
        protected T owner;
        /// <summary>The current state of this state machine</summary>
        protected IState<T> currentState;

        /// <summary>Instantiates a new State Machine with an owner, but no active state</summary>
        /// <param name="owner">The owner of this state machine</param>
        public StateMachine(T owner) : this(owner, null) { }
        /// <summary>Instantiates a new State Machine with an owner and an active state</summary>
        /// <param name="owner">The owner of this state machine</param>
        /// <param name="startingState">The initial state of the state machine</param>
        public StateMachine(T owner, IState<T> startingState) {
            this.owner = owner ?? throw new ArgumentNullException(nameof(owner));

            nullState = new NullState<T>();

            // If the starting state is null, set it to the null state so we always have a state.
            // We don't have to call Enter() because it doesn't do anything anyway.
            if (startingState == null)
                currentState = nullState;
            else { // If it is not null, we can set it and call the Enter() function
                currentState = startingState;

                currentState.Enter(owner);
            }
        }

        /// <inheritdoc/>
        public void ChangeState() {
            currentState.Exit(owner);

            currentState = nullState;
        }
        /// <inheritdoc/>
        public void ChangeState(IState<T> newState) {
            currentState.Exit(owner);

            if (newState == null)
                currentState = nullState;
            else {
                currentState = newState;

                currentState.Enter(owner);
            }
        }
        /// <inheritdoc/>
        public void Execute() => currentState.Execute(owner);
        /// <inheritdoc/>
        public void Execute(T target) => currentState.Execute(target);
        /// <inheritdoc/>
        public void SetOwner(T newOwner, bool callExitEnter = true) {
            if (callExitEnter) {
                currentState.Exit(owner);
                owner = newOwner ?? throw new ArgumentNullException(nameof(newOwner));
                currentState.Enter(owner);
            } else
                owner = newOwner ?? throw new ArgumentNullException(nameof(newOwner));
        }
        /// <inheritdoc/>
        public void SetState() => currentState = nullState;
        /// <inheritdoc/>
        public void SetState(IState<T> newState) {
            if (newState == null)
                currentState = nullState;
            else {
                currentState = newState;

                currentState.Enter(owner);
            }
        }
    }
}
