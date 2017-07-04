using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PSC.Xamarin.MvvmHelpers;
using MyExpenses.Data;
using MyExpenses.Enums;
using MyExpenses.EventsArgs;
using MyExpenses.Repository;
using Xamarin.Forms;

namespace MyExpenses.ViewModels {
    /// <summary>
    /// Class Expense item ViewModel
    /// </summary>
    public class ExpenseItemViewModel : BaseForViewModel {
       MyExpensesRepository repo = new MyExpensesRepository();
        bool saveOnDatabase = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseViewModel"/> class.
        /// </summary>
        public ExpenseItemViewModel() {
            Section = Enums.SectionImage.Expense;
            LoadDefaultData();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseViewModel"/> class.
        /// </summary>
        /// <param name="expenseId">The Expense identifier.</param>
        public ExpenseItemViewModel(int expenseId = 0, bool SaveOnDatabase = true) {
            saveOnDatabase = SaveOnDatabase;
            Section = Enums.SectionImage.Expense;
            if (expenseId != 0)  {
                Id = expenseId;
            }

            IsBusy = true;
            LoadDefaultData();
            LoadData();
            IsBusy = false;
        }

        #region Load data
        /// <summary>
        /// Loads the default data.
        /// </summary>
        public void LoadDefaultData()  {
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()  {
            Section = Enums.SectionImage.Expense;
            Expense expense = null;
            if (Id != 0)  {
                expense = repo.GetExpense(Id);
                AssociateData(expense);
            }
        }

        /// <summary>
        /// Associates expense data from the database to the form
        /// </summary>
        /// <param name="expense">The expense.</param>
        private void AssociateData(Expense expense)  {
            if (expense != null)  {
                ExpenseDate = expense.ExpenseDate;
                Description = expense.Description;
                Cost = expense.Cost;
                Category = expense.Category;
                IsRecurrence = expense.IsRecurrence;
                RecurrenceTime = expense.RecurrenceTime;
                IsIncome = expense.IsIncome;
            }
        }
        #endregion
        #region Model

        /// <summary>
        /// Gets or sets the expensedate.
        /// </summary>
        /// <value>The expensedate.</value>
        public string ExpenseDate
         {
            get  {
                return _expensedate;
            }

            set  {
                if (_expensedate != value)  {
                    _expensedate = value;
                    OnPropertyChanged("ExpenseDate");
                }
            }
        }
        private string _expensedate;

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description
         {
            get  {
                return _description;
            }

            set  {
                if (_description != value)  {
                    _description = value;
                    OnPropertyChanged("Description");
                }
            }
        }
        private string _description;

        /// <summary>
        /// Gets or sets the cost.
        /// </summary>
        /// <value>The cost.</value>
        public int Cost
         {
            get  {
                return _cost;
            }

            set  {
                if (_cost != value)  {
                    _cost = value;
                    OnPropertyChanged("Cost");
                }
            }
        }
        private int _cost;

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>The category.</value>
        public CategoryType Category
         {
            get  {
                return _category;
            }

            set  {
                if (_category != value)  {
                    _category = value;
                    OnPropertyChanged("Category");
                }
            }
        }
        private CategoryType _category;

        /// <summary>
        /// Gets or sets the isrecurrence.
        /// </summary>
        /// <value>The isrecurrence.</value>
        public bool IsRecurrence
         {
            get  {
                return _isrecurrence;
            }

            set  {
                if (_isrecurrence != value)  {
                    _isrecurrence = value;
                    OnPropertyChanged("IsRecurrence");
                }
            }
        }
        private bool _isrecurrence;

        /// <summary>
        /// Gets or sets the recurrencetime.
        /// </summary>
        /// <value>The recurrencetime.</value>
        public RecurrenceTimeType RecurrenceTime
         {
            get  {
                return _recurrencetime;
            }

            set  {
                if (_recurrencetime != value)  {
                    _recurrencetime = value;
                    OnPropertyChanged("RecurrenceTime");
                }
            }
        }
        private RecurrenceTimeType _recurrencetime;

        /// <summary>
        /// Gets or sets the isincome.
        /// </summary>
        /// <value>The isincome.</value>
        public bool IsIncome
         {
            get  {
                return _isincome;
            }

            set  {
                if (_isincome != value)  {
                    _isincome = value;
                    OnPropertyChanged("IsIncome");
                }
            }
        }
        private bool _isincome;

        #endregion
        #region Events
        /// <summary>
        /// Save handler when it doesn't save on database
        /// </summary>
        public delegate void SaveNoDatabaseHandler(object sender, SaveExpenseEventArgs e);

        /// <summary>
        /// Occurs when on save in memory
        /// </summary>
        public event SaveNoDatabaseHandler OnSaveInMemory;
        #endregion
        #region Commands
        ICommand _saveCommand = null;

        /// <summary>
        /// Gets the save expense command.
        /// </summary>
        /// <value>The save expense command.</value>
        public ICommand SaveExpenseItem
         {
            get  {
                return _saveCommand ?? (_saveCommand =
                    new Command(async () => await ExecuteSaveExpenseCommand()));
            }
        }

        /// <summary>
        /// Executes the save expense command.
        /// </summary>
        /// <returns>Task.</returns>
        private async Task ExecuteSaveExpenseCommand()  {
                Validate();
                if (this.IsValid)  {
                    IsBusy = true;
                    SaveExpenseOnDB();
                    IsBusy = false;
                }
                else  {
                    OnFormError(new FormErrorEventArgs("Expense", "The form is not valid!"));
                }
        }

        /// <summary>
        /// Saves the expense on database.
        /// </summary>
        private void SaveExpenseOnDB()  {
            Expense expense = new Expense();
            if (Id != 0)  {
                expense = repo.GetExpense(Id);
            }
            expense.ExpenseDate = ExpenseDate;
            expense.Description = Description;
            expense.Cost = Cost;
            expense.Category = Category;
            expense.IsRecurrence = IsRecurrence;
            expense.RecurrenceTime = RecurrenceTime;
            expense.IsIncome = IsIncome;

            if (saveOnDatabase) {
               Id = repo.SaveExpense(expense);
                OnFormSave(new SaveEventArgs() { CreatedOrUpdatedId = Id });
            }
            else {
                SaveExpenseEventArgs argsSave = new SaveExpenseEventArgs();
                argsSave.ExpenseDetails = expense;
                argsSave.SaveOnDatabase = saveOnDatabase;
                OnSaveInMemory(this, argsSave);
            }
        }

        /// <summary>
        /// Validates
        /// </summary>
        protected override void ValidateSelf()  {
            // validation example
            //if (Selected{tbl} == null)  {
            //    this.ValidationErrors["Selected{tbl}"] = "{tbl} type is required";
            //}
        }
        #endregion
    }
}
