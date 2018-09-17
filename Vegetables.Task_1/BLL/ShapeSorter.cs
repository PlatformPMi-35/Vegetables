using System;
using System.Collections.Generic;
using System.Linq;
using Vegetables.Task_1.BLL.Enums;
using Vegetables.Task_1.DAL.Interfaces;

namespace Vegetables.Task_1.BLL
{
    /// <summary>
    /// Sort shapes in collections.
    /// </summary>
    public static class ShapeSorter
    {
        /// <summary>
        /// Sort shapes by ascending
        /// </summary>
        /// <param name="collectionShapes">Collection of shapes</param>
        /// <param name="sortBy">How sort shapes</param>
        /// <returns>Sorted collection</returns>
        public static IEnumerable<IShape> SortByAscending(IEnumerable<IShape> collectionShapes, SortShapesBy sortBy)
        {
            IEnumerable<IShape> orderedEnumerable;
            switch (sortBy)
            {
                case SortShapesBy.Area:
                {
                    orderedEnumerable = collectionShapes.OrderBy(x => x.Area());
                    break;
                }

                case SortShapesBy.Perimeter:
                {
                    orderedEnumerable = collectionShapes.OrderBy(x => x.Perimeter());
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null);
            }

            return orderedEnumerable;
        }

        /// <summary>
        /// Sort shapes by Descending
        /// </summary>
        /// <param name="collectionShapes">Collection of shapes</param>
        /// <param name="sortBy">How sort shapes</param>
        /// <returns>Sorted collection</returns>
        public static IEnumerable<IShape> SortByDescending(IEnumerable<IShape> collectionShapes, SortShapesBy sortBy)
        {
            IEnumerable<IShape> orderedEnumerable;
            switch (sortBy)
            {
                case SortShapesBy.Area:
                {
                    orderedEnumerable = collectionShapes.OrderByDescending(x => x.Area());
                    break;
                }

                case SortShapesBy.Perimeter:
                {
                    orderedEnumerable = collectionShapes.OrderByDescending(x => x.Perimeter());
                    break;
                }

                default:
                    throw new ArgumentOutOfRangeException(nameof(sortBy), sortBy, null);
            }

            return orderedEnumerable;
        }
    }
}
