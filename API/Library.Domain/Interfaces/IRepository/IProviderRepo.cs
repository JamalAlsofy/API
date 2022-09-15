using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IProviderRepo : IBaseGetAllRepo<Provider>, IBaseGetByIdRepo<Provider>, IBaseAddRepo<Provider>
        , IBaseUpdateRepo<Provider>, IBaseDeleteRepo<Provider>
    {
    }
}
