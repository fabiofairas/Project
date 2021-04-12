using Project.Model.Entities;
using Project.Model.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context) { }

        public async Task Create(Cliente entity)
        {
            await CreateAsync(entity);
        }

        public async Task Delete(Cliente entity)
        {
            await RemoveAsync(entity);
        }

        public async Task Update(Cliente entity)
        {
            await UpdateAsync(entity);
        }

        public async Task<Cliente> Get(Guid id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cliente>> List()
        {
            return await GetAllAsync();
        }
    }
}