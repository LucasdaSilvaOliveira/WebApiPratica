using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Domain.Entities;

namespace WebApiPratica.Infra.Repositories.PedidoRepository
{
    public interface IPedidoRepository
    {
        List<Pedido> ObterTodos();

        Pedido ObterPorId(int id);

        bool AtualizarPedido(Pedido pedido);

        bool DeletarPedido(int id);

        bool AdicionarPedido(Pedido pedido);
    }
}
