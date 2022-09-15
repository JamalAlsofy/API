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
    public class LogsPermissionRepoImpl: ILogsPermissionRepo
    {
        private readonly ILogger<LogsPermissionRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(LogsPermissionRepoImpl);
        private DbSet<LogsPermission> _dbSet;
        public LogsPermissionRepoImpl(PaymentServicesContext db, ILogger<LogsPermissionRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.LogsPermissions;
        }

        public async Task<bool> Add(LogsPermission entity)
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

        public async Task<List<LogsPermission>> GetAll()
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

        public async Task<LogsPermission> GetById(object id)
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

        public async Task<List<LogsPermission>> GetByPermissionId(int permission_id)
        {
            try
            {
                return await _dbSet.Where(a => a.permission_id == permission_id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByPermissionId method error", type);
                throw;
            }
        }

        public async Task<List<LogsPermission>> GetByUserId(int user_id)
        {
            try
            {
                return await _dbSet.Where(a => a.user_id == user_id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByUserId method error", type);
                throw;
            }
        }
    }
}
