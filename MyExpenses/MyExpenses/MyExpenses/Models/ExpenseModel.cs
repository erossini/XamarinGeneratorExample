using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Enums;

namespace MyExpenses.Models {
    /// <summary>
    /// Class expense model.
    /// </summary>
    /// <seealso cref="MyExpenses.Models.BaseModel" />
    public class ExpenseModel : BaseModel {
        /// <summary>
        /// Gets or sets the expensedate.
        /// </summary>
        /// <value>
        /// The expensedate identifier.
        /// </value>
        public DateTime ExpenseDate { get; set; }

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>
        /// The cost identifier.
        /// </value>
        public int Cost { get; set; }

        /// <summary>
        /// Gets or sets the isrecurrence.
        /// </summary>
        /// <value>
        /// The isrecurrence identifier.
        /// </value>
        public bool IsRecurrence { get; set; }

        /// <summary>
        /// Gets or sets the recurrencetime.
        /// </summary>
        /// <value>
        /// The recurrencetime identifier.
        /// </value>
        public RecurrenceTimeType RecurrenceTime { get; set; }

        /// <summary>
        /// Gets or sets the isincome.
        /// </summary>
        /// <value>
        /// The isincome identifier.
        /// </value>
        public bool IsIncome { get; set; }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public CategoryType Category { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description identifier.
        /// </value>
        public string Description { get; set; }
    }
}
