using CMS.DAL.Models;
using FluentValidation;

namespace CMS.API.Validation
{
    public class MerchantValidator:AbstractValidator<Merchant>
    {
        public MerchantValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).Length(50);
            RuleFor(x => x.TerminalNo).NotNull().Length(16);


        }
    }
}
