using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services
{
    public interface IServicoService
    {
        List<Servico> FindAll();
        Servico FindbyId(int id);
        Servico Create(Servico servico);
        Servico Update(Servico servico);
        void Delete(int id);        
    }
}
