using apiTestes.Data;
using apiTestes.Models;
using apiTestes.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace apiFuncional.Repositorios
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly SistemaDadosDB _dbContext;

        public ContatoRepository(SistemaDadosDB sistemaDadosDBContext)
        {
            _dbContext = sistemaDadosDBContext;
        }

        public async Task<Contato> BuscarPorId(int id)
        {
            return await _dbContext.Contatos.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Contato>> BuscarTodosContatos()
        {
            return await _dbContext.Contatos.ToListAsync();
        }
        public async Task<Contato> Adicionar(Contato contato)
        {
            await _dbContext.Contatos.AddAsync(contato);
            await _dbContext.SaveChangesAsync();

            return contato;
        }

        public async Task<bool> Apagar(Contato contato)
        {
            _dbContext.Contatos.Remove(contato);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Contato> Atualizar(Contato contato)
        {
            Contato contatoPorId = await BuscarPorId(contato.Id);
            if (contatoPorId == null)
            {
                throw new Exception($"ID:{contato.Id} não encontrado no banco de dados");
            }

            contatoPorId.TipoContato = contato.TipoContato;
           

            _dbContext.Contatos.Update(contatoPorId);
            await _dbContext.SaveChangesAsync();

            return contatoPorId;
        }
    }
}
