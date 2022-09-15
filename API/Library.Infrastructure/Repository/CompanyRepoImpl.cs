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
    public class CompanyRepoImpl : ICompanyRepo
    {
        private readonly ILogger<CompanyRepoImpl> _logger;
        private readonly PaymentServicesContext _db;
        private Type type = typeof(CompanyRepoImpl);
        private DbSet<Company> _dbSet;
        public CompanyRepoImpl(PaymentServicesContext db, ILogger<CompanyRepoImpl> logger)
        {
            _db = db;
            _logger = logger;
            _dbSet = _db.Companies;
        }

        public async Task<bool> Add(Company entity)
        {
            try
            {
                //object id1 = _db.Roles.Max(a => a.id);
                //int id = await _dbSet.MaxAsync(a => a.id)+1;
                //entity.id = id;
                await _dbSet.AddAsync(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Add method error", type);
                throw; //return false;
            }
        }

        public async Task<bool> Delete(Company entity)
        {
            try
            {
                _dbSet.Remove(entity);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", type);
                throw; //return false;
            }
        }

        public async Task<List<Company>> GetAll()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", type);
                throw; //return new List<Company>();
            }
        }

        public async Task<Company> GetById(object id)
        {
            try
            {
                //var existingEntity = _dbSet.Find(entity.id);
                //var existingEntity = await _dbSet.Where(x => x.id == (int)id).FirstOrDefaultAsync();
                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", type);
                throw; //return new Company();
            }
        }

        public async Task<bool> Update(Company entity)
        {
            try
            {  
                 //var existingEntity = await _dbSet.AsNoTracking().Where(x => x.id==entity.id).FirstOrDefaultAsync();

                //_db.Entry(entity).State = EntityState.Detached;
                _dbSet.Update(entity);
                //_db.Entry(entity).State = EntityState.Modified;
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", type);
                throw; //return false;
            }
        }

    }
}
