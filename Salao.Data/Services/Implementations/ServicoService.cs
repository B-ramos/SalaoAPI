using Salao.Data.Repository.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repo;
        
        public ServicoService(IServicoRepository repo)
        {
            _repo = repo;            
        }

        public List<Servico> FindAll()
        {
            return _repo.FindAll();
        }

        public Servico FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Servico Create(Servico servico)
        {
            return _repo.Create(servico);
        }
        
        public Servico Update(Servico servico)
        {
            return _repo.Update(servico);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
