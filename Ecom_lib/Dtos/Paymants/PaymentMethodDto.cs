using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos.Paymants
{
    public class PaymentMethodDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
