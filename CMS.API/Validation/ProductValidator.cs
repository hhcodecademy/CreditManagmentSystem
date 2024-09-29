using CMS.DAL.DTOS;
using FluentValidation;

namespace CMS.API.Validation
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).Length(5);
            RuleFor(x => x.Price).InclusiveBetween(1,100);
            RuleFor(x => x.Stock).InclusiveBetween(1, 100);
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.Brand).NotEmpty();


        }
    }
}
