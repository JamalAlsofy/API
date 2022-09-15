using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class ClientUserPermissionServiceImpl : IClientUserPermissionService
    {
        private readonly IUserPermissionRepo _repo;
        private readonly IUserRepo _userRepo;
        private readonly IPermissionRepo _permissionRepo;
        public ClientUserPermissionServiceImpl(IUserPermissionRepo repo, IUserRepo userRepo, IPermissionRepo permissionRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _permissionRepo = permissionRepo;
        }
    }
}
