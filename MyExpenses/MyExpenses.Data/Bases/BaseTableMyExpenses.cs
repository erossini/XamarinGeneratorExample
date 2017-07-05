using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Data.Interfaces;
using SQLite;

namespace MyExpenses.Data {
    /// <summary>
    /// Class BaseTable.
    /// </summary>
    /// <seealso cref="MyExpenses.Data.Interfaces.ITableEntityMyExpenses" />
    public class BaseTableMyExpenses : ITableEntityMyExpenses {
        #region ITableEntity implementation

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKey, AutoIncrement]
        [Indexed]
        public int Id { get; set; }

        #endregion

        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether this instance is synchronize.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is synchronize; otherwise, <c>false</c>.
        /// </value>
        public bool IsSynchronize { get; set; } = false;

        /// <summary>
        /// Gets or sets the synchronize date.
        /// </summary>
        /// <value>
        /// The synchronize date.
        /// </value>
        public DateTime? SynchronizeDate { get; set; } = null;

        /// <summary>
        /// Gets or sets the synchronize.
        /// </summary>
        /// <value>The synchronize.</value>
        public int SynchronizeId { get; set; }

        /// <summary>
        /// Gets or sets the item version.
        /// </summary>
        /// <value>The version.</value>
        public int Version { get; set; } = 0;
    }
}
