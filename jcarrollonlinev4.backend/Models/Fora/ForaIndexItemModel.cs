using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaIndexItemModel : ForaModelBase
    {
        [Display(Name = "Title")]
        public string? Title { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Thread Count")]
        public int ThreadCount { get; set; }

        [Display(Name = "Last Thread")]
        public LastThreadModel? LastThread { get; set; }
    }
}
