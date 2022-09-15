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
    public class UserPermissionRepoImpl: IUserPermissionRepo
    {
        private readonly ILogger<UserPermissionRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(UserPermissionRepoImpl);
        private DbSet<UserPermissions> _dbSet;
        public UserPermissionRepoImpl(PaymentServicesContext db, ILogger<UserPermissionRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.PermissionUsers;
        }

        public async Task<bool> AddRange(List<UserPermissions> entities)
        {
            try
            {
                await _dbSet.AddRangeAsync(entities);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", type);
                throw;
            }
        }

        
        public async Task<bool> DeleteRange(List<UserPermissions> entities)
        {
            try
            {
                var existingEntity = _dbSet.Intersect(entities);

                if (existingEntity != null)
                {
                    _dbSet.RemoveRange(existingEntity);
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

        

        public async Task<UserPermissions> GetById(object id)
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

        public async Task<List<UserPermissions>> GetByUserId(int user_id)
        {
            try
            {
                return await _dbSet.Where(a=> a.user_id == user_id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByUserId method error", type);
                throw;
            }
        }

        public async Task<bool> Update(UserPermissions entity)
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
