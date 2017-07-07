using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExpenses.Helpers;
using MyExpenses.Models;
using MyExpenses.ViewModels;
using Xamarin.Forms;

namespace MyExpenses.Views {
    public partial class ExpenseList : ContentPage {
        ExpenseListViewModel vm = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="ExpenseId">The expense identifier.</param>
        public ExpenseList() {
            InitializeComponent();

            LoadViewModel();
        }

        /// <summary>
        /// Loads the view model.
        /// </summary>
        /// <param name="ExpenseId">The expense identifier.</param>
        private void LoadViewModel() {
            if (vm == null) {
                vm = new ExpenseListViewModel();
                vm.ParamError += vm_ParamError;
                BindingContext = vm;
            }
            else {
                vm.LoadData();
            }
        }

        protected override void OnAppearing() {
            base.OnAppearing();
            vm = null;
            LoadViewModel();
        }

        private void vm_ParamError(object sender, EventsArgs.ParamErrorEventArgs e) {
        }

        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            var expense = ((ListView)sender).SelectedItem as ExpenseModel;
            if (expense == null)
                return;

            await Navigation.PushAsync(new ExpenseItem(expense.Id), true);
        }

        public async void OnClickedNew(object sender, EventArgs e) {
            await Navigation.PushAsync(new ExpenseItem(0), true);
        }

        public async void OnDelete(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            bool answer = await DisplayAlert("AppName", "Are you sure you want to delete it?", "Yes", "Cancel");

            if (answer) {
                vm.DeleteItem((int)mi.CommandParameter);
                vm.Refresh();
            }
        }

        public void OnEdit(object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            Navigation.PushAsync(new ExpenseItem(  Convert.ToInt32(mi.CommandParameter)), true);
        }

        public void OnTextChanged(object sender, EventArgs e) {
            string search = "";
            if (!string.IsNullOrEmpty(this.searchBar.Text))
                search = this.searchBar.Text.Trim();
            vm.FilterTeams(search);
        }
    }
}
