using apiFuncional.Models.DTO;
using apiTestes.Models;

namespace apiTestes.Repositorios.Interfaces
{
    public interface IContatoService
    {
        Task<List<Contato>> BuscarTodosContatos();
        Task<Contato> BuscarPorId(int id);
        Task<Contato> Adicionar(ContatoDTO contato);
        Task<Contato> Atualizar(ContatoDTO contato);
        Task<bool> Apagar(int id);


    }
}
