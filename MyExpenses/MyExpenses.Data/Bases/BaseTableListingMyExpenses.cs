using SQLite;

namespace MyExpenses.Data {
    /// <summary>
    /// Class BaseTableListing.
    /// </summary>
    /// <seealso cref="MyExpenses.Data.BaseTableMyExpenses" />
    public class BaseTableListingMyExpenses : BaseTableMyExpenses {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [MaxLength(150)]
        public string Description { get; set; }
    }
}
