
namespace jcarrollonlinev4.backend.Models
{
    public interface IModelBase
    {
        string? PageContainer { get; set; }
        string? PageTitle { get; set; }
        string? Message { get; set; }
    }

    public class ModelBase : IModelBase
    {
        public string? PageContainer { get; set; }
        public string? PageTitle { get; set; }
        public string? Message { get; set; }
    }
}

