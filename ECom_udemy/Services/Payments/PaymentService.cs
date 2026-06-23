using ECom_db.Entities;
using Ecom_lib.Dtos;
using Ecom_lib.Dtos.Cart;
using ECom_udemy.Base;
using Stripe.Checkout;

namespace ECom_udemy.Services.Payments
{
    public class PaymentService : IPaymentService
    {
       
        public async Task<ResponseDto> PayMoney(decimal totalAmount, IEnumerable<Product> products, IEnumerable<CartDto> carts)
        {
            try
            {
                var lines = new List<SessionLineItemOptions>();
                foreach (var item in products)
                {
                    var proQty = carts.FirstOrDefault(p => p.productId == item.Id);
                    lines.Add(new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "usd",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = item.Name,
                                Description = item.Description,
                            },
                            UnitAmount = (long)(item.Price! * 100),
                        },
                        Quantity = proQty!.QTY
                    });
                }
                var options = new SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string> { "card" }, // التصحيح: هنا نكتب طرق الدفع مثل card وليس العملة usd
                    LineItems = lines,
                    Mode = "payment", // التصحيح: الكلمة الصحيحة هي payment وليس paymnet
                    SuccessUrl = "http://localhost:8069/paymentSuccess", // يفضل تصحيح الإملاء بالروابط أيضاً إذا كانت تابعة للكونترولر لديك
                    CancelUrl = "http://localhost:8069/paymentCancel"
                };

                var service = new SessionService();
                Session session = await service.CreateAsync(options);
                return new ResponseDto(true, session.Url);
            }
            catch (Exception ex)
            {
                return new ResponseDto(false, ex.Message);
            }
        }

        
    }
}
