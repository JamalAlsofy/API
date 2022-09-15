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
    public class ServiceRepoImpl : IServiceRepo
    {
        private readonly ILogger<ServiceRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(ServiceRepoImpl);
        private DbSet<Service> _dbSet;
        public ServiceRepoImpl(PaymentServicesContext db, ILogger<ServiceRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Services;
        }

        public async Task<bool> Add(Service entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", type);
                throw;
            }
        }
        //Service
        public async Task<bool> Delete(Service entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", type);
                throw;
            }
        }

        public async Task<List<Service>> GetAll()
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

        public async Task<Service> GetById(object id)
        {
            try
            {
                return await _dbSet.Where(a => a.id == (int)id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", type);
                throw;
            }
        }

        public async Task<bool> Update(Service entity)
        {
            try
            {
                _dbSet.Update(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", type);
                throw;
            }
        }

    }
}
