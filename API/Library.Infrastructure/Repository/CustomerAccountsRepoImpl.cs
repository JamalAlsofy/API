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
    public class CustomerAccountsRepoImpl : ICustomerAccountsRepo
    {
        private readonly ILogger<CustomerAccountsRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(CustomerAccountsRepoImpl);
        private DbSet<CustomerAccounts> _dbSet;
        public CustomerAccountsRepoImpl(PaymentServicesContext db, ILogger<CustomerAccountsRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.CustomerAccounts;
        }

        public async Task<bool> Add(CustomerAccounts entity)
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
                var existingEntity = await _dbSet.Where(x => x.id == id).FirstOrDefaultAsync();

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

        public async Task<List<CustomerAccounts>> GetAll()
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

        public async Task<CustomerAccounts> GetById(object id)
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

        public async Task<bool> Update(CustomerAccounts entity)
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
