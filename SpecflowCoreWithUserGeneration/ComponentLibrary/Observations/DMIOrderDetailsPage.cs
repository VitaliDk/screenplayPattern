using System;
using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;
using ComponentLibrary.Actions;
using ComponentLibrary.Config;

namespace ComponentLibrary.Observations
{
    public class DMIOrderDetailsPage : IObservation
    {
        string fieldName;
        string fieldValue;

        public bool CanBeSeen(User user)
        {
            try
            {
                Log.Observation($"the DMIOrderDetailsPage has a field '{fieldName}' with a value of '{fieldValue}'");
                string text = Get.InnerText(user.driver, Screens.DMIOrderDetailsPageScreen.Field(this.fieldName));
                if (text == this.fieldValue)
                {
                    Log.ObservationOutcome($"the field '{fieldName}' did have a value of '{fieldValue}'");
                    return true;
                }
                else
                {
                    Log.ObservationOutcome($"the actual value found was {text}");
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static DMIOrderDetailsPage SystemName()
        {
            return new DMIOrderDetailsPage("systemName");
        }
        public static DMIOrderDetailsPage DMIOrderId()
        {
            return new DMIOrderDetailsPage("orderId");
        }

        public DMIOrderDetailsPage(string fieldName)
        {
            this.fieldName = fieldName;
        }

        public DMIOrderDetailsPage HasAValueOf(string fieldValue)
        {
            this.fieldValue = fieldValue;
            return this;
        }


    }
}
