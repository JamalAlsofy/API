using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class RoleServiceImpl : IRoleService
    {
        private readonly IRoleRepo _repo;
        public RoleServiceImpl(IRoleRepo repo)
        {
            _repo = repo;
        }
    }
}
