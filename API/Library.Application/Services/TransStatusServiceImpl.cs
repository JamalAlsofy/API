using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class TransStatusServiceImpl : ITransStatusService
    {
        private readonly ITransactionStatusRepo _repo;
        private readonly IPaymentTypeRepo _paymentTypeRepo;
        private readonly IServiceRepo _serviceRepo;
        private readonly ICustomerAccountsRepo _customerAccRepo;
        private readonly IProviderRepo _providerRepo;
        public TransStatusServiceImpl(ITransactionStatusRepo repo, IPaymentTypeRepo paymentTypeRepo, IServiceRepo serviceRepo
            , ICustomerAccountsRepo customerAccRepo, IProviderRepo providerRepo)
        {
            _repo = repo;
            _paymentTypeRepo = paymentTypeRepo;
            _serviceRepo = serviceRepo;
            _customerAccRepo = customerAccRepo;
            _providerRepo = providerRepo;
        }
    }
}
