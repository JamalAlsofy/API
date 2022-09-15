using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository.IBaseRepository
{
    public interface IBaseGetAllRepo<T> where T : class, new()
    {
        Task<List<T>> GetAll();
    }
}
