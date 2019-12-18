using System;
using ComponentLibrary.UserClasses;

namespace ComponentLibrary.Interfaces
{
    public interface IObservation
    {
        Boolean CanBeSeen(User user);
    }
}
