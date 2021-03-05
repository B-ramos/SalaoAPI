using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services.Interface
{
    public interface IClienteService
    {
        List<Cliente> FindAll();
        Cliente FindById(int id);
        Cliente Create(Cliente cliente);
        Cliente Update(Cliente cliente);
        bool Delete(int id);        
    }
}
