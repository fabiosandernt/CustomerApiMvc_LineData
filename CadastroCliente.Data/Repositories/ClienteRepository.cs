using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Filters;
using CadastroCliente.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace CadastroCliente.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DataContext _dbContext;
        public ClienteRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async ValueTask<Cliente> CreateAsync(Cliente cliente)
        {
            await _dbContext.Set<Cliente>().AddAsync(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async ValueTask DeleteAsync(Cliente cliente)
        {
            _dbContext.Set<Cliente>().Remove(cliente);
            await _dbContext.SaveChangesAsync();
        }

        public async ValueTask<IEnumerable<Cliente>> GetAll(ClienteFilter filter)
        {
            var query = _dbContext.Set<Cliente>().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(filter.Nome))
                query = query.Where(x => x.Nome.ToLower().Contains(filter.Nome.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.Cpf))
                query = query.Where(x => x.Cpf.Number == Regex.Replace(filter.Cpf, "[^0-9]", ""));

            if (filter.BirthDate.HasValue)
                query = query.Where(x => x.BirthDate == filter.BirthDate.Value);

            if (filter.Sexo.HasValue)
                query = query.Where(x => x.Sexo == filter.Sexo.Value);

            if (!string.IsNullOrWhiteSpace(filter.City))
                query = query.Where(x => x.Address.City.ToLower().Contains(filter.City.ToLower()));

            if (!string.IsNullOrWhiteSpace(filter.State))
                query = query.Where(x => x.Address.State.ToLower().Contains(filter.State.ToLower()));

            return await query.ToListAsync();
        }

        public async ValueTask<Cliente> GetAsync(Expression<Func<Cliente, bool>> expression)
        {
            return await _dbContext.Set<Cliente>().AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async ValueTask Update(Cliente cliente)
        {
            _dbContext.Set<Cliente>().Update(cliente);
            await _dbContext.SaveChangesAsync();
        }
    }
}
