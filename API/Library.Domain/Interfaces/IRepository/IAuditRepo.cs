using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository.IBaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IAuditRepo : IBaseGetAllRepo<Audit>, IBaseGetByIdRepo<Audit>
    {
        Task<List<Audit>> GetByUserId(int user_id);
    }
}
