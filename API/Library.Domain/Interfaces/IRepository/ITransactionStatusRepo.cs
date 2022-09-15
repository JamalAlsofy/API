using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface ITransactionStatusRepo : IBaseGetAllRepo<TransactionStatus>, IBaseGetByIdRepo<TransactionStatus>
    {
        Task<List<TransactionStatus>> GetByCustomerId(int customer_id);
    }
}
