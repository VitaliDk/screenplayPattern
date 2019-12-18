using System;

namespace ComponentLibrary.UserClasses
{
    public class IdentityProviderUserModel
    {
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string id { get; set; }
        public Boolean isLockedOut { get; set; }
        public Boolean isDisabled { get; set; }
        public Boolean isDeleted { get; set; }
        public string lastLoginDate { get; set; }
        public string lastPasswordChangeDate { get; set; }
    }
}
