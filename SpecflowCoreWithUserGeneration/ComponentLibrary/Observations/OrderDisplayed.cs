using ComponentLibrary.Interfaces;
using ComponentLibrary.Screens;
using ComponentLibrary.UserClasses;
using OpenQA.Selenium;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class OrderDisplayed : IObservation
    {
        private int id;
        private bool idSet = false;
        private By orderDetailsLink;

        public bool CanBeSeen(User user)
        {
            if (idSet == true)
            {
                Log.Observation($"an order with id {id} is displayed on the page");
                user.FoundOrderId = DMIOrdersPageScreen.OrderDetailsLink(id);
                return Element.WithId(DMIOrdersPageScreen.OrderDetailsLink(id)).CanBeFoundOnThePageBy(user);
            }
            else
            {
                int containsdigit = 0;

                Element.WithId(DMIOrdersPageScreen.DmiOrderIdSearchField).CanBeFoundOnThePageBy(user);

                By OrderDetailsPageLink = DMIOrdersPageScreen.OrderDetailsLink(containsdigit);          

                while (Element.WithId(OrderDetailsPageLink).CannotBeFoundOnThePageBy(user) && containsdigit < 10)
                {
                    Log.Observation($"an order exists on the page whose orderId contains the digit {containsdigit}");
                    OrderDetailsPageLink = DMIOrdersPageScreen.OrderDetailsLink(containsdigit);
                    containsdigit += 1;
                }
                if (containsdigit == 10)
                {   // Assumption that if no link was found containing digits 0 to 9, then there is no order displayed
                    return false;
                }
                else
                {
                    this.orderDetailsLink = OrderDetailsPageLink;
                    user.FoundOrderId = containsdigit == 0 ? DMIOrdersPageScreen.OrderDetailsLink(0) : DMIOrdersPageScreen.OrderDetailsLink(containsdigit - 1);
                    return true;
                }

            }
        }

        public static OrderDisplayed OnThePage()
        {
            return new OrderDisplayed();
        }

        public OrderDisplayed WithOrderId(int id)
        {
            this.id = id;
            this.idSet = true;
            return this;
        }
        
        
    }
}
