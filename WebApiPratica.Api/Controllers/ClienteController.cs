using Microsoft.AspNetCore.Mvc;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Domain.Repositories.ClienteRepository;

namespace WebApiPratica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var clientes = _clienteRepository.ObterTodos();
                return Ok(clientes);
            }
            catch
            {
                return NotFound("Houve um erro na busca dos clientes.");
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var cliente = _clienteRepository.ObterPorId(id);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("AdicionarCliente")]
        public IActionResult AdicionarCliente(Cliente cliente)
        {
            var sucessoAoCadastrar = _clienteRepository.AdicionarCliente(cliente);

            if (sucessoAoCadastrar)
            {
                var clientes = _clienteRepository.ObterTodos();
                return Ok(clientes);
            }
            else
            {
                return BadRequest("Houve um erro na requisição ao adicionar o cliente.");
            }
        }
    }
}
