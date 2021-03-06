using Microsoft.AspNetCore.Mvc;
using Salao.Data.Services.Interface;
using Salao.Domain.Model;


namespace Salao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionariosController(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        /// <summary>
        /// Retorna lista de funcionarios.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/funcionarios
        /// </remarks>
        /// <response code="200">Retorna lista de funcionarios.</response>
        /// <response code="204">Não encontrou nenhum funcionario.</response>
        /// <response code="500">Erro interno no Servidor.</response> 
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var funcionarios = _funcionarioService.FindAll();

                if (funcionarios.Count < 1)
                    return NoContent();

                return Ok(funcionarios);
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
        }

        /// <summary>
        /// Retorna funcionario por Id.
        /// </summary>
        /// /// <param name="id">Identificador do funcionario.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Get /api/funcionarios/1
        /// </remarks>
        /// <response code="200">Retorna o funcionario .</response>
        /// <response code="204">Funcionario não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var funcionario = _funcionarioService.FindById(id);
                if (funcionario == null)
                    return NoContent();

                return Ok(funcionario);
            }
            catch (System.Exception)
            {

                return StatusCode(500);
            }
            
        }

        /// <summary>
        /// Inclui um novo funcionario.
        /// </summary>
        /// <remarks>
        /// Exemplo de request:
        ///     Post /api/funcionarios
        ///     
        ///         {
        ///             "nome" : "nomeFuncionario",
        ///             "telefone" : "999999999"
        ///             "cpf" : "999999999"
        ///         }
        /// </remarks>
        /// <response code="201">Funcionario incluído com sucesso.</response>
        /// <response code="204">Endereco não existe.</response>
        /// <response code="400">Todos os campos são obrigatórios.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [HttpPost]
        public IActionResult Post([FromBody] Funcionario funcionarioDto )  
        {
            try
            {
                if (string.IsNullOrEmpty(funcionarioDto.Nome) || string.IsNullOrEmpty(funcionarioDto.Telefone) ||
                    string.IsNullOrEmpty(funcionarioDto.CPF) || funcionarioDto.EnderecoId < 1)
                {
                    return BadRequest("Todos os campo são obrigatórios");
                }

                var funcionario = _funcionarioService.Create(funcionarioDto);

                if (funcionario == null)
                    return NoContent();
                
                return Created($"https://localhost:44399/api/funcionarios/{funcionario.Id}", funcionario);
            }
            catch (System.Exception)
            {
                return StatusCode(500);
            }            
        }

        /// <summary>
        /// Altera um funcionario.
        /// </summary>   
        /// <remarks>
        /// Exemplo de request:        
        ///     Put /api/funcionarios/1
        ///     
        ///         {
        ///             "id": 1,
        ///             "nome" : "novoNome",
        ///             "telefone" : "novoTelefone"
        ///             "cpf":"33333333333",
        ///             "enderecoid": 1
        ///         }
        /// </remarks>
        /// <response code="201">Funcionario alterado com sucesso.</response>
        /// <response code="204">Funcionario não foi encontrado ou enderco não existe.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(201)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpPut]
        public IActionResult Put([FromBody] Funcionario novoFuncionario)
        {
            try
            {                
                var funcionario = _funcionarioService.Update(novoFuncionario);

                if (funcionario == null)
                    return NoContent();

                return Created($"https://localhost:44399/api/funcionarios/{funcionario.Id}", funcionario);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Remove funcionario por Id.
        /// </summary>
        /// /// <param name="id">Identificador do funcionario.</param>
        /// <remarks>
        /// Exemplo de request:
        ///     Delete /api/funcionarios/1        
        ///       
        /// </remarks>
        /// <response code="200">Funcionario removido com sucesso.</response>
        /// <response code="204">Funcionario não foi encontrado.</response>
        /// <response code="500">Erro interno no Servidor.</response>
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var funcionario = _funcionarioService.Delete(id);

                if (!funcionario)
                    return NoContent();

                return Ok("Funcionario foi removido com sucesso.");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

    }
}
