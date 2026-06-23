using Ecom_lib.Dtos;
using FluentValidation;

namespace ECom_udemy.Base
{
    public interface IValidationServices
    {
        Task<ResponseDto> ValidationAsync<T>(T model, IValidator<T> validator);
    }
}
