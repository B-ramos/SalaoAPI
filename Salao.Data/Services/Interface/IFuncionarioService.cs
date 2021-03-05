using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IFuncionarioService
    {
        List<Funcionario> FindAll();
        Funcionario FindById(int id);
        Funcionario Create(Funcionario funcionario);
        Funcionario Update(Funcionario funcionario);
        bool Delete(int id);        
    }
}
