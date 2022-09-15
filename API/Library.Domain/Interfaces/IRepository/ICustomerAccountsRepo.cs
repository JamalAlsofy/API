using Library.Domain.Entities;
using Library.Domain.Interfaces.IRepository.IBaseRepository;

namespace Library.Domain.Interfaces.IRepository
{
    public interface ICustomerAccountsRepo : IBaseGetAllRepo<CustomerAccounts>, IBaseGetByIdRepo<CustomerAccounts>, IBaseAddRepo<CustomerAccounts>
        , IBaseUpdateRepo<CustomerAccounts>, IBaseDeleteRepo<int>
    {
    }
}
