using Library.Application.Utils;
using Library.Domain.DTOs;
using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class ServicesServiceImpl : IServicesService
    {
        private readonly IServiceRepo _repo;
        private readonly IOperationsAPIRepo _operationRepo;
        private readonly ICategoryRepo _categoryRepo;
        public ServicesServiceImpl(IServiceRepo repo, IOperationsAPIRepo operationRepo, ICategoryRepo categoryRepo)
        {
            _repo = repo;
            _operationRepo = operationRepo;
            _categoryRepo = categoryRepo;
        }

        public async Task<ServicesResultsDto> Add(Service entity)
        {
            try
            {
                var existingOperApi = await _operationRepo.GetById(entity.operApi_id);
                if (existingOperApi == null)
                {
                    return ServicesResultsDRY.GetError(ResultsTypes.Reference_Not_Found, "نوع عملية");
                }

                var existingCategory = await _categoryRepo.GetById(entity.catg_id);
                if (existingCategory == null)
                {
                    return ServicesResultsDRY.GetError(ResultsTypes.Reference_Not_Found, "تصنيف");
                }

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

        public async Task<Service> Details(int id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception)
            {
                return new Service();
            }
        }

        public async Task<ServicesResultsDto> Edit(Service entity)
        {
            try
            {
                var existingEntity = await _repo.GetById(entity.id);

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

        public async Task<List<Service>> GetAll()
        {
            try
            {
                var items = await _repo.GetAll();
                return items;
            }
            catch (Exception)
            {
                return new List<Service>();
            }
        }
    }
}
