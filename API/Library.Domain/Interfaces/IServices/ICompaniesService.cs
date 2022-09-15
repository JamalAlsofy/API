using Library.Domain.DTOs;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IServices
{
    public interface ICompaniesService
    {
        Task<List<Company>> GetAll();
        Task<ServicesResultsDto> Add(Company entity);
        Task<ServicesResultsDto> Edit(Company entity);
        Task<ServicesResultsDto> Delete(int id);
        Task<Company> Details(int id);
    }
}
