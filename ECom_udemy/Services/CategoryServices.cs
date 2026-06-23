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
    public class CategoryServices(IGenralRepo<Category> category, IMapper mapper) : ICategoryService
    {
        public async Task<ResponseDto> AddAsync(CategoryDto entity)
        {
            try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.AddAsync(mappData);
                if (result > 0)
                {
                    return new ResponseDto(true, "Success !");
                }
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
            return new ResponseDto(false, "Please check your server Can't save ?!");
        }

        public async Task<ResponseDto> deleteAsync(Guid id)
        {
            try
            {
                int result = await category.DeleteAsync(id);
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

        public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
        {
            try
            {
                var data = await category.GetAllAsync();
                if (data == null || !data.Any()) return [];
                return mapper.Map<IEnumerable<GetCategoryDto>>(data);
            }
            catch
            {
                return [];
            }
        }

        public async Task<GetCategoryDto> GetByID(Guid id)
        {
            try
            {
                var data = await category.GetByID(id);
                if (data == null) return new GetCategoryDto();
                return mapper.Map<GetCategoryDto>(data);
            }
            catch
            {
                return new GetCategoryDto();
            }
        }

        public async Task<ResponseDto> UpdateAsync(UpdateCategoryDto entity)
        {
            try
            {
                var mappData = mapper.Map<Category>(entity);
                int result = await category.UpdateAsync(mappData);
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
