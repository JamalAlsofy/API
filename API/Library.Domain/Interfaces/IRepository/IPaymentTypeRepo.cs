using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IPaymentTypeRepo : IBaseGetAllRepo<PaymentType>
    {
    }
}
