using EMPRESTIMO.LIVROS.Interfaces;
using EMPRESTIMO.LIVROS.Models;
using Microsoft.EntityFrameworkCore;

namespace EMPRESTIMO.LIVROS.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly EmprestimoLivroContext _context;

        public ClienteRepository(EmprestimoLivroContext context)
        {
            _context = context;
        }

        public void Incluir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
        }

        public void Alterar(Cliente cliente)
        {
            var existingCliente = _context.Cliente.Find(cliente.Id);

            if (existingCliente != null)
            {
                _context.Entry(existingCliente).State = EntityState.Detached;
            }

            _context.Cliente.Update(cliente);
        }

        public void Excluir(Cliente cliente)
        {
            _context.Cliente.Remove(cliente);
        }


        public async Task<Cliente> SelecionarByPk(int id)
        {
            var cliente = await _context.Cliente.Where(x => x.Id == id).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> SelecionarTodos()
        {
            var list = await _context.Cliente.ToListAsync();
            return list;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}