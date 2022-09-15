using Library.Domain.DTOs;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IServices
{
    public interface IProviderService
    {
        Task<List<Provider>> GetAll();
        Task<ServicesResultsDto> Add(Provider entity);
        Task<ServicesResultsDto> Edit(Provider entity);
        Task<ServicesResultsDto> Delete(int id);
        Task<Provider> Details(int id);
    }
}
