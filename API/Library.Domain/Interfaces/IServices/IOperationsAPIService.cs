using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IServices
{
    public interface IOperationsAPIService
    {
        Task<List<OperationsAPI>> GetAll();
        Task<List<OperationsAPI>> GetPaga(int pageNumber, int pageSize);
    }
}
