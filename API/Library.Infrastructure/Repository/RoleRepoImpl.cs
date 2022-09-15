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
    public class RoleRepoImpl : IRoleRepo
    {
        private readonly ILogger<RoleRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(RoleRepoImpl);
        private DbSet<Role> _dbSet;
        public RoleRepoImpl(PaymentServicesContext db, ILogger<RoleRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Roles;
        }

        public async Task<bool> Add(Role entity)
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

        public async Task<List<Role>> GetAll()
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

        public async Task<Role> GetById(object id)
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

        public async Task<bool> Update(Role entity)
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
