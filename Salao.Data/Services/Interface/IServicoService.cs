using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IServicoService
    {
        List<Servico> FindAll();
        Servico FindById(int id);
        Servico Create(Servico servico);
        Servico Update(Servico servico);
        bool Delete(int id);        
    }
}
