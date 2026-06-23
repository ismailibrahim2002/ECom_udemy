using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Cart;

namespace ECom_udemy.Base
{
    public interface ICartservices
    {
        Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistoryDto> checkouts);

        Task<ResponseDto> DoCheckout(CheckoutDto checkout, string userId);

    }
}
