using Ecom_lib.Base;
using Ecom_lib.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom_udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService srvCategory) : ControllerBase
    {
        [HttpGet("ALL")]
        public async Task<IActionResult> GetAll()
        {
            var result = await srvCategory.GetAllAsync();
            return result.Count() > 0 ? Ok(result) : NotFound();
        }

        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var result = await srvCategory.GetByID(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNew(CategoryDto item)
        {
            var result = await srvCategory.AddAsync(item);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateCategoryDto item)
        {
            var result = await srvCategory.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvCategory.deleteAsync(id);
            return result != null ? Ok(result) : BadRequest(result);
        }
    }
}
