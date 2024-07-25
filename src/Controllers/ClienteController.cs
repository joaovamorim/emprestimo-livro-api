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

        [HttpGet("selecionarmypk{id}")]
        public async Task<ActionResult> SelecionarMyPk(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            return BadRequest(cliente);
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

        [HttpPut("alterarcliente")]
        public async Task<ActionResult> AlterarCliente(Cliente cliente)
        {
            _clienteRepository.Alterar(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente atualizado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao atualizar o cliente.");
        }

        [HttpDelete("deletarcliente{id}")]
        public async Task<ActionResult> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            _clienteRepository.Excluir(cliente);
            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente deletado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao deletar o cliente.");
        }
    }
}