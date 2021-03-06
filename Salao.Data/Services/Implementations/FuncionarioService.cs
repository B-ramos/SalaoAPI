using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _repoFuncionario;
        private readonly IEnderecoRepository _repoEnderco;

        public FuncionarioService(IFuncionarioRepository repo, IEnderecoRepository repoEndereco)
        {
            _repoFuncionario = repo;
            _repoEnderco = repoEndereco;
        }

        public List<Funcionario> FindAll()
        {
            return _repoFuncionario.FindAll();
        }

        public Funcionario FindById(int id)
        {
            return _repoFuncionario.FindById(id);
        }

        public Funcionario Create(Funcionario funcionario)
        {
            var funcionarioExiste = _repoEnderco.FindById(funcionario.EnderecoId);
            if (funcionarioExiste == null)
                return null;

            return _repoFuncionario.Create(funcionario);
        }
        
        public Funcionario Update(Funcionario novoFuncionario)
        {
            var funcionario = _repoFuncionario.FindById(novoFuncionario.Id);
            var endereco = _repoEnderco.FindById(novoFuncionario.EnderecoId);

            if (funcionario == null || endereco == null)
                return null;

            return _repoFuncionario.Update(funcionario, novoFuncionario);
        }

        public bool Delete(int id)
        {
            var funcionario = _repoFuncionario.FindById(id);

            if (funcionario == null)
                return false;

            _repoFuncionario.Delete(funcionario);
            return true;
        }

        
    }
}
