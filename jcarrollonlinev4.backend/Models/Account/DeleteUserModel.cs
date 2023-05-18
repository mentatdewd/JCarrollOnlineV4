using System.ComponentModel.DataAnnotations;

namespace jcarrollonlinev4.backend.Models.Account
{
    public class DeleteUserModel : ModelBase
    {
        public string? Id { get; set; }

        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
    }

}
