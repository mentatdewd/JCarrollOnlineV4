using FluentValidation;
using System;
using System.ComponentModel.DataAnnotations;

namespace JCarrollOnline.ViewModels
{
    public class MicropostViewModel
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string AuthorEmail { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(140)]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; } // :null => false

        [DataType(DataType.DateTime)]
        public DateTime UpdatedAt { get; set; } // :null => false
    }

    public class MicroPostViewModelValidator : AbstractValidator<MicropostViewModel>
    {
        public MicroPostViewModelValidator()
        {
            RuleFor(create => create.Content).NotEmpty().WithMessage("Content cannot be empty");
            //RuleFor(register => register.Gender).NotEmpty().WithMessage("Gender cannot be empty");
        }
    }
}
