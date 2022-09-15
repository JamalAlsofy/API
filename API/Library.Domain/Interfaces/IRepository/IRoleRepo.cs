using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IRoleRepo : IBaseGetAllRepo<Role>, IBaseGetByIdRepo<Role>, IBaseAddRepo<Role>
        , IBaseUpdateRepo<Role>, IBaseDeleteRepo<int>
    {
    }
}
