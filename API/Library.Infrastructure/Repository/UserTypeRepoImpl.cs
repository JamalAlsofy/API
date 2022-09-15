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
    public class UserTypeRepoImpl : IUserTypeRepo
    {
        private readonly ILogger<UserTypeRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(UserTypeRepoImpl);
        private DbSet<UserType> _dbSet;
        public UserTypeRepoImpl(PaymentServicesContext db, ILogger<UserTypeRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.UserTypes;
        }
        public async Task<List<UserType>> GetAll()
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
