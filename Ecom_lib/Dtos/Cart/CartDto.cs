using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Dtos.Cart
{
    public class CartDto
    {
        public required Guid productId { get; set; }
        public required int QTY { get; set; }
    }
}
