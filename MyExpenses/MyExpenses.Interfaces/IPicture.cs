using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Enums;
using Xamarin.Forms;

namespace MyExpenses.Interfaces
{
    public interface IPicture
    {
        /// <summary>
        /// Creates the path.
        /// </summary>
        /// <param name="ImageId">The image identifier.</param>
        /// <param name="Section">The section.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<string> CreatePath(SectionImage Section);

        /// <summary>
        /// Deletes the picture from disk.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><c>true</c> if it deleted the picture, <c>false</c> otherwise.</returns>
        Task<bool> DeletePictureFromDisk(string ImageId, SectionImage Section);

        /// <summary>
        /// Gets the image as byte.
        /// </summary>
        /// <returns>The image as byte.</returns>
        /// <param name="ImageId">Image identifier.</param>
        /// <param name="Section">Section.</param>
        Task<byte[]> GetImageAsByte(string ImageId, SectionImage Section);

        /// <summary>
        /// Gets the image path.
        /// </summary>
        /// <returns>The image path.</returns>
        /// <param name="ImageId">Image identifier.</param>
        /// <param name="Section">Section.</param>
        Task<string> GetImagePath(string ImageId, SectionImage Section);

        /// <summary>
        /// Gets the personal folder.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetPersonalFolder();

        /// <summary>
        /// Gets the picture from disk.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>System.String.</returns>
        Task<string> GetPicturePathFromDisk(string ImageId, SectionImage Section);

        /// <summary>
        /// Is the path exist?
        /// </summary>
        /// <returns><c>true</c>, if exist was ised, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        bool IsExist(string path);

        /// <summary>
        /// Determines whether the specified identifier is exists.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <returns><c>true</c> if the specified identifier is exists; otherwise, <c>false</c>.</returns>
        Task<bool> IsExist(string ImageId, SectionImage Section);

        /// <summary>
        /// Saves the picture to disk (implementation for iOS and Android).
        /// </summary>
        /// <param name="imgSrc">The img source.</param>
        /// <param name="ImageId">The image identifier.</param>
        /// <param name="Section">The section.</param>
        /// <param name="OverwriteIfExist">if set to <c>true</c> overwrite if exist.</param>
        Task<string> SavePictureToDisk(ImageSource imgSrc, string ImageId, SectionImage Section, bool OverwriteIfExist = false);

        /// <summary>
        /// Saves the picture to disk.
        /// </summary>
        /// <returns>The picture to disk.</returns>
        /// <param name="imgSrc">Image source.</param>
        /// <param name="Id">Identifier.</param>
        /// <param name="OverwriteIfExist">If set to <c>true</c> overwrite if exist.</param>
        Task<bool> SavePictureToDisk(ImageSource imgSrc, string Id, bool OverwriteIfExist = false);

        /// <summary>
        /// Saves the picture to disk (implementation for Windows).
        /// </summary>
        /// <param name="Section">The section.</param>
        /// <param name="ImageId">The image identifier.</param>
        /// <param name="imgStream">The img stream.</param>
        /// <param name="OverwriteIfExist">if set to <c>true</c> [overwrite if exist].</param>
        void SavePictureToDiskWindows(SectionImage Section, string ImageId, Stream imgStream, bool OverwriteIfExist = false);

        /// <summary>
        /// Saves the picture thumb to disk.
        /// </summary>
        /// <returns>The picture thumb to disk.</returns>
        /// <param name="fileSourcePath">File source path.</param>
        /// <param name="filepath">Filepath.</param>
        /// <param name="OverwriteIfExist">If set to <c>true</c> overwrite if exist.</param>
        Task SavePictureThumbToDisk(string fileSourcePath, string filepath, bool OverwriteIfExist = false);
    }
}