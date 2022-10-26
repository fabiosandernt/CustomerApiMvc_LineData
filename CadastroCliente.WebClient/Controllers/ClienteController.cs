using CadastroCliente.Domain.Filters;
using CadastroCliente.Domain.Projections;
using CadastroCliente.Domain.Repositories;
using CadastroCliente.Domain.Services.Clientes.Contracts;
using CadastroCliente.Domain.Services.Clientes.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroCliente.WebClient.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        public ClienteController(
            IClienteRepository clienteRepository,
            IClienteService clienteService
        )
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        // GET: ClienteController1
        public async Task<ActionResult> Index(ClienteFilter clienteFilter)
        {
            return View((await _clienteRepository.GetAll(clienteFilter)).ToVm());
        }

        // GET: ClienteController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ClienteDto dto)
        {
            try
            {
                await _clienteService.CreateAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController1/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var cliente = await _clienteRepository.GetAsync(x => x.Id == id);
            return View(new EditClienteDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf.Number,
                BirthDate = cliente.BirthDate,
                Sexo = cliente.Sexo,
                Address = cliente.Address
            });
        }

        // POST: ClienteController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, EditClienteDto dto)
        {
            try
            {
                dto.Id = id;
                await _clienteService.EditAsync(dto);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: ClienteController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _clienteRepository.DeleteAsync(await _clienteRepository.GetAsync(x => x.Id == id));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
