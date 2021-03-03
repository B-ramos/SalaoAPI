using Salao.Domain.Interface;
using System.Collections.Generic;

namespace Salao.Domain.Model
{
    public class Servico : IBaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MinutosParaExecucao { get; set; }
        public decimal Preco { get; set; }
        public List<FuncionarioServico> FuncionarioServico { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
