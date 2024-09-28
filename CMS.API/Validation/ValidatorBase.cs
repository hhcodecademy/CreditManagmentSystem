using CMS.DAL.DTOS;
using FluentValidation;

namespace CMS.API.Validation
{
    public abstract class ValidatorBase<TDto> :  AbstractValidator<TDto>
        where TDto : BaseDto
    {
        protected ValidatorBase()
        {
           
        }

    }
}
