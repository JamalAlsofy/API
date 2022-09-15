using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository.IBaseRepository;

namespace Library.Domain.Interfaces.IRepository
{
    public interface ICompanyRepo : IBaseAddRepo<Company>, IBaseUpdateRepo<Company>, IBaseGetByIdRepo<Company>
        , IBaseGetAllRepo<Company>, IBaseDeleteRepo<Company>
    {
    }
}
