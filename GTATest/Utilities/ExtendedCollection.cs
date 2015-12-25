using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GTATest.Utilities
{
    /// <summary>
    /// Provides a collection of useful LINQ utilities for managing a <see cref="Collection{T}"/>.
    /// </summary>
    public static class ExtendedCollection
    {
        /// <summary>
        /// Performs the specified <see cref="Action"/> on each element in the specified <see cref="IEnumerable"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="startIndex">The start index.</param>
        /// <param name="endIndex">The end index.</param>
        /// <param name="action">The action.</param>
        public static void For<T>(this IEnumerable<T> enumerable, int startIndex, int endIndex, Action<T, int> action)
        {
            if (endIndex > enumerable.Count() - 1) {
                return;
            }
            if (startIndex < 0) {
                return;
            }
            if (enumerable == null) {
                return;
            }

            for (var i = startIndex; i < endIndex; i++) {
                action.Invoke(enumerable.ToArray()[i], i);
            }
        }

        /// <summary>
        /// Performs the specified <see cref="Action"/> on each element in the specified <see cref="IEnumerable"/>.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="action">The action.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            var index = 0;
            enumerable.ToList().ForEach(item =>
            {
                action.Invoke(item, index);
                index++;
            });
        }
    }
}
