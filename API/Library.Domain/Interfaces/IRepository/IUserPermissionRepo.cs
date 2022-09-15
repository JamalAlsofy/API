using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IUserPermissionRepo : IBaseGetByIdRepo<UserPermissions>
        , IBaseUpdateRepo<UserPermissions>
    {
        Task<List<UserPermissions>> GetByUserId(int user_id);
        Task<bool> AddRange(List<UserPermissions> entities);
        Task<bool> DeleteRange(List<UserPermissions> entities);
    }
}
