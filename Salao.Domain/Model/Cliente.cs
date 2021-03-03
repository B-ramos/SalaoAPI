using Salao.Domain.Interface;
using System.Collections.Generic;

namespace Salao.Domain.Model
{
    public class Cliente : IBaseEntity
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public List<Agendamento> Agendamentos { get; set; }
    }
}
