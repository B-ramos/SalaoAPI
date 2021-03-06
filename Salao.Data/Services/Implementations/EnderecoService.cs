using Salao.Data.Repository.Interface;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _repoEndereco;
        private readonly IFuncionarioRepository _repoFuncionario;

       
        public EnderecoService(IEnderecoRepository repoEndereco, IFuncionarioRepository repoFuncionario)
        {
            _repoEndereco = repoEndereco;
            _repoFuncionario = repoFuncionario;
        }

        public List<Endereco> FindAll()
        {
            return _repoEndereco.FindAll();
        }

        public Endereco FindEnderecoByIdFuncionario(int  id)
        {
            var funcionario = _repoFuncionario.FindById(id);
            if (funcionario == null)
                return null;

            return _repoEndereco.FindById(funcionario.EnderecoId);
        }

        public Endereco Create(Endereco endereco)
        {
            var enderecoExiste = _repoEndereco.FindByCep(endereco);

            if (enderecoExiste == null || endereco.Numero != enderecoExiste.Numero)
               return _repoEndereco.Create(endereco);

            return null;
        }
        
        public Endereco Update(Endereco novoEndereco)
        {
            var endereco = _repoEndereco.FindById(novoEndereco.Id);

            if (endereco == null)
                return null;

            return _repoEndereco.Update(endereco, novoEndereco);
        }

        public bool Delete(int id)
        {
            var EnderecoPertenceFuncionario = _repoFuncionario.FindByEnderco(id);

            if (EnderecoPertenceFuncionario != null)
                return false;

            var endereco = _repoEndereco.FindById(id);
            if (endereco == null)
                return false;
           
            _repoEndereco.Delete(endereco);
            return true;
        }
    }
}
