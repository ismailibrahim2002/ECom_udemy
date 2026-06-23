using ECom_db.Base.Paymants;
using ECom_db.Context;
using ECom_db.Entities.Payment;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Repos.Paymants
{
    public class PaymentMethodsRepo(AppDbContext context) : IPaymentMethodsRepo
    {
        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            return await context.paymentMethods.AsNoTracking().ToListAsync();
        }
    }
}
