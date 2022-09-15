using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IProviderServicesRepo : IBaseGetAllRepo<ProviderServices>, IBaseGetByIdRepo<ProviderServices>, 
        IBaseAddRepo<ProviderServices> , IBaseUpdateRepo<ProviderServices>, IBaseDeleteRepo<int>
    {
    }
}
