using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
	public class MenuListView : ListView
	{
		public MenuListView(List<MenuItems> data)
		{
			ItemsSource = data;
			VerticalOptions = LayoutOptions.FillAndExpand;
			BackgroundColor = Color.Transparent;
			SeparatorVisibility = SeparatorVisibility.None;

			var cell = new DataTemplate(typeof(MenuCell));
			cell.SetBinding(MenuCell.TextProperty, "Title");
			cell.SetBinding(MenuCell.ImageSourceProperty, "IconSource");

			ItemTemplate = cell;
		}
	}
}