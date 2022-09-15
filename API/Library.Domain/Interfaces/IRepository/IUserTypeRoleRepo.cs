using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IUserTypeRoleRepo : IBaseGetAllRepo<UserTypeRole>, IBaseGetByIdRepo<UserTypeRole>, IBaseAddRepo<UserTypeRole>
        , IBaseUpdateRepo<UserTypeRole>, IBaseDeleteRepo<int>
    {
    }
}
