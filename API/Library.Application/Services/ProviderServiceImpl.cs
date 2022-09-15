using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Domain.DTOs;
using Library.Application.Utils;

namespace Library.Application.Services
{
    public class ProviderServiceImpl : IProviderService
    {
        private readonly IProviderRepo _repo;
        public ProviderServiceImpl(IProviderRepo repo)
        {
            _repo = repo;
        }

        public async Task<ServicesResultsDto> Add(Provider entity)
        {
            try
            {
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

        public async Task<Provider> Details(int id)
        {
            try
            {
                return await _repo.GetById(id);
            }
            catch (Exception)
            {
                return new Provider();
            }
        }

        public async Task<ServicesResultsDto> Edit(Provider entity)
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

        public async Task<List<Provider>> GetAll()
        {
            try
            {
                var items= await _repo.GetAll();
                return items;
            }
            catch (Exception)
            {
                return new List<Provider>();
            }
        }

    }
}
