using AutoMapper;
using ECom_db.Base;
using ECom_db.Entities;
using Ecom_lib.Base;
using Ecom_lib.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_udemy.Services

{
    public class ProductServices(IGenralRepo<Product> product,IMapper mapper) : IProductService
    {
        public async Task<ResponseDto> AddAsync(ProductDto entity)
        {
            //try
            {
                var mappData = mapper.Map<Product>(entity);
                int result = await product.AddAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            //catch (Exception ex)
          //  {
            //    return new ResponseDto(false, ex.Message);
            //}
            return new ResponseDto(false, "Please check your server Can't save ?!");
        }

        public async Task<ResponseDto> deleteAsync(Guid id)
        {
            try
            {
                int result = await product.DeleteAsync(id);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check your server Can't delete ?!");
        }

        public async Task<IEnumerable<GetProductDto>> GetAllAsync()
        {
            try
            {
                var data = await product.GetAllAsync();
                if (data == null || !data.Any()) return [];
                return mapper.Map<IEnumerable<GetProductDto>>(data);
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetProductDto> GetByID(Guid id)
        {
            try
            {
                var data = await product.GetByID(id);
                if (data == null) return new GetProductDto();
                return mapper.Map<GetProductDto>(data);
            }
            catch
            {
                return new GetProductDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateProductDto entity)
        {
            try
            {
                var mappData = mapper.Map<Product>(entity);
                int result = await product.UpdateAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check your server Can't Update ?!");
        }
    }
}
