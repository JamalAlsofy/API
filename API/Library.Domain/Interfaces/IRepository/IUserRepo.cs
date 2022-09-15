using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IUserRepo : IBaseGetAllRepo<User>, IBaseGetByIdRepo<User>,IBaseAddRepo<User>
        , IBaseUpdateRepo<User>, IBaseDeleteRepo<int>
    {
    }
}
