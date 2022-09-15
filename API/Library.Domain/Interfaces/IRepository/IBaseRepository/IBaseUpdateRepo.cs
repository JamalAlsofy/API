

using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository.IBaseRepository
{
    public interface IBaseUpdateRepo<T> where T : class, new()
    {
        Task<bool> Update(T entity);
    }
}
