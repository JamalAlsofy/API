using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IPermissionRoleRepo : IBaseGetAllRepo<PermissionRole>, IBaseGetByIdRepo<PermissionRole>, IBaseAddRepo<PermissionRole>
        , IBaseUpdateRepo<PermissionRole>, IBaseDeleteRepo<int>
    {
    }
}
