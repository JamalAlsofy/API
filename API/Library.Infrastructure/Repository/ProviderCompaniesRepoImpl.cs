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
    public class ProviderCompaniesRepoImpl : IProviderCompaniesRepo
    {
        private readonly ILogger<ProviderCompaniesRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(ProviderCompaniesRepoImpl);
        private DbSet<ProviderCompany> _dbSet;
        public ProviderCompaniesRepoImpl(PaymentServicesContext db, ILogger<ProviderCompaniesRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.ProviderCompanies;
        }

        public async Task<bool> Add(ProviderCompany entity)
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

        public async Task<bool> Delete(ProviderCompany entity)
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

        public async Task<ProviderCompany> GetByCompIdAndProviderId(int mainCom_id, int provider_id)
        {
            try
            {
                return await _dbSet.Where(a => a.mainCom_id == mainCom_id && a.provider_id == provider_id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", type);
                throw;
            }
        }

        public async Task<List<ProviderCompany>> GetAll()
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

        public async Task<ProviderCompany> GetById(object id)
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

        public async Task<bool> Update(ProviderCompany entity)
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
