using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Api.Controllers;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Infra.Data;
using WebApiPratica.Infra.Repositories.PedidoRepository;

namespace WebApiPratica.Testes.Integration
{
    public class PedidoIntegracaoTest
    {
        [Fact()]
        public void TestaIntegracaoDoPedidoRepositorioComPedidoController()
        {
            var options = new DbContextOptionsBuilder<BancoContext>()
                .UseInMemoryDatabase(databaseName: "WebApiPratica").Options;

            using (var context = new BancoContext(options))
            {
                // UMA DAS FORMAS DE ADICIONAR DADOS AO BANCO EM MEMÓRIA
                //context.Pedidos.Add(new Pedido
                //{
                //    Id = 1,
                //    Lanche = "Pizza",
                //    ClienteId = 1,
                //    Cliente = new Cliente
                //    {
                //        Id = 2,
                //        Nome = "Luck",
                //        Endereco = "Rua Oliveira Braga"
                //    }
                //});
                //context.SaveChanges();

                var pedidoRepositorio = new PedidoRepository(context);
                var pedidoController = new PedidoController(pedidoRepositorio);

                // UMA DAS FORMAS DE ADICIONAR DADOS AO BANCO EM MEMÓRIA
                var pedido = new Pedido
                {
                    Id = 1,
                    Lanche = "Pizza",
                    ClienteId = 1,
                    Cliente = new Cliente
                    {
                        Id = 2,
                        Nome = "Luck",
                        Endereco = "Rua Oliveira Braga"
                    }
                };
                pedidoRepositorio.AdicionarPedido(pedido);

                var retornoObterTodos = pedidoController.ObterPorId(1);

                Assert.IsType<OkObjectResult>(retornoObterTodos);
            }
        }
    }
}
