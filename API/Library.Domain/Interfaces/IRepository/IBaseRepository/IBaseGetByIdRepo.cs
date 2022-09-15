

using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository.IBaseRepository
{
    public interface IBaseGetByIdRepo<T> where T : class, new()
    {
        Task<T> GetById(object id);
    }
}
