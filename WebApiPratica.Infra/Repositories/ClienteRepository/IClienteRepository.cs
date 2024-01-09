using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiPratica.Domain.Entities;

namespace WebApiPratica.Domain.Repositories.ClienteRepository
{
    public interface IClienteRepository
    {
        List<Cliente> ObterTodos();

        Cliente ObterPorId(int id);

        bool AtualizarCliente(Cliente cliente);

        bool DeletarCliente(int id);

        bool AdicionarCliente(Cliente cliente);
    }
}
