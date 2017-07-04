using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Data;
using MyExpenses.Models;

namespace MyExpenses.Mapping {
    /// <summary>
    /// Class Expense Mapping.
    /// </summary>
    public static class ExpenseMapping {
        /// <summary>
        /// To the expense.
        /// </summary>
        /// <param name="expense">The expense.</param>
        /// <returns>ExpenseModel.</returns>
        public static ExpenseModel ToExpense(this Expense expense) {
            ExpenseModel model = null;
            if (expense != null) {
                model = new ExpenseModel();
                model.Id = expense.Id;
                model.ExpenseDate = expense.ExpenseDate;
                model.Description = expense.Description;
                model.Cost = expense.Cost;
                model.Category = expense.Category;
                model.IsRecurrence = expense.IsRecurrence;
                model.RecurrenceTime = expense.RecurrenceTime;
                model.IsIncome = expense.IsIncome;
            }
            return model;
        }

        /// <summary>
        /// To the expense.
        /// </summary>
        /// <param name="expense">The expense.</param>
        /// <returns>Expense.</returns>
        public static Expense ToExpense(this ExpenseModel expense) {
            Expense model = new Expense();
            if (expense != null) {
                model = new Expense();
                model.Id = expense.Id;
                model.ExpenseDate = expense.ExpenseDate;
                model.Description = expense.Description;
                model.Cost = expense.Cost;
                model.Category = expense.Category;
                model.IsRecurrence = expense.IsRecurrence;
                model.RecurrenceTime = expense.RecurrenceTime;
                model.IsIncome = expense.IsIncome;
            }
            return model;
        }

        /// <summary>
        /// To the list of expense.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>List&lt;ExpenseModel&gt;.</returns>
        public static List<ExpenseModel> ToExpense(this List<Expense> list) {
            List<ExpenseModel> rtn = new List<ExpenseModel>();

            foreach(Expense a in list) {
                rtn.Add(a.ToExpense());
            }

            return rtn;
        }

        /// <summary>
        /// To the list of expense.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns>List&lt;Expense&gt;.</returns>
        public static List<Expense> ToExpense(this List<ExpenseModel> list) {
            List<Expense> rtn = new List<Expense>();

            foreach(ExpenseModel a in list) {
                rtn.Add(a.ToExpense());
            }

            return rtn;
        }
    }
}
