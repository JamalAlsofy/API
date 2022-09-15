using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IPermissionRepo : IBaseGetAllRepo<Permission>, IBaseGetByIdRepo<Permission>
    {
        Task<List<Permission>> GetByParentId(int parent_id);
    }
}
