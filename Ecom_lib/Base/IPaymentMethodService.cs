using Ecom_lib.Dtos.Paymants;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom_lib.Base
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodDto>> GetPaymentMethod();
    }
}
