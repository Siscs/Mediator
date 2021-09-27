using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Siscs.Mediator.Api.Domain.Repositories
{
    public interface IRepository<T> where T : class
    {
         
        Task<IEnumerable<T>> GetAll();

        Task<T> Get(Guid id);

        Task Add(T entity);

        Task Edit(T entity);

        Task Delete(Guid id);
    }
}