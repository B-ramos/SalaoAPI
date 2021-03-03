using Salao.Domain.Interface;

namespace Salao.Domain.Model
{
    public class FuncionarioServico : IBaseEntity
    {
        public int Id { get; set; }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int ServicoId { get; set; }
        public Servico Servico { get; set; }
    }
}
