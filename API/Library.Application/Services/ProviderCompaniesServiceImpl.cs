using Library.Application.Utils;
using Library.Domain.DTOs;
using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class ProviderCompaniesServiceImpl : IProviderCompaniesService
    {
        private readonly IProviderCompaniesRepo _repo;
        private readonly IProviderRepo _providerRepo;
        private readonly ICompanyRepo _companyRepo;
        private readonly PaymentServicesContext _db;
        public ProviderCompaniesServiceImpl(IProviderCompaniesRepo repo, IProviderRepo providerRepo, ICompanyRepo companyRepo, PaymentServicesContext db)
        {
            _repo = repo;
            _providerRepo = providerRepo;
            _companyRepo = companyRepo;
            _db = db;
        }       

        public async Task<ServicesResultsDto> Add(ProviderCompany entity)
        {
            try
            {
                var result =  await Validation(entity);
                if (!result.Success) 
                    return result;

                var isDone = await _repo.Add(entity);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }
        private async Task<ServicesResultsDto> Validation(ProviderCompany entity)
        {
            var existingProvider = await _providerRepo.GetById(entity.provider_id);
            if (existingProvider == null)
            {
                return ServicesResultsDRY.GetError(ResultsTypes.Reference_Not_Found, "مزود");
            }

            var existingCompany = await _companyRepo.GetById(entity.mainCom_id);
            if (existingCompany == null)
            {
                return ServicesResultsDRY.GetError(ResultsTypes.Reference_Not_Found, "شركة");
            }

            var existingEntity = await _repo.GetByCompIdAndProviderId(entity.mainCom_id, entity.provider_id);
            if (existingEntity != null)
            {
                return ServicesResultsDRY.GetError(ResultsTypes.Duplicate, "شركة مزود");
            }
            return ServicesResultsDRY.GetSuccess();
        }

        public async Task<ServicesResultsDto> Delete(int id)
        {
            try
            {
                var existingEntity = await _repo.GetById(id);
                if (existingEntity == null)
                {
                    return ServicesResultsDRY.GetError(ResultsTypes.Record_Not_Found);
                }
                var isDone = await _repo.Delete(existingEntity);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public async Task<ProviderCompany> Details(int id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception)
            {
                return new ProviderCompany();
            }
        }

        public async Task<ServicesResultsDto> Edit(ProviderCompany entity)
        {
            try
            {
                var existingEntity = await _db.ProviderCompanies.Where(x => x.id == entity.id && x.provider_id==entity.provider_id && x.mainCom_id == entity.mainCom_id).FirstOrDefaultAsync();
                //var existingEntity = await _db.ProviderCompanies.Where(x => x.id == entity.id).FirstOrDefaultAsync();
                //var existingEntity = await _repo.GetById(entity.id);
                if (existingEntity == null)
                {
                    return ServicesResultsDRY.GetError(ResultsTypes.Record_Not_Found);
                }
                var isDone = await _repo.Update(entity);
                if (isDone)
                    return ServicesResultsDRY.GetSuccess();
                else return ServicesResultsDRY.GetError(ResultsTypes.None);
            }
            catch (Exception)
            {
                return ServicesResultsDRY.GetException();
            }
        }

        public async Task<List<ProviderCompany>> GetAll()
        {
            try
            {
                var items = await _repo.GetAll();
                return items;
            }
            catch (Exception)
            {
                throw;
                //return new List<ProviderCompany>();
            }
        }

        
    }
}
