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
    public class ProviderServicesRepoImpl : IProviderServicesRepo
    {
        private readonly ILogger<ProviderServicesRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(ProviderServicesRepoImpl);
        private DbSet<ProviderServices> _dbSet;
        public ProviderServicesRepoImpl(PaymentServicesContext db, ILogger<ProviderServicesRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.ProviderServices;
        }

        public async Task<bool> Add(ProviderServices entity)
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

        public async Task<bool> Delete(int id)
        {
            try
            {
                var existingEntity =await _dbSet.Where(x => x.id == id).FirstOrDefaultAsync();

                if (existingEntity != null)
                {
                    _dbSet.Remove(existingEntity);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", type);
                throw;
            }
        }

        public async Task<List<ProviderServices>> GetAll()
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

        public async Task<ProviderServices> GetById(object id)
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

        public async Task<bool> Update(ProviderServices entity)
        {
            try
            {
                var existingEntity =await _dbSet.FindAsync(entity.id);

                if (existingEntity != null)
                {
                    _dbSet.Update(entity);
                    await _db.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", type);
                throw;
            }
        }
    }
}
