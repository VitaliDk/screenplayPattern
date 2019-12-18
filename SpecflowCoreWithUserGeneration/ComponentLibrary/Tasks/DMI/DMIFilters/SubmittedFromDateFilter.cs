using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using ComponentLibrary.UserClasses;
using System.Globalization;
using ComponentLibrary.Config;
using ComponentLibrary.Screens.UI;

namespace ComponentLibrary.DMIFilters
{
    public class SubmittedFromDateFilter : IDmiFilter
    {
        int day;
        string month;
        string year;

        public void FilterBy(User user)
        {
            var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
            var currentYear = DateTime.Today.Year.ToString();

            Log.Task($"filter by the 'submitted from date' by the date: {this.day} {this.month} {this.year}");
            user.AttemptsTo(Click.On(SubmittedFromDate.OpenCalendar),
                            Click.On(DMIOrdersPageScreen.FromDateMonthYearSelector($"{currentMonth} {currentYear}")),
                            Click.On(DMIOrdersPageScreen.FromDateMonthYearSelector($"{currentYear}")),
                            Click.On(DMIOrdersPageScreen.FromDateMonthYearSelector(this.year)),
                            Click.On(DMIOrdersPageScreen.FromDateMonthYearSelector(this.month)),
                            Click.On(DMIOrdersPageScreen.FromDateDaySelector($"{this.day}")));
        }

        public SubmittedFromDateFilter(int day, string month, string year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public static SubmittedFromDateFilter EqualTo(int day, string month, string year)
        {
            return new SubmittedFromDateFilter(day, month, year);
        }

    }
}
