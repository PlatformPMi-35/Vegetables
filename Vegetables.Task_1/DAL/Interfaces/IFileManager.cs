using System.Collections.Generic;

namespace Vegetables.Task_1.DAL.Interfaces
{
    /// <summary>
    /// Represents a file manager.
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Loads all shapes from  the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <returns>Collection of shapes.</returns>
        IEnumerable<IShape> Load(string filePath);
       
        /// <summary>
        /// Saves all shapes in the file.
        /// </summary>
        /// <param name="filePath">A file path.</param>
        /// <param name="shapes">Collection of shapes.</param>
        /// <returns>True - if shapes successfully saved in the file, otherwise - false.</returns>
        bool Save(string filePath, IEnumerable<IShape> shapes);
    }
}
