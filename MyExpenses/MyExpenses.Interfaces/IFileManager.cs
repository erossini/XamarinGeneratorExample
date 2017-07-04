using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExpenses.Interfaces
{
    public interface IFileManager
    {
        /// <summary>
        /// Creates the directory if not exists.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CreateDirectoryIfNotExists(string name);

        /// <summary>
        /// Creates the file asynchronous.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="context">The context.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> CreateFileAsync(string name, string context);

        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <returns><c>true</c>, if directory was deleted, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        bool DeleteDirectory(string path);

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteFile(string file);

        /// <summary>
        /// Deletes the file in directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="search">The search.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> DeleteFileInDirectory(string path, string search = "");

        /// <summary>
        /// Gets the free space.
        /// </summary>
        /// <returns>The free space.</returns>
        long GetFreeSpace();

        /// <summary>
        /// Gets the local storage.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetLocalStorage();

        /// <summary>
        /// Gets the personal folder.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetPersonalFolder();

        /// <summary>
        /// Gets the size of the space.
        /// </summary>
        /// <returns>The space size.</returns>
        long GetSpaceSize();

        /// <summary>
        /// Reads the directories.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>List&lt;FileItem&gt;.</returns>
        List<FileItem> ReadDirectories(string path);

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> ReadFile(string name);

        /// <summary>
        /// Reads the files in directory.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>List&lt;FileItem&gt;.</returns>
        List<FileItem> ReadFilesInDirectory(string path, string search = "");
    }
}
