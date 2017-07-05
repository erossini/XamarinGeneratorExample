using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Data;
using MyExpenses.Helpers;
using MyExpenses.Mapping;
using MyExpenses.Models;
using MyExpenses.Repository;

namespace MyExpenses.ViewModels {
    /// <summary>
    /// Class Expense list ViewModel
    /// </summary>
    public class ExpenseListViewModel : BaseListViewModel {
        /// <summary>
        /// Gets or sets the expense list.
        /// </summary>
        /// <value>The expense list.</value>
        public ObservableCollection<ExpenseModel> ExpensesList { get; set; }

        /// <summary>
        /// The repository
        /// </summary>
        MyExpensesRepository repo = new MyExpensesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpensesList"/> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public ExpenseListViewModel() : base() {
            Section = Enums.SectionImage.Expense;
            LoadData();
        }

        /// <summary>
        /// Deletes the item.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        public override void DeleteItem(int Id) {
            repo.DeleteExpense(Id);
            LoadData();
        }

        /// <summary>
        /// Loads the data for this kind of expense
        /// </summary>
        /// <param name="search">The search.</param>
        public override void LoadData(string search = "") {
            IsBusy = true;
            Section = Enums.SectionImage.Expense;

            ExpensesList = new ObservableCollection<ExpenseModel>();
            List<Expense> list = repo.GetExpense();

            if (!string.IsNullOrEmpty(search)) {
                // TODO ExpenseListViewModel set your condition in the search
                // list = list.Where(l => (l.Issue != null && l.Issue.Contains(search))).ToList();
            }

            if (list != null) {
                foreach (Expense expense in list) {
                    ExpenseModel model = expense.ToExpense();
                    model.ImagePath = "GenericIcon.png";
                    ExpensesList.Add(model);
                    OnPropertyChanged("ExpensesList");
                }
                ItemNumber = list.Count;
            }
            else {
                ItemNumber = 0;
            }

            if (ItemNumber == 0) {
                ShowEmpty = true;
                ShowListView = false;
                ItemNumberText = "No expense found";
            }
            else {
                ShowEmpty = false;
                ShowListView = true;
                if (ItemNumber == 1) {
                    ItemNumberText = "1 expense";
                }
                else {
                    ItemNumberText = $"{ItemNumber} expenses";
                }
            }

            IsBusy = false;
        }
    }
}
