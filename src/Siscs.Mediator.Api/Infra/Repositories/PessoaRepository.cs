using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Siscs.Mediator.Api.Domain.Entities;
using Siscs.Mediator.Api.Domain.Repositories;

namespace Siscs.Mediator.Api.Infra.Repositories
{
    public class PessoaRepository : IRepository<Pessoa>
    {
        private static readonly Dictionary<Guid, Pessoa> _pessoas = new Dictionary<Guid, Pessoa>();

        public PessoaRepository()
        {
        }

        public async Task<IEnumerable<Pessoa>> GetAll()
        {
            return await Task.Run(() => _pessoas.Values.ToList());
        }

        public async Task<Pessoa> Get(Guid id)
        {
            return await Task.Run(() => _pessoas.GetValueOrDefault(id));
        }
       
        public async Task Add(Pessoa entity)
        {
            await Task.Run(() => _pessoas.Add(entity.Id, entity));
        }

        public async Task Edit(Pessoa entity)
        {
            await Task.Run(async () => {
                await Delete(entity.Id);
                _pessoas.Add(entity.Id, entity);
            });
        }

        public async Task Delete(Guid id)
        {
            await Task.Run(() => _pessoas.Remove(id));
        }

    }
}