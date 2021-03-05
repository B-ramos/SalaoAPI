using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _repo;
        
        public ClienteService(IClienteRepository repo)
        {
            _repo = repo;            
        }

        public List<Cliente> FindAll()
        {
            return _repo.FindAll();
        }

        public Cliente FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Cliente Create(Cliente cliente)
        {            
            return _repo.Create(cliente);
        }
        
        public Cliente Update(Cliente novoCliente)
        {
            var cliente = _repo.FindById(novoCliente.Id);

            if (cliente == null)
                return null;

            return _repo.Update(cliente, novoCliente);
        }

        public bool Delete(int id)
        {
            var cliente = _repo.FindById(id);

            if (cliente == null)
                return false;

            _repo.Delete(cliente);
            return true;
        }
    }
}
