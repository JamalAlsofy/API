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
    public class TransactionStatusRepoImpl: ITransactionStatusRepo
    {
        private readonly ILogger<TransactionStatusRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(TransactionStatusRepoImpl);
        private DbSet<TransactionStatus> _dbSet;
        public TransactionStatusRepoImpl(PaymentServicesContext db, ILogger<TransactionStatusRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Transactions;
        }

        public async Task<List<TransactionStatus>> GetAll()
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

        public async Task<List<TransactionStatus>> GetByCustomerId(int customer_id)
        {
            try
            {
                return await _dbSet.Where(a => a.customer_id == customer_id).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetByCustomerId method error", type);
                throw;
            }
        }

        public async Task<TransactionStatus> GetById(object id)
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
    }
}
