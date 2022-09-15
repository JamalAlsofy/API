using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Interfaces.IRepository.IBaseRepository
{
    public interface IBaseAddRepo<T> where T: class,new()
    {
        Task<bool> Add(T entity);
    }
}
