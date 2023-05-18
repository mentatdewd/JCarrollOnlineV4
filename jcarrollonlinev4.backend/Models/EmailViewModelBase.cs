using jcarrollonlinev4.backend.Entities;

namespace jcarrollonlinev4.backend.Models
{
    public class EmailModelBase
    {
        public ApplicationUser? TargetUser { get; set; }
        public string? Content { get; set; }
    }
}
