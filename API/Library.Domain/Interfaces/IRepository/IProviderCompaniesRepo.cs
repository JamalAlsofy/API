using Library.Domain.Interfaces.IRepository.IBaseRepository;
using Library.Domain.Entities;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository
{
    public interface IProviderCompaniesRepo : IBaseGetAllRepo<ProviderCompany>, IBaseGetByIdRepo<ProviderCompany>, IBaseAddRepo<ProviderCompany>
        , IBaseUpdateRepo<ProviderCompany>, IBaseDeleteRepo<ProviderCompany>
    {
        Task<ProviderCompany> GetByCompIdAndProviderId(int mainCom_id, int provider_id);
    }
}
