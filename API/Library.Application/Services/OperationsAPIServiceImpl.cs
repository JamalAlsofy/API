using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class OperationsAPIServiceImpl : IOperationsAPIService
    {
        private readonly IOperationsAPIRepo _repo;
        public OperationsAPIServiceImpl(IOperationsAPIRepo repo)
        {
            _repo = repo;
        }

        
        public async Task<List<OperationsAPI>> GetAll()
        {
            try
            {
                var lst = await _repo.GetAll();
                return lst;
            }
            catch (Exception)
            {
                return new List<OperationsAPI>();
            }
        }

        public async Task<List<OperationsAPI>> GetPaga(int pageNumber, int pageSize)
        {
            try
            {
                var lst = await _repo.GetPaga(pageNumber, pageSize);
                return lst;
            }
            catch (Exception)
            {
                return new List<OperationsAPI>();
            }
        }
    }
}
