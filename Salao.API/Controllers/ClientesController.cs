using Microsoft.AspNetCore.Mvc;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;


namespace Salao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _clienteService.FindAll();

                if (result.Count < 1)
                    return NoContent();

                return Ok(result);
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _clienteService.FindById(id);
            if (cliente == null)
                return NoContent();

            return Ok(cliente);
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente )  
        {
            try
            {
                if (string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Telefone))
                    return BadRequest("Nome e telefone não podem ser nulos");

                var result = _clienteService.Create(cliente);
                
                return Created($"https://localhost:44399/api/clientes/{result.Id}", result);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Cliente novoCliente)
        {
            try
            {                
                var result = _clienteService.Update(novoCliente);

                if (result == null)
                    return BadRequest("O cliente não existe.");

                return Created($"https://localhost:44399/api/clientes/{result.Id}", result);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _clienteService.Delete(id);

            if (!result)
                return BadRequest("O cliente não existe");

            return Ok("Cliente foi removido com sucesso.");
        }
    }
}
