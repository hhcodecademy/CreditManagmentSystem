
using CMS.DAL.DTOS;
using FluentValidation;

namespace CMS.API.Validation
{
    public class BranchValidator : AbstractValidator<BranchDto>
    {
        public BranchValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Ad").MinimumLength(3);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.MerchantId).NotNull();
            RuleFor(x=>x.Address).NotEmpty();



        }
    }
}
