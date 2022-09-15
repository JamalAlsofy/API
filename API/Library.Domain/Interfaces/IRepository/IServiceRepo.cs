using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IServiceRepo : IBaseGetAllRepo<Service>, IBaseGetByIdRepo<Service>, IBaseAddRepo<Service>
        , IBaseUpdateRepo<Service>, IBaseDeleteRepo<Service>
    {
    }
}
