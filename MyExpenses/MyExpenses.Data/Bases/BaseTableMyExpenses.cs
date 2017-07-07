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
        public int Id { get; set; } = 0;
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

        public bool IsDeleted { get; set; }
    }
}
