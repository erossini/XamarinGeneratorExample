using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Controls;
using MyExpenses.EventsArgs;
using MyExpenses.Helpers;
using MyExpenses.Repository;
using MyExpenses.ViewModels;
using Xamarin.Forms;

namespace MyExpenses.Views  {
    public partial class ExpenseItem : ContentPage  {
        ExpenseItemViewModel vm = null;

        public ExpenseItem()  {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="ExpenseId">The expense identifier.</param>
        public ExpenseItem(int expenseId = 0)  {
            InitializeComponent();
            LoadViewModel(expenseId);
        }

        /// <summary>
        /// Loads the view model.
        /// </summary>
        /// <param name="ExpenseId">The expense identifier.</param>
        public void LoadViewModel(int expenseId = 0)  {
            if (vm == null)  {
                vm = new ExpenseItemViewModel(expenseId);
                vm.FormError += vm_FormError;
                vm.FormSave += vm_FormSave;
                vm.FormSaveError += vm_FormSaveError;
                vm.ParamError += vm_ParamError;
                vm.InitMedia();
                BindingContext = vm;
            }
        }

        private void vm_ParamError(object sender, ParamErrorEventArgs e)  {
            //LogHelpers.Save(Enums.EventType.Error, "ExpenseItem Parameters error -> " + e.Message);
        }

        private void vm_FormSaveError(object sender, FormSaveErrorEventArgs e)  {
            //LogHelpers.Save(Enums.EventType.Error, "ExpenseItem Form Save Error -> " + e.Message);
        }

        private async void vm_FormSave(object sender, SaveEventArgs e)  {
            if (e.CreatedOrUpdatedId != 0)  {
                await Navigation.PopAsync();
            }
        }

        private void vm_FormError(object sender, FormErrorEventArgs e)  {
            //LogHelpers.Save(Enums.EventType.Error, "ExpenseItem Parameters error -> " + e.Message);
        }

        private void OnLoadingImages(object sender, LoadingEventArgs e)  {
            this.cvLoading.IsVisible = e.IsLoading;
        }
    }
}
