using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class ServicoService : IServicoService
    {
        private readonly IServicoRepository _repoServico;
        
        public ServicoService(IServicoRepository repo)
        {
            _repoServico = repo;            
        }

        public List<Servico> FindAll()
        {
            return _repoServico.FindAll();
        }

        public Servico FindById(int id)
        {
            return _repoServico.FindById(id);
        }

        public Servico Create(Servico servico)
        {
            var servicoExiste = _repoServico.FindByName(servico.Nome);
            if (servicoExiste != null)
                return null;

            return _repoServico.Create(servico);
        }
        
        public Servico Update(Servico novoServico)
        {
            var servico = _repoServico.FindById(novoServico.Id);

            if (servico == null)
                return null;

            return _repoServico.Update(servico, novoServico);
        }

        public bool Delete(int id)
        {
            var servico = _repoServico.FindById(id);

            if (servico == null)
                return false;

            _repoServico.Delete(servico);
            return true;
        }
    }
}
