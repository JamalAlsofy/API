using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Library.Domain.Interfaces.IRepository;
using Library.Infrastructure.Data;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class OperationsAPIRepoImpl : IOperationsAPIRepo
    {
        private readonly ILogger<OperationsAPIRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(OperationsAPIRepoImpl);
        private DbSet<OperationsAPI> _dbSet;
        public OperationsAPIRepoImpl(PaymentServicesContext db, ILogger<OperationsAPIRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.OperationsAPIs;
        }

        public async Task<List<OperationsAPI>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", type);
                throw;
            }
        }

        public async Task<OperationsAPI> GetById(object id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", type);
                throw;
            }
        }

        public async Task<List<OperationsAPI>> GetPaga(int pageNumber, int pageSize)
        {
            try
            {
               // int pageNumber = 1, int pageSize = 2;
                var pagedData = await _dbSet
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize).ToListAsync();
                return pagedData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", type);
                throw;
            }
        }
    }
}
