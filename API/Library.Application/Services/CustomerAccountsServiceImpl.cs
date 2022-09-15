using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class CustomerAccountsServiceImpl: ICustomerAccountsService
    {
        private readonly ICustomerAccountsRepo _repo;
        private readonly IUserRepo _userRepo;
        public CustomerAccountsServiceImpl(ICustomerAccountsRepo repo, IUserRepo userRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
        }
    }
}
