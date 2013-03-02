﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace Pie.Collections
{
    /// <summary>
    /// A max heap.
    /// </summary>
    /// <typeparam name="T">The type of items in the heap.</typeparam>
    public class MaxHeap<T> : BinaryHeap<T> where T : IComparable<T>
    {
        /// <summary>
        /// The constructor.
        /// </summary>
        public MaxHeap() : base() { }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="capacity">The capacity of the heap.</param>
        public MaxHeap(int capacity) : base(capacity) { Contract.Requires(capacity > 0); }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="array">The items.</param>
        public MaxHeap(T[] array) : base(array) { }

        /// <summary>
        /// The item comparer.
        /// </summary>
        /// <param name="firstIndex">The index of the first item.</param>
        /// <param name="secondIndex">The index of the second item.</param>
        /// <returns>The order of the items.</returns>
        protected override int Compare(int firstIndex, int secondIndex)
        {
            return this.InternalArray[firstIndex].CompareTo(this.InternalArray[secondIndex]);
        }

        /// <summary>
        /// Whether the heap contains the item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Whether the heap contains the item.</returns>
        public bool Contains(T item)
        {
            return this.Contains(item, 0);
        }

        private bool Contains(T item, int i)
        {
            if (item.CompareTo(this.InternalArray[i]) == 0) return true;

            int left = this.Left(i);
            if (left < this.Count)
            {
                if (item.CompareTo(this.InternalArray[left]) <= 0 && this.Contains(item, left)) return true;

                int right = this.Right(i);
                if (right < this.Count && item.CompareTo(this.InternalArray[right]) <= 0 && this.Contains(item, right)) return true;
            }

            return false;
        }

        /// <summary>
        /// Heapsort the array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The sorted array.</returns>
        public static IEnumerable<T> Sort(T[] array)
        {
            MaxHeap<T> heap = new MaxHeap<T>(array);
            return heap.InternalSortReversed();
        }

        /// <summary>
        /// Heapsort the array, in descending order.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <returns>The sorted array.</returns>
        public static IEnumerable<T> SortDescending(T[] array)
        {
            MaxHeap<T> heap = new MaxHeap<T>(array);
            return heap.InternalSort();
        }
    }
}