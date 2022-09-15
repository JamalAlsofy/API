using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository.IBaseRepository;

namespace Library.Domain.Interfaces.IRepository
{
    public interface ICategoryRepo : IBaseGetAllRepo<Category>, IBaseGetByIdRepo<Category>
    {
    }
}
