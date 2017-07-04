using System;
using System.Collections.Generic;
using MyExpenses.Views;

namespace MyExpenses.ViewModels
{
	public class MenuListData : List<MenuItems>
	{
		public MenuListData()
		{
			this.Add(new MenuItems()
			{
				Title = "Appointment",
				IconSource = "Home.png",
				TargetType = typeof(ExpenseList)
			});
		}
	}
}