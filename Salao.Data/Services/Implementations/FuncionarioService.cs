using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repo;
        
        public FuncionarioService(IFuncionarioRepository repo)
        {
            _repo = repo;            
        }

        public List<Funcionario> FindAll()
        {
            return _repo.FindAll();
        }

        public Funcionario FindById(int id)
        {
            return _repo.FindById(id);
        }

        public Funcionario Create(Funcionario funcionario)
        {
            return _repo.Create(funcionario);
        }
        
        public Funcionario Update(Funcionario novoFuncionario)
        {
            var funcionario = _repo.FindById(novoFuncionario.Id);

            if (funcionario == null)
                return null;

            return _repo.Update(funcionario, novoFuncionario);
        }

        public bool Delete(int id)
        {
            var funcionario = _repo.FindById(id);

            if (funcionario == null)
                return false;

            _repo.Delete(funcionario);
            return true;
        }

        
    }
}
