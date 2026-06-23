using AutoMapper;
using ECom_db.Base.Paymants;
using Ecom_lib.Base;
using Ecom_lib.Dtos.Paymants;

namespace ECom_udemy.Services.Payments
{
    public class PaymentMethodService(IPaymentMethodsRepo repo, IMapper mapper) : IPaymentMethodService
    {
        public async Task<IEnumerable<PaymentMethodDto>> GetPaymentMethod()
        {
            var methodes = await repo.GetAllPaymentMethods();
            if (!methodes.Any()) return [];
            return mapper.Map<IEnumerable<PaymentMethodDto>>(methodes);
        }
    }
}
