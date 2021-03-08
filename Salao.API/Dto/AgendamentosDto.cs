namespace Salao.API.Dto
{
    public class AgendamentosDto
    {
        public ClienteDto Cliente { get; set; }
        public FuncionarioDto Funcionario { get; set; }
        public ServicoDto Servico { get; set; }
        public AgendamentoDto Agendamento { get; set; }
    }
}
