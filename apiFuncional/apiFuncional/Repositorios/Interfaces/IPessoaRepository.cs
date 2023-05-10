using apiTestes.Models;

namespace apiTestes.Repositorios.Interfaces
{
    public interface IPessoaRepository
    {
        Task<List<Pessoa>> BuscarTodasPessoas();
        Task<Pessoa> BuscarPorId(int id);
        Task<Pessoa> Adicionar(Pessoa pessoa);
        Task<Pessoa> Atualizar(Pessoa pessoa);
        Task<bool> Apagar(Pessoa pessoa);


    }
}
