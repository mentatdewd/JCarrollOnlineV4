namespace jcarrollonlinev4.backend.Models.Users
{
    public class UserModelBase : ModelBase
    {
        public UserModelBase()
        {
            User = new ApplicationUserModel();
        }
        public ApplicationUserModel User { get; set; }
    }
}
