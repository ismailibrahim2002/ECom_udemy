using ECom_db.Entities;
using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Cart;

namespace ECom_udemy.Base
{
    public interface IPaymentService
    {
        Task<ResponseDto> PayMoney(decimal totalAmount, IEnumerable<Product> products, IEnumerable<CartDto> carts);
    }
}
