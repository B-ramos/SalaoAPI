using System;

namespace Salao.API.Dto
{
    public class AgendamentoDto
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public DateTime DataTermino { get; set; }
        public string Anotacao { get; set; }
        public string Status { get; set; }
    }
}
