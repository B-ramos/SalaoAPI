using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repo;
        
        public EnderecoService(IEnderecoRepository repo)
        {
            _repo = repo;            
        }

        public List<Endereco> FindAll()
        {
            return _repo.FindAll();
        }

        public Endereco FindbyId(int id)
        {
            return _repo.FindById(id);
        }

        public Endereco Create(Endereco endereco)
        {
            return _repo.Create(endereco);
        }
        
        public Endereco Update(Endereco endereco)
        {
            return _repo.Update(endereco);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
