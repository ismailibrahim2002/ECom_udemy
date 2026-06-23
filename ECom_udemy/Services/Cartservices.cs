using AutoMapper;
using ECom_db.Base;
using ECom_db.Entities;
using Ecom_lib.Base;
using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Cart;
using ECom_udemy.Base;
using Stripe;

namespace ECom_udemy.Services
{
    public class CartService(ICart repo, IMapper mapper, IGenralRepo<ECom_db.Entities.Product> productRepo,
    IPaymentMethodService paymentMethod, IPaymentService service) : ICartservices
    {
        public async Task<ResponseDto> DoCheckout(CheckoutDto checkout, string userId)
        {
            var (products, amount) = await GetCartAmount(checkout.Carts);
            var payMethododes = await paymentMethod.GetPaymentMethod();

            if (payMethododes != null && checkout.PaymentMethodId == payMethododes.FirstOrDefault()!.Id)
            {
                var result = await service.PayMoney(amount, products, checkout.Carts);
                return result;
            }

            return new ResponseDto(false, "Something is worng try again");
        }

        private async Task<(IEnumerable<ECom_db.Entities.Product>, decimal)> GetCartAmount(IEnumerable<CartDto> carts)
        {
            if (!carts.Any()) return ([], 0);
            var products = await productRepo.GetAllAsync();
            if (!products.Any()) return ([], 0);

            var cartPros = carts.Select(i => products.FirstOrDefault(p => p.Id == i.productId))
                .Where(p => p != null).ToList();

            var totalAmount = carts.Where(i => cartPros.Any(p => p!.Id == i.productId))
                .Sum(ci => ci.QTY * cartPros.First(p => p!.Id == ci.productId)!.Price);

            return (cartPros!, totalAmount!.Value);
        }
        public async Task<ResponseDto> SaveCheckoutHistory(IEnumerable<ProductHistoryDto> checkouts)
        {
            var mappedData = mapper.Map<IEnumerable<ProductHistory>>(checkouts);
            var result = await repo.SaveCheckoutHistory(mappedData);

            ResponseDto response = new ResponseDto(true, "Checkout saved done");
            if (result <= 0)
            {
                response = new ResponseDto(false, "Error in save checkout");
            }

            return response;
        }
    }
}
