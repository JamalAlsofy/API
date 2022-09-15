using Library.Domain.Interfaces.IRepository;
using Library.Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class AuditServiceImpl : IAuditService
    {
        private readonly IAuditRepo _repo;
        private readonly IOperationsAPIRepo _operationsAPIRepo;
        private readonly IUserRepo _userRepo;
        public AuditServiceImpl(IAuditRepo repo, IOperationsAPIRepo operatsAPIRepo, IUserRepo userRepo)
        {
            _repo = repo;
            _operationsAPIRepo = operatsAPIRepo;
            _userRepo = userRepo;
        }
    }
}
