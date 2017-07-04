using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSC.Xamarin.MvvmHelpers;
using MyExpenses.Enums;
using Xamarin.Forms;

namespace MyExpenses.Models {
    /// <summary>
    /// Class GalleryImage.
    /// </summary>
    /// <seealso cref="PSC.Xamarin.MvvmHelpers.ObservableObject" />
    public class GalleryImage : ObservableObject {
        /// <summary>
        /// Initializes a new instance of the <see cref="GalleryImage"/> class.
        /// </summary>
        public GalleryImage() {
            ImageId = Guid.NewGuid();
        }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the item identifier (for example a Room Id or Boundary ID and so on).
        /// </summary>
        /// <value>The item identifier.</value>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the section for this image.
        /// </summary>
        /// <value>The image section.</value>
        public SectionImage Section { get; set; }

        /// <summary>
        /// Gets or sets the order identifier.
        /// </summary>
        /// <value>The order identifier.</value>
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the image identifier.
        /// </summary>
        /// <value>The image identifier.</value>
        public Guid ImageId { get; set; }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        /// <value>The source.</value>
        public ImageSource Source { get; set; }

        /// <summary>
        /// Gets or sets the org image.
        /// </summary>
        /// <value>The org image.</value>
        public byte[] OrgImage { get; set; }

        /// <summary>
        /// Gets or sets the size image.
        /// </summary>
        /// <value>The org image.</value>
        public long ImageSize { get; set; }

        /// <summary>
        /// Gets or sets the path of an image.
        /// </summary>
        /// <value>The org image.</value>
        public string FilePath { get; set; }
    }
}
