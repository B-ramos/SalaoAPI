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
    public class FuncionariosServicosController : ControllerBase
    {
        private readonly IFuncionarioServicoService _funcionarioServicoService;
        private readonly IMapper _mapper;

        public FuncionariosServicosController(IFuncionarioServicoService funcionarioServicoService, IMapper mapper)
        {
            _funcionarioServicoService = funcionarioServicoService;
            _mapper = mapper;
        }       

        /// <summary>
        /// Retorna os funcionarios que prestam o servico pelo Id do servico.
        /// </summary>
        /// <param name="id">Identificador do Servico.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/funcionarioServicos/1
        /// </remarks>
        /// <response code="200">Retorna os funcionarios que prestam o servico.</response>
        /// <response code="204">servico não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("GetByIdServico/{id}")]
        public IActionResult GetByIdServico(int id)
        {
            try
            {
                var funcionarioServico = _funcionarioServicoService.FindByIdServico(id);
                if (funcionarioServico == null)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<FuncionarioServicoDto>>(funcionarioServico));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Retorna os serviços que o funcionario oferece pelo Id do funcionário.
        /// </summary>
        /// <param name="id">Identificador do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/funcionarioServicos/1
        /// </remarks>
        /// <response code="200">Retorna os serviços que o funcionario oferece pelo Id do funcionário.</response>
        /// <response code="204">Funcionário não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("GetByIdFuncionario/{id}")]
        public IActionResult GetByIdFuncionario(int id)
        {
            try
            {
                var funcionarioServico = _funcionarioServicoService.FindByIdFuncionario(id);
                if (funcionarioServico == null)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<FuncionarioServicoDto>>(funcionarioServico));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }

        }

        /// <summary>
        /// Inclui serviço pro funcionário.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/funcionarioServicos
        ///     
        ///         {
        ///             "funcionarioId" : 1,
        ///             "servicoId" : 1
        ///         }
        /// </remarks>
        /// <response code="201">serviço incluído com sucesso.</response>
        /// <response code="400">Todos os campos são obrigatórios.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] FuncionarioServico funcionarioServicoDto )  
        {
            try
            {
                if (funcionarioServicoDto.FuncionarioId < 1 || funcionarioServicoDto.ServicoId < 1)
                    return BadRequest("Todos os campos são obrigatórios e id tem que ser maior que zero(0).");

                var funcionarioServico = _funcionarioServicoService.Create(funcionarioServicoDto);
                if (funcionarioServico == null)
                    return BadRequest("Funcionario ou Serviço não existe.");
                
                return Created($"https://localhost:44399/api/funcionarioServicos/{funcionarioServico.Id}", funcionarioServico);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Remove o serviço do funcionário.
        /// </summary>
        /// <param name="funcionarioId"></param>
        /// <param name="servicoId"></param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/funcionarioServicos/1        
        ///       
        /// </remarks>
        /// <response code="200">FuncionarioServico removido com sucesso.</response>
        /// <response code="204">Funcionário não tem esse serviço.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{funcionarioId}/{servicoId}")]
        public IActionResult Delete(int funcionarioId, int servicoId)
        {
            try
            {
                var funcionarioServico = _funcionarioServicoService.Delete(funcionarioId, servicoId);

                if (!funcionarioServico)
                    return NoContent();

                return Ok("Servico foi removido do funcionário com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
