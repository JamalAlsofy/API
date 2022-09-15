

using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository.IBaseRepository
{
    public interface IBaseDeleteRepo<T> //where T : struct
    {
        Task<bool> Delete(T entity);
    }
}
