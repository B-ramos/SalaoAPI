using Salao.Domain.Interface;
using System;

namespace Salao.Domain.Model
{
    public class Agendamento : IBaseEntity
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public int ServicoId { get; set; }
        public Servico Servico { get; set; }

        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public DateTime? Data { get; set; }
        public DateTime? DataTermino { get; set; }
        public string Anotacao { get; set; }

        public StatusAgendamento Status { get; set; }

    }
    public enum StatusAgendamento
    {
        Pendente, 
        Finalizado, 
        Cancelado
    }
}
