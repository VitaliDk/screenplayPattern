using ComponentLibrary.Interfaces;
using ComponentLibrary.UserClasses;

namespace ComponentLibrary.Abilities
{
    public class Access : IAbility
    {
        DMIUser dmiuser;

        public void AddAbilityFor(User user)
        {
            user.dmiuser = dmiuser;
        }

        public Access(DMIUser dmiuser)
        {
            this.dmiuser = dmiuser;
        }

        public static Access TheDmi()
        {
            DMIUser dmiuser = DMIUser.Create(ComponentLibrary.Config.Environment.ClientId).GetAwaiter().GetResult();
            return new Access(dmiuser);
        }

        public Access WithUsername(string username)
        {
            DMIUser dmiuser = DMIUser.Create(ComponentLibrary.Config.Environment.ClientId, username).GetAwaiter().GetResult();
            this.dmiuser = dmiuser;
            return this;
        }

    }
}
