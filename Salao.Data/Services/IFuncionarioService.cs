using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services
{
    public interface IFuncionarioService
    {
        List<Funcionario> FindAll();
        Funcionario FindById(int id);
        Funcionario Create(Funcionario funcionario);
        Funcionario Update(Funcionario funcionario);
        void Delete(int id);        
    }
}
