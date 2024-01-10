using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Api.Controllers;
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

            var clienteController = new ClienteController(mockClienteRepositorio.Object);

            var retornoGet = clienteController.ObterTodos();

            Assert.IsType<OkObjectResult>(retornoGet);
        }

        [Fact(DisplayName = "Teste de obter clientes através do id com retorno Ok")]
        public void ObterClientePorIdDeveRetornarOk()
        {
            var mockClienteRepositorio = new Mock<IClienteRepository>();

        [Fact(DisplayName = "Teste de obter cliente através do id deve retornar status BadRequest")]
        public void ObterClientePorIdDeveRetornarBadRequest()
        {
            _clienteRepositoryMock.Setup(x => x.ObterPorId(It.IsAny<int>())).Throws(new Exception());

            var clienteController = new ClienteController(_clienteRepositoryMock.Object);

            var retornoObterPorId = clienteController.ObterPorId(It.IsAny<int>());

            Assert.IsType<BadRequestObjectResult>(retornoObterPorId);

        }
    }
}
