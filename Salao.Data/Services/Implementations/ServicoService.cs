using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
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
        
        public Servico Update(Servico novoServico)
        {
            var servico = _repo.FindById(novoServico.Id);

            if (servico == null)
                return null;

            return _repo.Update(servico, novoServico);
        }

        public bool Delete(int id)
        {
            var servico = _repo.FindById(id);

            if (servico == null)
                return false;

            _repo.Delete(servico);
            return true;
        }
    }
}
