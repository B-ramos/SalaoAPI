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
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClientesController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna lista de clientes.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/clientes
        /// </remarks>
        /// <response code="200">Retorna lista de clientes.</response>
        /// <response code="204">Não encontrou nenhum cliente.</response>
        /// <response code="500">Erro interno no Servidor.</response> 
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clientes = _clienteService.FindAll();

                if (clientes.Count < 1)
                    return NoContent();

                return Ok(_mapper.Map<IEnumerable<ClienteDto>>(clientes));                
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna cliente por Id.
        /// </summary>
        /// /// <param name="id">Identificador do cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/clientes/1
        /// </remarks>
        /// <response code="200">Retorna o cliente .</response>
        /// <response code="204">Cliente não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult GetByIdCliente(int id)
        {
            try
            {
                var cliente = _clienteService.FindById(id);
                if (cliente == null)
                    return NoContent();

               return Ok(_mapper.Map<ClienteDto>(cliente));
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Inclui um novo cliente.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/clientes
        ///     
        ///         {
        ///             "nome" : "nomeCliente",
        ///             "telefone" : "999999999"
        ///         }
        /// </remarks>
        /// <response code="201">Cliente incluído com sucesso.</response>
        /// <response code="400">Todos os campos são obrigatórios.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Cliente clienteDto )  
        {
            try
            {
                if (string.IsNullOrEmpty(clienteDto.Nome) || string.IsNullOrEmpty(clienteDto.Telefone))
                    return BadRequest("Todos os campos são obrigatórios");

                var cliente = _clienteService.Create(clienteDto);
                
                return Created($"https://localhost:44399/api/clientes/{cliente.Id}", cliente);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Altera um cliente.
        /// </summary>   
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/clientes/1
        ///     
        ///         {
        ///             "id": 1,
        ///             "nome" : "novoNome",
        ///             "telefone" : "novoTelefone"
        ///         }
        /// </remarks>
        /// <response code="201">Cliente alterado com sucesso.</response>
        /// <response code="204">Cliente não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Cliente novoCliente)
        {
            try
            {                
                var cliente = _clienteService.Update(novoCliente);

                if (cliente == null)
                    return NoContent();

                return Created($"https://localhost:44399/api/clientes/{cliente.Id}", cliente);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove cliente por Id.
        /// </summary>
        /// /// <param name="id">Identificador do cliente.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/clientes/1        
        ///       
        /// </remarks>
        /// <response code="200">Cliente removido com sucesso.</response>
        /// <response code="204">Cliente não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = _clienteService.Delete(id);

                if (!cliente)
                    return NoContent();

                return Ok("Cliente foi removido com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
