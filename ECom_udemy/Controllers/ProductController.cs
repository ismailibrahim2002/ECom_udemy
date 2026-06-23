using Ecom_lib.Base;
using Ecom_lib.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom_udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController (IProductService srvProduce) : ControllerBase
    {
        [HttpGet("ALL")]
        public async Task<IActionResult>GetAll()
        {
            var result = await srvProduce.GetAllAsync();
            return result.Count()>0 ? Ok(result) : NotFound();
        }
        [HttpGet("item/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        { 
        var result = await srvProduce.GetByID(id);
            return result !=null ? Ok(result) : NotFound();
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddNew(ProductDto item)
        {
            var result = await srvProduce.AddAsync(item);

            return result != null ? Ok(result) : BadRequest(result);

        }
        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto item)
        {
            var result = await srvProduce.UpdateAsync(item);
            return result != null ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await srvProduce.deleteAsync(id);
            return result != null ? Ok(result) : BadRequest(result);

        }
    }

}
