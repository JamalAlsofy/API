using Library.Domain.DTOs;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IServices
{
    public interface IProviderCompaniesService
    {
        Task<List<ProviderCompany>> GetAll();
        Task<ServicesResultsDto> Add(ProviderCompany entity);
        Task<ServicesResultsDto> Edit(ProviderCompany entity);
        Task<ServicesResultsDto> Delete(int id);
        Task<ProviderCompany> Details(int id);
    }
}
