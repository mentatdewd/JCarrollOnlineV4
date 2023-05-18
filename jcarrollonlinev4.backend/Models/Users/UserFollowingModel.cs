namespace jcarrollonlinev4.backend.Models.Users
{
    public class UserFollowingModel : UserModelBase
    {
        public UserFollowingModel()
        {
            Users = new List<UserItemModel>();
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<UserItemModel> Users { get; set; }
    }
}
