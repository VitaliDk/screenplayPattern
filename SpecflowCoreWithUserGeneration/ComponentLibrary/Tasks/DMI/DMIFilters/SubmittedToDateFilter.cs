using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;
using System.Globalization;
using ComponentLibrary.Screens.UI;


namespace ComponentLibrary.DMIFilters
{
    public class SubmittedToDateFilter : IDmiFilter
    {
        int day;
        string month;
        string year;

        public void FilterBy(User user)
        {
            var currentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month);
            var currentYear = DateTime.Today.Year.ToString();

            Log.Task($"filter by the 'submitted to date' by the date: {this.day} {this.month} {this.year}");
            user.AttemptsTo(Click.On(SubmittedToDate.OpenCalendar),
                            Click.On(DMIOrdersPageScreen.ToDateMonthYearSelector($"{currentYear}")), //{currentMonth} {currentYear}
                            Click.On(DMIOrdersPageScreen.ToDateMonthYearSelector($"{currentYear}")),
                            Click.On(DMIOrdersPageScreen.ToDateMonthYearSelector(this.year)),
                            Click.On(DMIOrdersPageScreen.ToDateMonthYearSelector(this.month)),
                            Click.On(DMIOrdersPageScreen.ToDateDaySelector($"{this.day}")));
        }
        public SubmittedToDateFilter(int day, string month, string year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }

        public static SubmittedToDateFilter EqualTo(int day, string month, string year)
        {
            return new SubmittedToDateFilter(day, month, year);
           // return Instrumented.InstanceOfs<SubmittedToDate>(day, month, year);
        }

    }
}
