using PSC.Xamarin.Controls.EnumBindablePicker.Extensions;

namespace MyExpenses.Enums {
    public enum CategoryType
    {
        [DescriptionAttribute(Text = "General")]
        General = 0,

        [DescriptionAttribute(Text = "Bills")]
        Bills = 1,

        [DescriptionAttribute(Text = "Daily shopping")]
        DailyShopping = 2,

        [DescriptionAttribute(Text = "Work shopping")]
        WorkShopping = 3,

        [DescriptionAttribute(Text = "Funny")]
        Funny = 3,
    }
}
