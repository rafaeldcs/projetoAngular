using apiFuncional.Models.DTO;
using apiTestes.Data;
using apiTestes.Models;
using apiTestes.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Refit;

namespace apiTestes.Repositorios
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<Contato> BuscarPorId(int id)
        {
            if (id == default)
            {
                throw new Exception($"Id não veio");
            }

            return await _contatoRepository.BuscarPorId(id);
        }

        public async Task<List<Contato>> BuscarTodosContatos()
        {
            return await _contatoRepository.BuscarTodosContatos();
        }
        public async Task<Contato> Adicionar(ContatoDTO contato)
        {
            if(contato == null)
            {
                throw new Exception("Nenhum Objeto Enviado!");
            }

            Contato item = new Contato();
            item.TipoContato = contato.TipoContato;
            item.Contact = contato.Contact;
            var teste = contato.TipoContato.ToString();
          

            await _contatoRepository.Adicionar(item);

            return item;
        }

        public async Task<bool> Apagar(int id)
        {
            Contato contatoPorId = await _contatoRepository.BuscarPorId(id);
            if (contatoPorId == null)
            {
                throw new Exception($"Contato para o ID:{id} não encontrado no banco de dados");
            }

            await _contatoRepository.Apagar(contatoPorId);
            
            return true;
        }

        public async Task<Contato> Atualizar(ContatoDTO contato)
        {
            if (contato == null)
            {
                throw new Exception("Nenhum Objeto Enviado!");
            }

            if(contato.Id == default)
            {
                throw new Exception("Id não enviado");
            }

            Contato item = new Contato();

            item.TipoContato =  contato.TipoContato;
            item.Contact =  contato.Contact;
            

            Contato contatoPorId = await BuscarPorId(item.Id);
            if (contatoPorId == null)
            {
                throw new Exception($"Cotação para o ID:{contato.Id} não encontrado no banco de dados");
            }

            contatoPorId.TipoContato = contato.TipoContato;    

            await _contatoRepository.Atualizar(contatoPorId);

            return contatoPorId;
        }
    }
}
