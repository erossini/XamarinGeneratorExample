using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Enums;
using SQLite;

namespace MyExpenses.Data {
    /// <summary>
    /// Class Images.
    /// </summary>
    /// <seealso cref="MyExpenses.Data.BaseTable" />
    [Table("Images")]
    public class Images : BaseTableMyExpenses {
        /// <summary>
        /// Gets or sets the section.
        /// </summary>
        /// <value>The section.</value>
        [Indexed("PropAppIndex", 1)]
        public SectionImage Section { get; set; } = SectionImage.Generic;

        /// <summary>
        /// Gets or sets the item section identifier.
        /// </summary>
        /// <value>The item section identifier.</value>
        public int ItemSectionId { get; set; }

        /// <summary>
        /// Gets or sets the name of the file.
        /// </summary>
        /// <value>The name of the file.</value>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the extension.
        /// </summary>
        /// <value>The extension.</value>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets the size of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        public long FileSize { get; set; }

        /// <summary>
        /// Gets or sets the path of the file.
        /// </summary>
        /// <value>The size of the file.</value>
        [Ignore]
        public string FilePath { get; set; }
    }
}