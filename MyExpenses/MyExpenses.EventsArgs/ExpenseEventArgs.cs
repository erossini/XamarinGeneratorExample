using System;
using System.Collections.Generic;
using MyExpenses.Data;

namespace MyExpenses.EventsArgs
{
    public class SaveExpenseEventArgs : EventArgs
    {
        public SaveExpenseEventArgs()
        {
        }

        /// <summary>
        /// Gets or sets the expense.
        /// </summary>
        /// <value>The expense.</value>
        public Expense ExpenseDetails { get; set; }

        /// <summary>
        /// Gets or sets the save on database.
        /// </summary>
        /// <value>The save on database.</value>
        public bool SaveOnDatabase { get; set; }
    }
}