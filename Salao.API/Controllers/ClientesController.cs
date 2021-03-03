using Microsoft.AspNetCore.Mvc;
using Salao.Data.Services;
using Salao.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<ClientesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_clienteService.FindAll());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _clienteService.FindById(id);
            if (cliente == null)
                return NoContent();

            return Ok(cliente);
        }
            
        // POST api/<ClientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente )  
        {
            if (cliente == null) 
                return BadRequest();

            return Ok(_clienteService.Create(cliente));
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente == null)
                return BadRequest();

            return Ok(_clienteService.Update(cliente));
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _clienteService.Delete(id);
            return NoContent();
        }
    }
}
