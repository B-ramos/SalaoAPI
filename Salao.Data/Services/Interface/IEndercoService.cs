using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IEnderecoService
    {
        List<Endereco> FindAll();
        Endereco FindEnderecoByIdFuncionario(int id);
        Endereco Create(Endereco endereco);
        Endereco Update(Endereco endereco);
        bool Delete(int id);        
    }
}
