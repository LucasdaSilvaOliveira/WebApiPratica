using WebApiPratica.Domain.Entities;
using WebApiPratica.Infra.Data;

namespace WebApiPratica.Domain.Repositories.ClienteRepository
{
    public class ClienteRepository : IClienteRepository
    {
        private BancoContext _bancoContext;

        public ClienteRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public bool AdicionarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                _bancoContext.Clientes.Add(cliente);
                _bancoContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AtualizarCliente(Cliente cliente)
        {
            if (cliente != null)
            {
                _bancoContext.Clientes.Update(cliente);
                _bancoContext.SaveChanges();
                return true;
            }
            else
            {
                throw new Exception("Não foi possível atualizar o cliente.");
            }
        }

        public bool DeletarCliente(int id)
        {
            if(id != 0)
            {
                var cliente = _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
                if (cliente != null)
                {
                    _bancoContext.Clientes.Remove(cliente);
                    _bancoContext.SaveChanges();
                    return true;
                }
                else
                {
                    throw new Exception("Não foi possível deletar o cliente.");
                }
            } else
            {
                throw new Exception("Não foi possível fazer a operação.");
            }
        
        }

        public Cliente ObterPorId(int id)
        {
            if (id != 0)
            {
                var cliente = _bancoContext.Clientes.FirstOrDefault(x => x.Id == id);
                if (cliente != null)
                {
                    return cliente;
                }
                else
                {
                    throw new Exception("Cliente não encontrado");
                }
            }
            else
            {
                throw new Exception("Não foi possível fazer a operação.");
            }

        }

        public List<Cliente> ObterTodos()
        {
            return _bancoContext.Clientes.ToList();
        }
    }
}
