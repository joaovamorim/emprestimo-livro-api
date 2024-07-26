using AutoMapper;
using EMPRESTIMO.LIVROS.DTOs;
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
        private readonly IMapper _mapper;

        public ClienteController(IClienteRepository clienteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _clienteRepository = clienteRepository;
        }

        [HttpGet("selecionartodos")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            var clientes = await _clienteRepository.SelecionarTodos();
            var clientesDTO = _mapper.Map<IEnumerable<ClienteDTO>>(clientes);

            return Ok(clientesDTO);  
        }

        [HttpGet("selecionarmypk{id}")]
        public async Task<ActionResult> SelecionarMyPk(int id)
        {
            var cliente = await _clienteRepository.SelecionarByPk(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

            return BadRequest(clienteDTO);
        }

        [HttpPost("cadastrarcliente")]
        public async Task<ActionResult> CadastrarCliente(ClienteDTO clienteDTO)
        {
            var cliente = _mapper.Map<Cliente>(clienteDTO);
            _clienteRepository.Incluir(cliente);

            if (await _clienteRepository.SaveAllAsync())
            {
                return Ok("Cliente cadastrado com sucesso!");
            }

            return BadRequest("Ocorreu um erro ao salvar o cliente.");
        }

        [HttpPut("alterarcliente")]
        public async Task<ActionResult> AlterarCliente(ClienteDTO clienteDTO)
        {
            if (clienteDTO.Id == 0)
            {
                return BadRequest("Não é possivel alterar o cliente. É preciso informar o ID.");
            }

            var clienteExiste = await _clienteRepository.SelecionarByPk(clienteDTO.Id);

            if (clienteExiste == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            var cliente = _mapper.Map<Cliente>(clienteDTO);
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