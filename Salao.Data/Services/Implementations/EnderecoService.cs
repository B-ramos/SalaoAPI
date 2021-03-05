using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
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

        public Endereco FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Endereco Create(Endereco endereco)
        {
            return _repo.Create(endereco);
        }
        
        public Endereco Update(Endereco novoEndereco)
        {
            var endereco = _repo.FindById(novoEndereco.Id);

            if (endereco == null)
                return null;

            return _repo.Update(endereco, novoEndereco);
        }

        public bool Delete(int id)
        {
            var endereco = _repo.FindById(id);

            if (endereco == null)
                return false;

            _repo.Delete(endereco);
            return true;
        }
    }
}
