using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;

namespace ComponentLibrary.Abilities
{
    public class View : IAbility
    {
        private readonly string productType;

        public void AddAbilityFor(User user)
        {
            switch (this.productType)
            {
                case "Orders":
                    user.dmiuser.CanViewOrders();
                    break;
                case "Settlements":
                    user.dmiuser.CanViewSettlements();
                    break;
                case "Balances":
                    user.dmiuser.CanViewBalances();
                    break;
                case "Holdings":
                    user.dmiuser.CanViewHoldings();
                    break;
                default:
                    throw new Exception();
            }
        }
        public View(string productType)
        {
            this.productType = productType;
        }

        public static View Orders()
        {
            return new View("Orders");
        }

        public static View Settlements()
        {
            return new View("Settlements");
        }

        public static View Balances()
        {
            return new View("Balances");
        }

        public  static View Holdings()
        {
            return new View("Holdings");
        }
    }
}
