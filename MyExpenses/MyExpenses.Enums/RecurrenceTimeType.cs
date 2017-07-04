using PSC.Xamarin.Controls.EnumBindablePicker.Extensions;

namespace MyExpenses.Enums {
    public enum RecurrenceTimeType
    {
        [DescriptionAttribute(Text = "One off")]
        OneOff = 0,

        [DescriptionAttribute(Text = "Daily")]
        Daily = 1,

        [DescriptionAttribute(Text = "Weekly")]
        Weekly = 2,

        [DescriptionAttribute(Text = "Monthly")]
        Monthly = 3,
    }
}
