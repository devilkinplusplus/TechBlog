using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
namespace Business.Validations
{
    public class BlogValidator:AbstractValidator<BlogEditVM>
    {
        public BlogValidator()
        {
            RuleFor(x=>x.Description).NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Can't be empty");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Can't be empty");
        }
    }
}
