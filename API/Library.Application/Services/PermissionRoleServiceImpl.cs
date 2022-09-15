using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class PermissionRoleServiceImpl: IPermissionRoleService
    {
        private readonly IPermissionRoleRepo _repo;
        private readonly IRoleRepo _roleRepo;
        private readonly IPermissionRepo _permissionRepo;
        public PermissionRoleServiceImpl(IPermissionRoleRepo repo, IRoleRepo roleRepo, IPermissionRepo permissionRepo)
        {
            _repo = repo;
            _roleRepo = roleRepo;
            _permissionRepo = permissionRepo;
        }
    }
}
