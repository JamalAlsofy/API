using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class UserTypeRoleServiceImpl : IUserTypeRoleService
    {
        private readonly IUserTypeRoleRepo _repo;
        private readonly IRoleRepo _roleRepo;
        public UserTypeRoleServiceImpl(IUserTypeRoleRepo repo, IRoleRepo roleRepo)
        {
            _repo = repo;
            _roleRepo = roleRepo;
        }
    }
}
