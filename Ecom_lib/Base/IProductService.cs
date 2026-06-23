using Ecom_lib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Base
{
    public interface IProductService
    {
        Task<IEnumerable<GetProductDto>> GetAllAsync();
        Task<GetProductDto> GetByID(Guid id);
        Task<ResponseDto> AddAsync(ProductDto entity);
        Task<ResponseDto> UpdateAsync(UpdateProductDto entity);
        Task<ResponseDto> deleteAsync(Guid id);
    }
}
