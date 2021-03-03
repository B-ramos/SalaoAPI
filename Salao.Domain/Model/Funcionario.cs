using Salao.Domain.Interface;
using System.Collections.Generic;

namespace Salao.Domain.Model
{
    public class Funcionario : IBaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public List<FuncionarioServico> FuncionarioServico { get; set; }
    }
}
