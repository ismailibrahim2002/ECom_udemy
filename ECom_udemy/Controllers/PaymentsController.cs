using Ecom_lib.Base;
using Ecom_lib.Dtos.Paymants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECom_udemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController(IPaymentMethodService payService) : ControllerBase
    {
        [HttpGet("payMethods")]
        public async Task<ActionResult<IEnumerable<PaymentMethodDto>>> GetPaymentMethodes()
        {
            var methods = await payService.GetPaymentMethod();
            if (!methods.Any())
                return NotFound();

            return Ok(methods);
        }
    }
}
