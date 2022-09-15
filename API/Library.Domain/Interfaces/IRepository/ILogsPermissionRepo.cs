using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface ILogsPermissionRepo : IBaseGetAllRepo<LogsPermission>, IBaseGetByIdRepo<LogsPermission>
        , IBaseAddRepo<LogsPermission>
    {
        Task<List<LogsPermission>> GetByUserId(int user_id);
        Task<List<LogsPermission>> GetByPermissionId(int permission_id);
    }
}
