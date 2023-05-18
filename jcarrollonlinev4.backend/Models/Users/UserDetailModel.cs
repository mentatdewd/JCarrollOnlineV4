namespace jcarrollonlinev4.backend.Models.Users
{
    public class UserDetailModel : UserModelBase
    {
        //private static Logger logger = LogManager.GetCurrentClassLogger();

        public UserDetailModel()
        {
            UserInfoModel = new UserItemModel();
            UserStatsModel = new UserStatsModel();
        }
        public UserItemModel UserInfoModel { get; set; }
        public UserStatsModel UserStatsModel { get; set; }
    }
}
