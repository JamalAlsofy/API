using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class ProviderServicesServiceImpl : IProviderServicesService
    {
        private readonly IProviderServicesRepo _repo;
        private readonly IProviderRepo _providerRepo;
        private readonly IServiceRepo _serviceRepo;
        private readonly ICompanyRepo _companyRepo;
        public ProviderServicesServiceImpl(IProviderServicesRepo repo, IProviderRepo providerRepo
            , IServiceRepo serviceRepo, ICompanyRepo companyRepo)
        {
            _repo = repo;
            _providerRepo = providerRepo;
            _serviceRepo = serviceRepo;
            _companyRepo = companyRepo;
        }

    }
}
