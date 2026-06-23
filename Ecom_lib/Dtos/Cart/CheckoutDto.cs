using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos.Cart
{
    public class CheckoutDto
    {
        public required Guid PaymentMethodId { get; set; }

        public required IEnumerable<CartDto> Carts { get; set; }
    }
}
