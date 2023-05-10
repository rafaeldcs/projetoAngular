using apiFuncional.Models.DTO;
using apiTestes.Models;

namespace apiTestes.Repositorios.Interfaces
{
    public interface IPessoaService
    {
        Task<List<Pessoa>> BuscarTodasPessoas();
        Task<Pessoa> BuscarPorId(int id);
        Task<Pessoa> Adicionar(PessoaDTO pessoa);
        Task<Pessoa> Atualizar(PessoaDTO pessoa);
        Task<bool> Apagar(int id);


    }
}
