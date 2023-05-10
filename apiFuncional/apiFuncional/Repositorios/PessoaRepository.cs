using apiTestes.Data;
using apiTestes.Models;
using apiTestes.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace apiFuncional.Repositorios
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly SistemaDadosDB _dbContext;

        public PessoaRepository(SistemaDadosDB sistemaDadosDBContext)
        {
            _dbContext = sistemaDadosDBContext;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            return await _dbContext.Pessoas.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return await _dbContext.Pessoas.ToListAsync();
        }
        public async Task<Pessoa> Adicionar(Pessoa pessoa)
        {
         

            await _dbContext.Pessoas.AddAsync(pessoa);
            await _dbContext.SaveChangesAsync();
            
            return pessoa;
        }

        public async Task<bool> Apagar(Pessoa pessoa)
        {

            _dbContext.Pessoas.Remove(pessoa);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Pessoa> Atualizar(Pessoa pessoa)
        {
            Pessoa pessoaPorId = await BuscarPorId(pessoa.Id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Cotação para o ID:{pessoa.Id} não encontrado no banco de dados");
            }

            pessoaPorId.Nome = pessoa.Nome;
        

            _dbContext.Pessoas.Update(pessoaPorId);
            await _dbContext.SaveChangesAsync();

            return pessoaPorId;
        }


    }
}
