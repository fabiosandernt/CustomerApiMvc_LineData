
using CadastroCliente.CrossCutting.Exceptions;
using CadastroCliente.Domain.Entities;
using CadastroCliente.Domain.Projections;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Domain.Services.Clientes.Contracts;
using CadastroCliente.Domain.Services.Clientes.Dtos;
using CadastroCliente.Domain.ViewModels;

namespace CadastroCliente.Domain.Services.Clientes
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public async ValueTask<ClienteViewModel> CreateAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente(Guid.NewGuid(), clienteDto.Nome, clienteDto.BirthDate, clienteDto.Cpf, clienteDto.Address, clienteDto.Sexo);

            cliente = await _clienteRepository.CreateAsync(cliente);

            return cliente.ToVm();
        }

        public async ValueTask<ClienteViewModel> EditAsync(EditClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.GetAsync(x => x.Id == clienteDto.Id);
            if (cliente is null) throw new DomainException("cliente não encontrado");

            cliente.Update(clienteDto.Nome, clienteDto.BirthDate, clienteDto.Cpf, clienteDto.Address, clienteDto.Sexo);

            await _clienteRepository.Update(cliente);

            return cliente.ToVm();
        }
    }
}
