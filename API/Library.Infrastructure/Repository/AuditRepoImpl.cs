using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Library.Domain.Entities;
using Library.Infrastructure.Data;
using Library.Domain.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repository
{
    public class AuditRepoImpl : IAuditRepo
    {
        private readonly ILogger<AuditRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(AuditRepoImpl);
        private DbSet<Audit> _dbSet;
        public AuditRepoImpl(PaymentServicesContext db, ILogger<AuditRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Audits;
        }

        public async Task<List<Audit>> GetAll()
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

        public async Task<Audit> GetById(object id)
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

        public async Task<List<Audit>> GetByUserId(int user_id)
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
