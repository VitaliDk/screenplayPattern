using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Config;

namespace ComponentLibrary.Tasks
{
    public class FilterResults : ITask
    {
        IDmiFilter[] filters;

        public void PerformAs(User user)
        {
            for (int listOfFilters = 0; listOfFilters < filters.Length; listOfFilters++)
            {
                filters[listOfFilters].FilterBy(user);
            }
        }

        public FilterResults(params IDmiFilter[] filters) 
        {
            this.filters = filters;
        }

        public static FilterResults By(params IDmiFilter[] dmiFilters)
        {
            Log.Task("filter results on the page");
            return new FilterResults(dmiFilters);
        }
       

    }
}
