using ECom_db.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECom_db.Base
{
    public interface ICart
    {
        Task<int> SaveCheckoutHistory(IEnumerable<ProductHistory> checkouts);
    }
}
