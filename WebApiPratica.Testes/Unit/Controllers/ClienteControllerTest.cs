using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Api.Controllers;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Domain.Repositories.ClienteRepository;

namespace WebApiPratica.Testes.Unit.Controllers
{
    public class ClienteControllerTest
    {
        private Mock<IClienteRepository> _clienteRepositoryMock;
        public ClienteControllerTest()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
        }

        [Fact(DisplayName = "Teste de obter todos os clientes com retorno de status Ok")]
        public void ObterTodosOsClientesDeveRetornarOk()
        {
            _clienteRepositoryMock.Setup(x => x.ObterTodos()).Returns(new List<Cliente>());

            var clienteController = new ClienteController(_clienteRepositoryMock.Object);

            var retornoGet = clienteController.ObterTodos();

            Assert.IsType<OkObjectResult>(retornoGet);
        }

        [Fact(DisplayName = "Teste de obter cliente através do id deve retornar status Ok")]
        public void ObterClientePorIdDeveRetornarOk()
        {
            _clienteRepositoryMock.Setup(x => x.ObterPorId(It.IsAny<int>())).Returns(new Cliente());

            var clienteController = new ClienteController(_clienteRepositoryMock.Object);

            var retornoObterPorId = clienteController.ObterPorId(It.IsAny<int>());

            Assert.IsType<OkObjectResult>(retornoObterPorId);
        }

        [Fact(DisplayName = "Teste de obter cliente através do id deve retornar status BadRequest")]
        public void ObterClientePorIdDeveRetornarBadRequest()
        {
            _clienteRepositoryMock.Setup(x => x.ObterPorId(It.IsAny<int>())).Throws(new Exception());

            var clienteController = new ClienteController(_clienteRepositoryMock.Object);

            var retornoObterPorId = clienteController.ObterPorId(It.IsAny<int>());

            Assert.IsType<BadRequestObjectResult>(retornoObterPorId);

        }

        [Fact(DisplayName = "Teste de adicionar cliente deve retornar status Ok")]
        public void AdicionarClienteDeveRetornarOk()
        {
            _clienteRepositoryMock.Setup(x => x.AdicionarCliente(It.IsAny<Cliente>())).Returns(true);

            var controller = new ClienteController(_clienteRepositoryMock.Object);

            var retornoAdicionarCliente = controller.AdicionarCliente(It.IsAny<Cliente>());

            Assert.IsType<OkObjectResult>(retornoAdicionarCliente);
        }

        [Fact(DisplayName = "Teste de adicionar cliente deve retornar status Bad Request")]
        public void AdicionarClienteDeveRetornarBadRequest()
        {
            _clienteRepositoryMock.Setup(x => x.AdicionarCliente(It.IsAny<Cliente>())).Returns(false);

            var controller = new ClienteController(_clienteRepositoryMock.Object);

            var retornoAdicionarCliente = controller.AdicionarCliente(It.IsAny<Cliente>());

            Assert.IsType<BadRequestObjectResult>(retornoAdicionarCliente);
        }
    }
}
