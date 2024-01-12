using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Api.Controllers;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Infra.Repositories.PedidoRepository;

namespace WebApiPratica.Testes.Unit.Controllers
{
    public class PedidoControllerTest
    {
        private Mock<IPedidoRepository> _pedidoRepository;
        private PedidoController _pedidoController;
        public PedidoControllerTest()
        {
            _pedidoRepository = new Mock<IPedidoRepository>();
            _pedidoController = new PedidoController(_pedidoRepository.Object);
        }

        [Fact(DisplayName = "Obter todos os pedidos deve retornar status Ok")]
        public void ObterTodosOsPedidosDeveRetornarOk()
        {

            _pedidoRepository.Setup(x => x.ObterTodos()).Returns(It.IsAny<List<Pedido>>);

            var retornoObterPedidos = _pedidoController.ObterTodos();

            Assert.IsType<OkObjectResult>(retornoObterPedidos);
        }

        [Fact(DisplayName = "Obter pedido por id deve retornar status Ok")]
        public void ObterPedidoPorIdDeveRetornarOk()
        {
            _pedidoRepository.Setup(x => x.ObterPorId(It.IsAny<int>())).Returns(new Pedido());

            var retornoObterPorId = _pedidoController.ObterPorId(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(retornoObterPorId);
        }

        [Fact(DisplayName = "Obter pedido por id deve retornar uma Exception")]
        public void ObterPedidoPorIdDeveRetornarException()
        {
            _pedidoRepository.Setup(x => x.ObterPorId(It.IsAny<int>())).Throws(new Exception());

            var retornoObterPorId = _pedidoController.ObterPorId(It.IsAny<int>());

            Assert.IsType<NotFoundObjectResult>(retornoObterPorId);
        }
    }
}
