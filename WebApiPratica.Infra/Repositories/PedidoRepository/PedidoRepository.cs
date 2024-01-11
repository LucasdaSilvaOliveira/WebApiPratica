using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Domain.Entities;
using WebApiPratica.Infra.Data;

namespace WebApiPratica.Infra.Repositories.PedidoRepository
{
    public class PedidoRepository : IPedidoRepository
    {
        private BancoContext _bancoContext;
        public PedidoRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public bool AdicionarPedido(Pedido pedido)
        {
            if(pedido != null)
            {
                _bancoContext.Pedidos.Add(pedido);
                _bancoContext.SaveChanges();
                return true;
            } else
            {
                throw new Exception("Não foi possível adicionar o pedido.");
            }
        }

        public bool AtualizarPedido(Pedido pedido)
        {
            if(pedido != null)
            {
                _bancoContext.Pedidos.Update(pedido);
                _bancoContext.SaveChanges();
                return true;
            } else
            {
                throw new Exception("Não foi possível atualizar o pedido.");
            }
        }

        public bool DeletarPedido(int id)
        {
            var pedido = _bancoContext.Pedidos.FirstOrDefault(x => x.Id == id);

            if (pedido != null)
            {
                _bancoContext.Pedidos.Remove(pedido);
                _bancoContext.SaveChanges();
                return true;
            } else
            {
                throw new Exception("Pedido não encontrado.");
            }
        }

        public Pedido ObterPorId(int id)
        {
            var pedido = _bancoContext.Pedidos.FirstOrDefault(x => x.Id == id);

            if (pedido != null)
            {
                return pedido;
            } else
            {
                throw new Exception("Pedido não encontrado.");
            }
        }

        public List<Pedido> ObterTodos()
        {
            return _bancoContext.Pedidos.ToList();
        }
    }
}
