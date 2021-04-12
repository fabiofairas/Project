using Project.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Model.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task Create(Cliente entity);
        Task Delete(Cliente entity);
        Task Update(Cliente entity);
        Task<Cliente> Get(Guid id);
        Task<IEnumerable<Cliente>> List();
    }
}