using jcarrollonlinev4.backend.Models.Users;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaPostModel
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Id { get; set; }
        public ApplicationUserModel CreatedBy { get; set; } = null!;
    }
}
