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
    public class PaymentTypeRepoImpl : IPaymentTypeRepo
    {
        private readonly ILogger<PaymentTypeRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(PaymentTypeRepoImpl);
        private DbSet<PaymentType> _dbSet;
        public PaymentTypeRepoImpl(PaymentServicesContext db, ILogger<PaymentTypeRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.PaymentTypes;
        }
        public async Task<List<PaymentType>> GetAll()
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
    }
}
