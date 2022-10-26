using CadastroCliente.Domain.Filters;
using CadastroCliente.Domain.Projections;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Domain.Services.Clientes.Contracts;
using CadastroCliente.Domain.Services.Clientes.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.WebClient.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteApiController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        public ClienteApiController(
            IClienteRepository clienteRepository,
            IClienteService clienteService
        )
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAll([FromQuery] ClienteFilter clienteFilter)
        {
            return Ok(await _clienteRepository.GetAll(clienteFilter));
        }

        [HttpGet("{id:guid}")]
        public async ValueTask<IActionResult> GetByid([FromRoute] Guid id)
        {
            var cliente = await _clienteRepository.GetAsync(x => x.Id == id);

            if (cliente is null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async ValueTask<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            if (clienteDto is null) return UnprocessableEntity();

            return Ok(await _clienteService.CreateAsync(clienteDto));
        }

        [HttpPut("{id:guid}")]
        public async ValueTask<IActionResult> Update([FromRoute] Guid id, [FromBody] EditClienteDto clienteDto)
        {
            if (clienteDto is null) return UnprocessableEntity();

            clienteDto.Id = id;

            return Ok(await _clienteService.EditAsync(clienteDto));
        }

        [HttpDelete("{id:guid}")]
        public async ValueTask<IActionResult> Delete([FromRoute] Guid id)
        {
            var cliente = await _clienteRepository.GetAsync(x => x.Id == id);
            if (cliente is null) return NotFound();

            await _clienteRepository.DeleteAsync(cliente);

            return Ok(cliente.ToVm());
        }
    }
}
