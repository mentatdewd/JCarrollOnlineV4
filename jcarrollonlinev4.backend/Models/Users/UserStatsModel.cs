namespace jcarrollonlinev4.backend.Models.Users
{
    public class UserStatsModel : UserModelBase
    {
        public UserStatsModel()
        {
            UserFollowers = new UserFollowersModel();
            UsersFollowing = new UserFollowingModel();
        }
        public UserFollowersModel UserFollowers { get; set; }
        public UserFollowingModel UsersFollowing { get; set; }
    }
}
