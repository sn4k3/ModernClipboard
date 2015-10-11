using System.Collections.Generic;

namespace ModernClipboard
{
    /// <summary>
    /// Extended List with Queue and Stack funcionalities
    /// </summary>
    /// <typeparam name="T">Object type name</typeparam>
    public sealed class ListEx<T> : List<T>
    {
        /// <summary>
        /// Adds an object to the end of the Queue
        /// </summary>
        /// <param name="item">Object to add in the end of the Queue</param>
        public void Enqueue(T item) => Insert(0, item);

        /// <summary>
        /// Removes and returns the object at the beginning of the Queue
        /// </summary>
        /// <returns>Object at the beginning of the Queue</returns>
        public T Dequeue()
        {
            var item = this[Count - 1];
            RemoveAt(Count - 1);
            return item;
        }

        /// <summary>
        /// Inserts an object to the top of the Stack
        /// </summary>
        /// <param name="item">Object to insert in the top of the Stack</param>
        public void Push(T item) => Add(item);

        /// <summary>
        /// Removes and returns the object at the top of the Stack
        /// </summary>
        /// <returns>Object at the top of the Stack</returns>
        public T Pop()
        {
            var item = this[Count - 1];
            RemoveAt(Count - 1);
            return item;
        }

        /// <summary>
        /// Returns the object at the top of the List without removing it
        /// </summary>
        /// <returns>Object at the top of the List</returns>
        public T PeekTop() => this[Count - 1];

        /// <summary>
        /// Returns the object at the bottom of the List without removing it
        /// </summary>
        /// <returns>Object at the top of the List</returns>
        public T PeekBottom() => this[0];
    }
}
