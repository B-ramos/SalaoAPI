using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.Data.Services
{
    public interface IEnderecoService
    {
        List<Endereco> FindAll();
        Endereco FindbyId(int id);
        Endereco Create(Endereco endereco);
        Endereco Update(Endereco endereco);
        void Delete(int id);        
    }
}
