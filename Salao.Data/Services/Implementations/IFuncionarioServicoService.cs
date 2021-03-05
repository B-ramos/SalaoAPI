using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class FuncionarioServicoService : IFuncionarioServicoService
    {
        private readonly IFuncionarioServicoRepository _repo;
        
        public FuncionarioServicoService(IFuncionarioServicoRepository repo)
        {
            _repo = repo;            
        }

        public List<FuncionarioServico> FindAll()
        {
            return _repo.FindAll();
        }

        public FuncionarioServico FindById(int id)
        {
            return _repo.FindById(id);
        }

        public FuncionarioServico Create(FuncionarioServico funcionarioServico)
        {
            return _repo.Create(funcionarioServico);
        }
        
        public FuncionarioServico Update(FuncionarioServico novoFuncionarioServico)
        {
            var funcionarioServico = _repo.FindById(novoFuncionarioServico.Id);

            if (funcionarioServico == null)
                return null;

            return _repo.Update(funcionarioServico, novoFuncionarioServico);
        }

        public bool Delete(int id)
        {
            var funcionarioServico = _repo.FindById(id);

            if (funcionarioServico == null)
                return false;

            _repo.Delete(funcionarioServico);
            return true;
        }
    }
}
