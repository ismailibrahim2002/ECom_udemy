using ECom_db.Base;
using ECom_db.Context;
using ECom_db.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Repos
{
    public class CartRepo(AppDbContext context) : ICart
    {
        public async Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory> checkouts)
        {
            context.ProductHistories.AddRange(checkouts);
            return await context.SaveChangesAsync();
        }
    }
}
