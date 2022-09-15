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
    public class PermissionRepoImpl : IPermissionRepo
    {
        private readonly ILogger<PermissionRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(PermissionRepoImpl);
        private DbSet<Permission> _dbSet;
        public PermissionRepoImpl(PaymentServicesContext db, ILogger<PermissionRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Permissions;
        }

        public async Task<List<Permission>> GetAll()
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

        public async Task<Permission> GetById(object id)
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

        public async Task<List<Permission>> GetByParentId(int parent_id)
        {
            try
            {
                return await _dbSet.Where(a=> a.parent_id== parent_id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByParentId method error", type);
                throw;
            }
        }
    }
}
