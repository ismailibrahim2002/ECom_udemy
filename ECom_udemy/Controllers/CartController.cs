using Ecom_lib.Dtos.Cart;
using ECom_udemy.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom_udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(ICartservices cartService) : ControllerBase
    {
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout(CheckoutDto checkout)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                var result = await cartService.DoCheckout(checkout, "0");
                return result.Success ? Ok(result) : BadRequest(result);
            }
        }

        [HttpPost("saveCheckout")]
        public async Task<IActionResult> SaveCheckout(IEnumerable<ProductHistoryDto> historyDtos)
        {
            var result = await cartService.SaveCheckoutHistory(historyDtos);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }  
}