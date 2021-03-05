using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IFuncionarioServicoService
    {
        List<FuncionarioServico> FindAll();
        FuncionarioServico FindById(int id);
        FuncionarioServico Create(FuncionarioServico funcionarioServico);
        FuncionarioServico Update(FuncionarioServico funcionarioServico);
        bool Delete(int id);        
    }
}
