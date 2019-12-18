using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actions;
using ComponentLibrary.Screens;
using OpenQA.Selenium;
using ComponentLibrary.Observations;

namespace ComponentLibrary.Tasks
{
    public class ExpandAllDatagrids : ITask
    {
        public void PerformAs(User user)
        {
            By expandDataGridToggle = DMISettlementsPageScreen.closedDatagridArrowToggle;
            while (Element.WithId(expandDataGridToggle).CanBeFoundOnThePageBy(user))
            {
                user.AttemptsTo(Click.On(expandDataGridToggle));
            }
        }

        public static ExpandAllDatagrids OnTheSettlementsPage()
        {
            return new ExpandAllDatagrids();
        }

        public static ExpandAllDatagrids OnTheRegisterPage()
        {
            return new ExpandAllDatagrids();
        }

    }
}
