using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Filters;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace CadastroCliente.Domain.Repositories
{
    public interface IClienteRepository
    {
        ValueTask<Cliente> CreateAsync(Cliente cliente);
        ValueTask Update(Cliente cliente);
        ValueTask DeleteAsync(Cliente cliente);
        ValueTask<Cliente> GetAsync(Expression<Func<Cliente, bool>> expression);
        ValueTask<IEnumerable<Cliente>> GetAll(ClienteFilter filter);
    }
}
