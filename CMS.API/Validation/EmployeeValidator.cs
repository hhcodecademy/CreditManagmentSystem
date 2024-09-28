using CMS.DAL.DTOS;
using FluentValidation;

namespace CMS.API.Validation
{
    public class EmployeeValidator : ValidatorBase<EmployeeDto>
    {
        public EmployeeValidator() : base()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Adini mutleq doldurun");
            RuleFor(x => x.Surname).NotNull();
            RuleFor(x => x.Phone).Must(x => x.StartsWith("+994"))
                .WithMessage("Telefon nomresi +994 le baslamalidir");
            RuleFor(x => x.Email).NotEmpty();

        }
    }
}
