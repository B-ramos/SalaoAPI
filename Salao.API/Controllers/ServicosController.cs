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
    public class ServicosController : ControllerBase
    {
        private readonly IServicoService _servicoService;
        private readonly IMapper _mapper;

        public ServicosController(IServicoService servicoService, IMapper mapper)
        {
            _servicoService = servicoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna lista de servicos.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/servicos
        /// </remarks>
        /// <response code="200">Retorna lista de servicos.</response>
        /// <response code="204">Não encontrou nenhum servico.</response>
        /// <response code="500">Erro interno no Servidor.</response> 
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var servicos = _servicoService.FindAll();

                if (servicos.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<ServicoDto>>(servicos));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna servico por Id.
        /// </summary>
        /// /// <param name="id">Identificador do servico.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/servicos/1
        /// </remarks>
        /// <response code="200">Retorna o servico .</response>
        /// <response code="204">Servico não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var servico = _servicoService.FindById(id);
                if (servico == null)
                    return NoContent();

                return Ok(_mapper.Map<ServicoDto>(servico));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Inclui um novo servico.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/servicos
        ///     
        ///         {
        ///             "nome" : "nomeServico",
        ///             "MinutosParaExecucao" : "29",
        ///             "preco" : "25.00"
        ///         }
        ///         
        /// </remarks>
        /// <response code="201">Servico incluído com sucesso.</response>
        /// <response code="400">Todos os campos são obrigatórios.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Servico servicoDto )  
        {
            try
            {
                if (string.IsNullOrEmpty(servicoDto.Nome) || servicoDto.MinutosParaExecucao < 1 ||
                    servicoDto.Preco < 1)
                {
                    return BadRequest("Todos os campos são obrigatórios");
                }

                var servico = _servicoService.Create(servicoDto);
                if (servico == null)
                    return BadRequest("Serviço já existe.");
                
                return Created($"https://localhost:44399/api/servicos/{servico.Id}", servico);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Altera um servico.
        /// </summary>   
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/servicos/1
        ///     
        ///         {
        ///             "id" : 1,
        ///             "nome" : "nomeServico",
        ///             "MinutosParaExecucao" : "29",
        ///             "preco" : "25.00"
        ///         }
        /// </remarks>
        /// <response code="201">Servico alterado com sucesso.</response>
        /// <response code="204">Servico não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Servico novoServico)
        {
            try
            {                
                var servico = _servicoService.Update(novoServico);

                if (servico == null)
                    return NoContent();

                return Created($"https://localhost:44399/api/servicos/{servico.Id}", servico);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove servico por Id.
        /// </summary>
        /// /// <param name="id">Identificador do servico.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/servicos/1        
        ///       
        /// </remarks>
        /// <response code="200">Servico removido com sucesso.</response>
        /// <response code="204">Servico não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var servico = _servicoService.Delete(id);

                if (!servico)
                    return NoContent();

                return Ok("Servico foi removido com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
