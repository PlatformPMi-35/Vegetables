using System.Collections.Generic;
using Vegetables.Task_1.BLL.Enums;

namespace Vegetables.Task_1.BLL.Interfaces
{
    /// <summary>
    /// Represents a finder
    /// </summary>
    /// <typeparam name="T">Type of interface or class</typeparam>
    public interface IFinder<T>
    { 
        /// <summary>
        /// Find elements, which are on the quarter.
        /// </summary>
        /// <param name="enumerable">The collection</param>
        /// <param name="quarter">The quarter</param>
        /// <returns>Collection of the elements, which are on the quarter</returns>
        IEnumerable<T> Find(IEnumerable<T> enumerable, Quarter quarter);
    }
}
