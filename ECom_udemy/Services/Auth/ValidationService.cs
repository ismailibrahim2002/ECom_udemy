using Ecom_lib.Dtos;
using ECom_udemy.Base;
using FluentValidation;

namespace ECom_udemy.Services.Auth
{
    public class ValidationServices : IValidationServices
    {
        public async Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator)
        {
            var _validator = await validator.ValidateAsync(model);
            
            if (!_validator.IsValid)
            {
                var errors = _validator.Errors.Select(e => e.ErrorMessage).ToList();
                string errorsToString = string.Join(", ", errors);
                return new ResponseDto { Msessage = errorsToString };
            }
            return new ResponseDto { Success = true };
        }
    }
}
