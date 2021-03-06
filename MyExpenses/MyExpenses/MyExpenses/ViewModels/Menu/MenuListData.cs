﻿using System;
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
				Title = "Expense",
				IconSource = "GenericIconMenu.png",
				TargetType = typeof(ExpenseList)
			});
		}
	}
}