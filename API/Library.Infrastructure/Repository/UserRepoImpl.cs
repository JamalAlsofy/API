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
    public class UserRepoImpl: IUserRepo
    {
        private readonly ILogger<UserRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(UserRepoImpl);
        private DbSet<User> _dbSet;
        public UserRepoImpl(PaymentServicesContext db, ILogger<UserRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Users;
        }

        public async Task<bool> Add(User entity)
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
                var existingEntity =await _dbSet.FindAsync(id);

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

        public async Task<List<User>> GetAll()
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

        public async Task<User> GetById(object id)
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

        public async Task<bool> Update(User entity)
        {
            try
            {
                var existingEntity =await _dbSet.Where(x => x.id == entity.id).FirstOrDefaultAsync();

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
