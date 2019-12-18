using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using System;
using OpenQA.Selenium;

namespace ComponentLibrary.Tasks

{
    public class NavigateToCalendarView : ITask
    {
        By id;

        public void PerformAs(User user)
        {
            throw new NotImplementedException();
        }

        public NavigateToCalendarView(By id)
        {
            this.id = id;
        }

        public static NavigateToCalendarView ForTheCurrentYear(By id)
        {
            return new NavigateToCalendarView(id);
        }
    }
}
