using EMPRESTIMO.LIVROS.Interfaces;
using EMPRESTIMO.LIVROS.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMPRESTIMO.LIVROS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("selecionartodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return Ok(await _clienteRepository.SelecionarTodos());  
        }

        [HttpPost("cadastrarcliente")]
        public async Task<ActionResult> CadastrarCliente(Cliente cliente)
        {
            _clienteRepository.Incluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o cliente.");
        }
    }
}