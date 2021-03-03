using Salao.Data.Repository.Interface;
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

        public Cliente FindbyId(int id)
        {
            return _repo.FindById(id);
        }

        public Cliente Create(Cliente cliente)
        {
            return _repo.Create(cliente);
        }
        
        public Cliente Update(Cliente cliente)
        {
            return _repo.Update(cliente);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
