using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaanLib.Datastructures {
    /// <summary>
    /// A Queue that can hold objects in a FiFo sequence
    /// </summary>
    /// <typeparam name="T">The type of object stored in the queue</typeparam>
    public sealed class Queue<T> {
        /// <summary>
        /// The queue
        /// </summary>
        private T[] queue;
        /// <summary>
        /// The index of the element at the front
        /// </summary>
        private int front;
        /// <summary>
        /// The index of the open element at the back
        /// </summary>
        private int back;
        /// <summary>
        /// The maximum amount of objects the queue can hol
        /// </summary>
        private int queueMaxSize;
        /// <summary>
        /// Whether the queue can grow larger if an object wants to be enqueued into a full queue
        /// </summary>
        private readonly bool staticSize;

        /// <summary>
        /// Indicates whether the queue contains no elements
        /// </summary>
        public bool isEmpty => size == 0;

        /// <summary>
        /// The number of elements in the queue
        /// </summary>
        public int size { get; private set; }

        /// <summary>
        /// Instantiates a new Queue
        /// </summary>
        /// <param name="staticSize">Whether the queue is allowed to grow larger if needed</param>
        public Queue(bool staticSize = false) : this(5, staticSize) { }

        /// <summary>
        /// Instantiates a new Queue with a certain start size
        /// </summary>
        /// <param name="queueStartSize">How many elements the queue can initially hold</param>
        /// <param name="staticSize">Whether the queue is allowed to grow larger if needed</param>
        public Queue(int queueStartSize, bool staticSize = false) {
            queue = new T[queueStartSize];
            queueMaxSize = queueStartSize;
            front = back = size = 0;
            this.staticSize = staticSize;
        }

        /// <summary>
        /// Enqueues an item on the queue
        /// </summary>
        /// <param name="item">The item to enqueue</param>
        /// <returns>True if the item was succesfully added</returns>
        public bool Enqueue(T item) {
            if(size == queueMaxSize) {
                if (staticSize)
                    return false;
                else
                    DoubleQueue();
            }

            queue[back] = item;
            back++;
            size++;
            back %= queueMaxSize;

            return true;
        }

        /// <summary>
        /// Takes the first item in the queue and removes it
        /// </summary>
        /// <returns>The item at the front of the queue</returns>
        public T Dequeue() {
            if (size == 0)
                return default;

            T item = queue[front];
            size--;
            front++;
            front %= queueMaxSize;

            return item;
        }

        /// <summary>
        /// Shows the item that is at the front of the queue, without removing it
        /// </summary>
        /// <returns>The item at the front</returns>
        public T Peek() {
            if (size == 0)
                return default;

            return queue[front];
        }

        /// <summary>
        /// Clears the queue
        /// </summary>
        public void Clear() => front = back = size = 0;

        /// <summary>
        /// Fully resets the queue to a given queuesize
        /// </summary>
        /// <param name="queueSize">The amount of elements the queue can hold</param>
        public void Reset(int queueSize) {
            queue = new T[queueSize];
            queueMaxSize = queueSize;
            front = back = this.size = 0;
        }

        /// <summary>
        /// Doubles the size of the queue and copies the elements to the new queue
        /// </summary>
        private void DoubleQueue() {
            queueMaxSize *= 2;
            T[] temp = new T[queueMaxSize];

            for (int i = 0; i < size; i++)
                temp[i] = queue[(i + back) % size];

            back = size;
            front = 0;
            queue = temp;
        }
    }
}
