using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class LogsPermissionServiceImpl : ILogsPermissionService
    {
        private readonly ILogsPermissionRepo _repo;
        private readonly IUserRepo _userRepo;
        private readonly IPermissionRepo _permissionRepo;
        public LogsPermissionServiceImpl(ILogsPermissionRepo repo, IUserRepo userRepo, IPermissionRepo permissionRepo)
        {
            _repo = repo;
            _userRepo = userRepo;
            _permissionRepo = permissionRepo;
        }
    }
}
