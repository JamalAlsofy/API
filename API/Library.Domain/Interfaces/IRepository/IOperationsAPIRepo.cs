using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IOperationsAPIRepo : IBaseGetAllRepo<OperationsAPI>, IBaseGetByIdRepo<OperationsAPI>
    {
        Task<List<OperationsAPI>> GetPaga(int pageNumber, int pageSize = 10);
    }
}
