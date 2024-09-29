using CMS.DAL.Models;
using FluentValidation;

namespace CMS.API.Validation
{
    public class MerchantValidator:AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description);
            RuleFor(x => x.TerminalNo).NotNull();


        }
    }
}
