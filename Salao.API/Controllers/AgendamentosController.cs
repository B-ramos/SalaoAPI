using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Salao.API.Dto;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;
using System.Collections.Generic;

namespace Salao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentosController : ControllerBase
    {
        private readonly IAgendamentoService _agendamentoService;
        private readonly IMapper _mapper;

        public AgendamentosController(IAgendamentoService agendamentoService, IMapper mapper)
        {
            _agendamentoService = agendamentoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna lista de agendamentos.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/agendamentos
        /// </remarks>
        /// <response code="200">Retorna lista de agendamentos.</response>
        /// <response code="204">Não encontrou nenhum agendamento.</response>
        /// <response code="500">Erro interno no Servidor.</response> 
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var agendamentos = _agendamentoService.FindAll();

                if (agendamentos.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AgendamentosDto>>(agendamentos));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna agendamento pelo Id do cliente.
        /// </summary>
        /// /// <param name="id">Identificador do cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/agendamentos/1
        /// </remarks>
        /// <response code="200">Retorna os agendamentos do cliente .</response>
        /// <response code="204">Cliente não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("cliente/{id}")]
        public IActionResult GetByIdCliente(int id)
        {
            try
            {
                var agendamentos = _agendamentoService.FindByIdCliente(id);
                if (agendamentos == null)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AgendamentosDto>>(agendamentos));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Retorna agendamento pelo Id do funcionário.
        /// </summary>
        /// /// <param name="id">Identificador do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/agendamentos/1
        /// </remarks>
        /// <response code="200">Retorna os agendamentos do funcionário .</response>
        /// <response code="204">Funcionário não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("funcionario/{id}")]
        public IActionResult GetByidFuncionario(int id)
        {
            try
            {
                var agendamentos = _agendamentoService.FindByIdFuncionario(id);
                if (agendamentos == null)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<AgendamentosDto>>(agendamentos));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }

        }

        /// <summary>
        /// Inclui um novo agendamento.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/agendamentos
        ///     
        ///         {
        ///             "nome" : "nomeAgendamento",
        ///             "telefone" : "999999999"
        ///         }
        /// </remarks>
        /// <response code="201">Agendamento incluído com sucesso.</response>
        /// <response code="400">Todos os campos são obrigatórios.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Agendamento agendamentoDto )  
        {
            try
            {
                
                var agendamento = _agendamentoService.Create(agendamentoDto);
                if (agendamento == null)
                    return BadRequest("Horário indisponível.");
                
                return Created($"https://localhost:44399/api/agendamentos/{agendamento.Id}", agendamento);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Altera um agendamento.
        /// </summary>   
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/agendamentos/1
        ///     
        ///         {
        ///             "id": 1,
        ///             "nome" : "novoNome",
        ///             "telefone" : "novoTelefone"
        ///         }
        /// </remarks>
        /// <response code="201">Agendamento alterado com sucesso.</response>
        /// <response code="204">Agendamento não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Agendamento novoAgendamento)
        {
            try
            {                
                var agendamento = _agendamentoService.Update(novoAgendamento);

                if (agendamento == null)
                    return NoContent();

                return Created($"https://localhost:44399/api/agendamentos/{agendamento.Id}", agendamento);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove agendamento por Id.
        /// </summary>
        /// /// <param name="id">Identificador do agendamento.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/agendamentos/1        
        ///       
        /// </remarks>
        /// <response code="200">Agendamento removido com sucesso.</response>
        /// <response code="204">Agendamento não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var agendamento = _agendamentoService.Delete(id);

                if (!agendamento)
                    return NoContent();

                return Ok("Agendamento foi removido com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
