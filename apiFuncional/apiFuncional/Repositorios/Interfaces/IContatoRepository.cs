using apiTestes.Models;

namespace apiTestes.Repositorios.Interfaces
{
    public interface IContatoRepository
    {
        Task<List<Contato>> BuscarTodosContatos();
        Task<Contato> BuscarPorId(int id);
        Task<Contato> Adicionar(Contato contato);
        Task<Contato> Atualizar(Contato contato);
        Task<bool> Apagar(Contato contato);


    }
}
