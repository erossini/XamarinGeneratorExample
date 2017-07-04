using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Data;
using MyExpenses.Enums;
using MyExpenses.Interfaces;
using MyExpenses.Models;
using MyExpenses.Repository;
using PCLStorage;
using Xamarin.Forms;

namespace MyExpenses.Helpers
{
    public class FileHelper
    {
        /// <summary>
        /// Deletes the directory.
        /// </summary>
        /// <returns><c>true</c>, if directory was deleted, <c>false</c> otherwise.</returns>
        /// <param name="path">Path.</param>
        public static bool DeleteDirectory(string path)
        {
            return DependencyService.Get<IFileManager>().DeleteDirectory(path);
        }

        /// <summary>
        /// Deletes the files in a folder
        /// </summary>
        /// <param name="path">The path where delete files (for default the app folder)</param>
        /// <param name="search">The search with jolly characters. If is empty or null, all files will be deleted.</param>
        public static async Task DeleteFiles(string path, string search = "")
        {
            await DependencyService.Get<IFileManager>().DeleteFileInDirectory(path, search);
        }

        #region For images
        /// <summary>
        /// Deletes the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="Id">Identifier.</param>
        public static async Task DeleteImage(string ImageId, SectionImage Section)
        {
            bool result = await DependencyService.Get<IPicture>().DeletePictureFromDisk(ImageId, Section);
        }

        /// <summary>
        /// Gets the first image path.
        /// </summary>
        /// <param name="ItemId">The item identifier.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> GetFirstImagePath(SectionImage Section, int ItemId = 0)
        {
            string rtn = "";
            MyExpensesRepository repo = new MyExpensesRepository();

            if (repo.GetImageNumber(Section, ItemId) > 0)
            {
                Images img = repo.GetFirstImage(Section, ItemId);
            }

            return rtn;
        }

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <returns>The image.</returns>
        /// <param name="Id">Identifier.</param>
        public static async Task<ImageSource> GetImage(string ImageId, SectionImage Section)
        {
            string fileName = await DependencyService.Get<IPicture>().GetPicturePathFromDisk(ImageId, Section);
            ImageSource imageSource = ImageSource.FromFile(fileName);
            return imageSource;
        }

        /// <summary>
        /// Gets the file as byte.
        /// </summary>
        /// <returns>The file as byte.</returns>
        /// <param name="filepath">Filepath.</param>
        public async static Task<byte[]> GetFileAsByte(string filepath)
        {
            byte[] buffer = null;

            try
            {
                IFile file = await FileSystem.Current.GetFileFromPathAsync(filepath);
                using (System.IO.Stream stream = await file.OpenAsync(FileAccess.Read))
                {
                    long length = stream.Length;
                    buffer = new byte[length];
                    stream.Read(buffer, 0, (int)length);
                }
                file = null;
            }
            catch (Exception ex)
            {
            }

            return buffer;
        }

        /// <summary>
        /// Gets the image as byte.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="imagePath">The image path.</param>
        /// <returns>Task&lt;System.Byte[]&gt;.</returns>
        public async static Task<byte[]> GetImageAsByte(string imagePath)
        {
            byte[] buffer = null;
            IFile file = await FileSystem.Current.GetFileFromPathAsync(imagePath);
            using (System.IO.Stream stream = await file.OpenAsync(FileAccess.Read))
            {
                long length = stream.Length;
                buffer = new byte[length];
                stream.Read(buffer, 0, (int)length);
            }
            file = null;

            return buffer;
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <returns>The path.</returns>
        /// <param name="Id">Identifier.</param>
        public static async Task<string> GetPath(string ImageId, SectionImage Section)
        {
            return await DependencyService.Get<IPicture>().GetPicturePathFromDisk(ImageId, Section);
        }

        /// <summary>
        /// Loads the images for a property
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="PropertyId">The property identifier.</param>
        /// <param name="AppointmentId">The appointment identifier.</param>
        /// <param name="Section">The section.</param>
        /// <returns>Task&lt;List&lt;GalleryImage&gt;&gt;.</returns>
        public static async Task<List<GalleryImage>> LoadImages(SectionImage Section, int ItemId)
        {
            List<GalleryImage> rtn = new List<GalleryImage>();
            MyExpensesRepository repo = new MyExpensesRepository();

            List<Images> list = repo.GetImages(Section, ItemId);
            if (list.Count > 0)
            {
                foreach (Images i in list)
                {
                    if (!string.IsNullOrEmpty(i.FileName))
                    {
                        bool result = await FileHelper.IsImageExist(i.FileName, Section);
                        if (result)
                        {
                            string filePath = await FileHelper.GetPath(i.FileName, Section);
                            rtn.Add(new GalleryImage
                            {
                                Id = i.Id,
                                ImageId = new Guid(i.FileName),
                                FilePath = filePath,
                                OrgImage = await FileHelper.GetImageAsByte(filePath)
                            });
                        }
                        else
                        {
                            repo.DeleteImages(i.Id);
                        }
                    }
                    else
                    {
                        repo.DeleteImages(i.Id);
                    }
                }

                repo.Dispose();
            }

            return rtn;
        }

        /// <summary>
        /// Is the picture exists on the file system
        /// </summary>
        /// <returns>The exists.</returns>
        /// <param name="Id">Identifier.</param>
        public static async Task<bool> IsImageExist(string ImageId, SectionImage Section)
        {
            return await DependencyService.Get<IPicture>().IsExist(ImageId, Section);
        }

        /// <summary>
        /// Is the picture exists on the file system
        /// </summary>
        /// <param name="images">List of images.</param>
        /// <param name="Section">Section image.</param>
        /// <param name="ItemId">Item Identifier.</param>
        public static async Task<bool> SaveGalleryImages(List<GalleryImage> images, SectionImage Section, int ItemId)
        {
            bool rtn = true;

            // open a connection with database
            MyExpensesRepository repo = new MyExpensesRepository();

            // save each image in the database
            foreach (GalleryImage img in images)
            {
                Images imgRecord = new Images();
                imgRecord.ItemSectionId = ItemId;
                imgRecord.Section = Section;
                imgRecord.Extension = "jpg";
                imgRecord.FileName = img.ImageId.ToString();
                imgRecord.FileSize = img.ImageSize;
                imgRecord.UpdatedDate = DateTime.Now;
                if (img.Id == 0)
                    repo.SaveImages(imgRecord);

                bool exist = await IsImageExist(img.ImageId.ToString(), Section);
                if (!exist)
                {
                    if (img.Source != null)
                    {
                        try
                        {
                            if (Device.RuntimePlatform == Device.Windows || Device.RuntimePlatform == Device.WinPhone)
                            {
                                MemoryStream stream = new MemoryStream(await GetImageAsByte(img.FilePath));
                                DependencyService.Get<IPicture>().SavePictureToDiskWindows(Section, img.ImageId.ToString(), stream);
                            }
                            else
                            {
                                await DependencyService.Get<IPicture>().SavePictureToDisk(img.Source, imgRecord.FileName, Section);

                                byte[] imgByte = await GetFileAsByte(img.FilePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("SaveGalleryImages -> " + ex.Message);
                        }
                    }

                    rtn = rtn && true;
                }
            }
            return rtn;
        }
        #endregion
    }
}
