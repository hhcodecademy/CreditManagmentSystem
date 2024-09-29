using CMS.DAL.DTOS;
using FluentValidation;

namespace CMS.API.Validation
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
