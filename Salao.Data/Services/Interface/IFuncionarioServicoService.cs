using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IFuncionarioServicoService
    {
        List<FuncionarioServico> FindAll();
        List<FuncionarioServico> FindByIdServico(int id);
        List<FuncionarioServico> FindByIdFuncionario(int id);
        FuncionarioServico Create(FuncionarioServico funcionarioServico);       
        bool Delete(int funcionarioId, int servicoId);        
    }
}
