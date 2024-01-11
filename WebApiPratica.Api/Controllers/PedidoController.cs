using Microsoft.AspNetCore.Mvc;
using WebApiPratica.Infra.Repositories.PedidoRepository;

namespace WebApiPratica.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        private IPedidoRepository _pedidoRepository;
        public PedidoController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        [HttpGet]
        [Route("ObterTodos")]
        public IActionResult ObterTodos()
        {
            try
            {
                var pedidos = _pedidoRepository.ObterTodos();
                return Ok(pedidos);
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObterPorId")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var pedido = _pedidoRepository.ObterPorId(id);
                return Ok(pedido);
            } catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
