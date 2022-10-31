using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class EditProfileValidator:AbstractValidator<EditProfileDTO>
    {
        public EditProfileValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Writer name is required");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email adrress");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
