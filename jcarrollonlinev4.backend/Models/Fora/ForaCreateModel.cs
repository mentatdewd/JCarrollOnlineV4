using Microsoft.AspNetCore.Mvc;

namespace jcarrollonlinev4.backend.Models.Fora
{
    public class ForaCreateModel
    {
        public string? title { get; set; } = string.Empty;

        public string? description { get; set; } = string.Empty;

        public int? id { get; set; }
    }
}
