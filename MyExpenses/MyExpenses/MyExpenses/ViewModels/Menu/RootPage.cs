using System;
using Xamarin.Forms;
using System.Linq;
using MyExpenses.Views;

namespace MyExpenses.ViewModels
{
	public class RootPage : MasterDetailPage
	{
		MenuPage menuPage;

		public RootPage()
		{
			menuPage = new MenuPage();
			menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItems);

			Master = menuPage;
				Detail = new NavigationPage(new ExpenseList())
				{
					BarTextColor = Color.White,
					BarBackgroundColor = Color.FromHex("#3498db")
				};
		}

		void NavigateTo(MenuItems menu)
		{
			if (menu == null)
				return;

			Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
			Detail = new NavigationPage(displayPage)
			{
				BarTextColor = Color.White,
				BarBackgroundColor = Color.FromHex("#3498db")
			};

			menuPage.Menu.SelectedItem = null;
			IsPresented = false;
		}
	}
}