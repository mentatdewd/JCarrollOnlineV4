using jcarrollonlinev4.backend.Models.Users;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class LastThreadModel : ForaModelBase
    {
        public DateTime UpdatedAt { get; set; }
        public string? Title { get; set; }
        public int PostRoot { get; set; }
        public int PostNumber { get; set; }
        public ApplicationUserModel? Author { get; set; }
        public ForaModel? Forum { get; set; }
    }

}
