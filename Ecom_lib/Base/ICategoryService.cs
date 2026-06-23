using Ecom_lib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;


   
namespace Ecom_lib.Base
{
    public interface ICategoryService
    {
        Task<IEnumerable<GetCategoryDto>> GetAllAsync();
        Task<GetCategoryDto> GetByID(Guid id);
        Task<ResponseDto> AddAsync(CategoryDto entity);
        Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity);
        Task<ResponseDto> deleteAsync(Guid id);
    }
}

