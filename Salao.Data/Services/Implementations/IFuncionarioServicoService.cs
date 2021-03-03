using Salao.Data.Repository.Interface;
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

        public FuncionarioServico FindbyId(int id)
        {
            return _repo.FindById(id);
        }

        public FuncionarioServico Create(FuncionarioServico funcionarioServico)
        {
            return _repo.Create(funcionarioServico);
        }
        
        public FuncionarioServico Update(FuncionarioServico funcionarioServico)
        {
            return _repo.Update(funcionarioServico);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}
