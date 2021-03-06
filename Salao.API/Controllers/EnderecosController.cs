using Microsoft.AspNetCore.Mvc;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;


namespace Salao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecosController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;        

        public EnderecosController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;            
        }

        /// <summary>
        /// Retorna lista de enderecos.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/enderecos
        /// </remarks>
        /// <response code="200">Retorna lista de enderecos.</response>
        /// <response code="204">Não encontrou nenhum endereco.</response>
        /// <response code="500">Erro interno no Servidor.</response> 
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var enderecos = _enderecoService.FindAll();

                if (enderecos.Count < 1)
                    return NoContent();

                return Ok(enderecos);
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna endereco por Id do funcionário.
        /// </summary>
        /// <param name="id">Identificador do funcionário.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/enderecos/1
        /// </remarks>
        /// <response code="200">Retorna o endereco do funcionário.</response>
        /// <response code="204">Funcionário não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {                                
                var endereco = _enderecoService.FindEnderecoByIdFuncionario(id);
                if (endereco == null)
                    return NoContent();

                return Ok(endereco);
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }

        }

        /// <summary>
        /// Inclui um novo endereco.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/enderecos
        ///     
        ///          {
	    ///               "logradouro":"Carlos de albuquerque",
	    ///               "cep": "0433-058",
	    ///               "bairro":"Paulistano",
	    ///               "cidade":"São paulo",
	    ///               "uf":"Sp",
	    ///               "numero":"1158",
	    ///               "complemento":""
        ///            }
        /// </remarks>
        /// <response code="201">Endereco incluído com sucesso.</response>
        /// <response code="400">Apenas o campo complemento pode ser nulo.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Endereco enderecoDto)
        {
            try
            {
                if (string.IsNullOrEmpty(enderecoDto.Logradouro) || string.IsNullOrEmpty(enderecoDto.Numero) ||
                    string.IsNullOrEmpty(enderecoDto.Bairro) || string.IsNullOrEmpty(enderecoDto.CEP) ||
                    string.IsNullOrEmpty(enderecoDto.Cidade) || string.IsNullOrEmpty(enderecoDto.UF))
                {
                        return BadRequest("Apenas o campo complemento pode ser nulo.");
                }

                var endereco = _enderecoService.Create(enderecoDto);
                if (endereco == null)
                    return StatusCode(422, "Endereço já cadastrado");

                return Created($"https://localhost:44399/api/enderecos/{endereco.Id}", endereco);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Altera um endereco.
        /// </summary>   
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/enderecos/1
        ///     
        ///          {
        ///               "id": 1,  
        ///               "logradouro":"Carlos de albuquerque",
        ///               "cep": "0433-058",
        ///               "bairro":"Paulistano",
        ///               "cidade":"São paulo",
        ///               "uf":"Sp",
        ///               "numero":"1158",
        ///               "complemento":""
        ///            }
        /// </remarks>
        /// <response code="201">Endereco alterado com sucesso.</response>
        /// <response code="204">Endereco não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Endereco novoEndereco)
        {
            try
            {
                if (string.IsNullOrEmpty(novoEndereco.Logradouro) || string.IsNullOrEmpty(novoEndereco.Numero) ||
                    string.IsNullOrEmpty(novoEndereco.Bairro) || string.IsNullOrEmpty(novoEndereco.CEP) ||
                    string.IsNullOrEmpty(novoEndereco.Cidade) || string.IsNullOrEmpty(novoEndereco.UF))
                {
                    return BadRequest("Apenas o campo complemento pode ser nulo.");
                }

                var enderco = _enderecoService.Update(novoEndereco);

                if (enderco == null)
                    return NoContent();

                return Created($"https://localhost:44399/api/enderecos/{enderco.Id}", enderco);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove endereco por Id.
        /// </summary>
        /// /// <param name="id">Identificador do endereco.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/enderecos/1        
        ///       
        /// </remarks>
        /// <response code="200">Endereco removido com sucesso.</response>
        /// <response code="400">Enderco não existe ou está sendo usado por algum funcionário.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var enderco = _enderecoService.Delete(id);

                if (!enderco)
                    return BadRequest("Enderco não existe ou está sendo usado por algum funcionário.");

                return Ok("Endereco foi removido com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
