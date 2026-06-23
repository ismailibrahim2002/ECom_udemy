using ECom_db.Entities.Payment;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Base.Paymants
{
    public interface IPaymentMethodsRepo
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();
    }
}
