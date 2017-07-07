using System;
using Xamarin.Forms;

namespace MyExpenses.ViewModels
{
	public partial class MenuPage : ContentPage
	{
		public ListView Menu { get; set; }

		public MenuPage()
		{
			Title = "menu"; // The Title property must be set.
			BackgroundColor = Color.FromHex("#3498db");
			if (Device.RuntimePlatform == Device.iOS)
			{
				Icon = "settings.png";
			}

			Menu = new MenuListView(new MenuListData());

			var menuLabel = new ContentView
			{
				Padding = new Thickness(10, 36, 0, 5),
				Content = new Image
				{
					Source = "Logo.png",
					WidthRequest = 100,
                    HorizontalOptions = LayoutOptions.Center
				}
			};

			var layout = new StackLayout
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
            
			// app version
			var lbl = new Label
			{
				TextColor = Color.White,
				VerticalOptions = LayoutOptions.EndAndExpand,
				Text = $"Version: ",
				HorizontalTextAlignment = TextAlignment.Center,
			};
			layout.Children.Add(menuLabel);
			layout.Children.Add(Menu);
			layout.Children.Add(lbl);

			Content = layout;
		}
	}
}