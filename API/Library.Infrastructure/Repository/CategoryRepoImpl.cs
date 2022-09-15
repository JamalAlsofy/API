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
    public class CategoryRepoImpl : ICategoryRepo
    {
        private readonly ILogger<CategoryRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(CategoryRepoImpl);
        private DbSet<Category> _dbSet;
        public CategoryRepoImpl(PaymentServicesContext db, ILogger<CategoryRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Categories;
        }

        public async Task<List<Category>> GetAll()
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
        public async Task<Category> GetById(object id)
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
