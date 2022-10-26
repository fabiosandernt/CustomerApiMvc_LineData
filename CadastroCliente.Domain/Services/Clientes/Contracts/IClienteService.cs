using CadastroCliente.Domain.Services.Clientes.Dtos;
using CadastroCliente.Domain.ViewModels;

namespace CadastroCliente.Domain.Services.Clientes.Contracts
{
    public interface IClienteService
    {
        ValueTask<ClienteViewModel> CreateAsync(ClienteDto clienteDto);
        ValueTask<ClienteViewModel> EditAsync(EditClienteDto clienteDto);
    }
}
