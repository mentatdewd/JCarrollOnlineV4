namespace jcarrollonlinev4.backend.Models
{
    public class UserWelcomeViewModel : EmailModelBase
    {
        public Uri? CallbackUrl { get; set; }
        //public bool IsPremiumUser { get; set; }
    }
}
