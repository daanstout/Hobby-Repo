using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A stack that can hold objects in a FiLo sequence
    /// </summary>
    /// <typeparam name="T">The type of object to store in the stack</typeparam>
    public sealed class Stack<T> {
        /// <summary>
        /// The stack
        /// </summary>
        private T[] stack;
        /// <summary>
        /// The maximum size of the stack
        /// </summary>
        private int maxStackSize;
        /// <summary>
        /// Whether the stack can grow if needed
        /// </summary>
        private readonly bool staticSize;

        /// <summary>
        /// Whether the stack is currently empty
        /// </summary>
        public bool isEmpty => size == 0;
        /// <summary>
        /// The size of the stack
        /// </summary>
        public int size { get; private set; }

        /// <summary>
        /// Instantiates a new stack
        /// </summary>
        /// <param name="staticSize">Whether the stack can grow if needed</param>
        public Stack(bool staticSize = false) : this(5, staticSize) { }

        /// <summary>
        /// Instantiates a new stack with a given stack size
        /// </summary>
        /// <param name="startStackSize">How many elements the stack can initially hold</param>
        /// <param name="staticSize">Whether the stack can grow if needed</param>
        public Stack(int startStackSize, bool staticSize = false) {
            maxStackSize = startStackSize;
            stack = new T[maxStackSize];
            size = 0;
            this.staticSize = staticSize;
        }

        /// <summary>
        /// Pushes an object onto the stack
        /// </summary>
        /// <param name="data">The object to push</param>
        /// <returns>True if the object was pushed succesfully</returns>
        public bool Push(T data) {
            if (size == maxStackSize) {
                if (staticSize)
                    return default;
                else
                    DoubleStack();
            }

            stack[size] = data;

            size++;

            return true;
        }

        /// <summary>
        /// Pops the top item off of the stack
        /// </summary>
        /// <returns>The top item of the stack</returns>
        public T Pop() {
            if (size == 0)
                return default;

            size--;
            T temp = stack[size];

            return temp;
        }

        /// <summary>
        /// Peeks at the top item on the stack, without popping it
        /// </summary>
        /// <returns>The item at the top of the stack</returns>
        public T Top() => size == 0 ? default : stack[size - 1];

        /// <summary>
        /// Creates and returns a copy of the stack
        /// </summary>
        /// <returns>A copy of the stack</returns>
        public T[] GetCopy() {
            var copy = new T[size];

            for (int i = 0; i < size; i++)
                copy[i] = stack[i];

            return copy;
        }

        /// <summary>
        /// Doubles the stack size and copies the elements over
        /// </summary>
        private void DoubleStack() {
            maxStackSize *= 2;
            T[] temp = new T[maxStackSize];

            for (int i = 0; i < maxStackSize / 2; i++)
                temp[i] = stack[i];

            stack = temp;
        }
    }
}
