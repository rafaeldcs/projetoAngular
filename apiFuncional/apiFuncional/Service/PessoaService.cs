using apiFuncional.Models.DTO;
using apiTestes.Data;
using apiTestes.Models;
using apiTestes.Repositorios.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace apiTestes.Repositorios
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> BuscarPorId(int id)
        {
            if (id == default)
            {
                throw new Exception($"Id não veio");
            }

            return await _pessoaRepository.BuscarPorId(id);
        }

        public async Task<List<Pessoa>> BuscarTodasPessoas()
        {
            return await _pessoaRepository.BuscarTodasPessoas();
        }
        public async Task<Pessoa> Adicionar(PessoaDTO pessoa)
        {
            Pessoa item = new Pessoa();

            if (pessoa == null)
            {
                throw new Exception("Nenhum Objeto Enviado!");
            }

            item.Id = pessoa.Id;
            item.Nome = pessoa.Nome;
            item.Cpf = pessoa.Cpf;
            item.Idade = pessoa.Idade;
            item.ContatoId= pessoa.ContatoId;

            await _pessoaRepository.Adicionar(item);

            return item;
        }

        public async Task<bool> Apagar(int id)
        {
            Pessoa pessoaPorId = await _pessoaRepository.BuscarPorId(id);
            if (pessoaPorId == null)
            {
                throw new Exception($"Pessoa para o ID:{id} não encontrado no banco de dados");
            }

            await _pessoaRepository.Apagar(pessoaPorId);
            
            return true;
        }

        public async Task<Pessoa> Atualizar(PessoaDTO pessoa)
        {
            if (pessoa == null)
            {
                throw new Exception("Nenhum Objeto Enviado!");
            }

            if(pessoa.Id == default)
            {
                throw new Exception("Id não enviado");
            }

            Pessoa item = new Pessoa();
            item.Id = pessoa.Id;
            item.Nome = pessoa.Nome;
            item.Cpf = pessoa.Cpf;
            item.Idade = pessoa.Idade;
            item.ContatoId = pessoa.ContatoId;


            Pessoa pessoaPorId = await BuscarPorId(item.Id);

            if (pessoaPorId == null)
            {
                throw new Exception($"Cotação para o ID:{pessoa.Id} não encontrado no banco de dados");
            }

            pessoaPorId.Id = pessoa.Id;
            pessoaPorId.Nome = item.Nome;
            pessoaPorId.Cpf = item.Cpf;
            pessoaPorId.Idade = item.Idade;
            pessoaPorId.ContatoId = item.ContatoId;
         

            await _pessoaRepository.Atualizar(pessoaPorId);

            return pessoaPorId;
        }

   
    }
}
