using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Api.Controllers;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Domain.Repositories.ClienteRepository;
using WebApiPratica.Infra.Data;

namespace WebApiPratica.Testes.Integration
{
    public class ClienteIntegracaoTest
    {
        private DbContextOptions<BancoContext> _options;

        public ClienteIntegracaoTest()
        {
            _options = new DbContextOptionsBuilder<BancoContext>().UseInMemoryDatabase(databaseName: "WebApiPratica").Options;
        }

        [Fact(DisplayName = "Teste de integração do ClienteController com o ClienteRepository")]
        public void IntegracaoClienteControllerComRepositorio()
        {
            using (var context = new BancoContext(_options))
            {
                context.Clientes.Add(new Cliente
                {
                    Id = 1,
                    Nome = "Luck Silva",
                    Endereco = "Rua Oliveira Braga"
                });
                context.SaveChanges();

                var clienteRepositorio = new ClienteRepository(context);
                var clienteController = new ClienteController(clienteRepositorio);

                var clientes = clienteRepositorio.ObterTodos();
                var retornoActionResultClientes = clienteController.ObterTodos();

                Assert.Equal(1, clientes.Count);
                Assert.IsType<OkObjectResult>(retornoActionResultClientes);
            }
        }
    }
}
