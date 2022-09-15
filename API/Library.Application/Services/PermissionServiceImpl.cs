using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class PermissionServiceImpl : IPermissionService
    {
        private readonly IPermissionRepo _repo;
        public PermissionServiceImpl(IPermissionRepo repo)
        {
            _repo = repo;
        }
    }
}
