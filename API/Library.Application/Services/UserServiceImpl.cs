using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UserServiceImpl : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IUserTypeRepo _userTypeRepo;
        public UserServiceImpl(IUserRepo repo, IUserTypeRepo userTypeRepo)
        {
            _repo = repo;
            _userTypeRepo = userTypeRepo;
        }
    }
}
