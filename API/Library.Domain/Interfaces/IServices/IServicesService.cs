using Library.Domain.DTOs;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IServices
{
    public interface IServicesService
    {
        Task<List<Service>> GetAll();
        Task<ServicesResultsDto> Add(Service entity);
        Task<ServicesResultsDto> Edit(Service entity);
        Task<ServicesResultsDto> Delete(int id);
        Task<Service> Details(int id);
    }
}
