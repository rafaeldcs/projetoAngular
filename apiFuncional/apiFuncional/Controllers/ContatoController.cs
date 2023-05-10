using apiFuncional.Models.DTO;
using apiTestes.Models;
using apiTestes.Repositorios;
using apiTestes.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apiTestes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {

        private readonly IContatoService _contatoService;

        public ContatoController(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Contato>>> BuscaTodasContatos()
        {
            List<Contato> contatos = await _contatoService.BuscarTodosContatos();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contato>> BuscarPorId(int id)
        {
            Contato contato = await _contatoService.BuscarPorId(id);
            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Cadastrar([FromBody] ContatoDTO contatoModel)
        {
            Contato contato = await _contatoService.Adicionar(contatoModel);
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Contato>> Atualizar([FromBody] ContatoDTO contatoModel)
        {
            return Ok(await _contatoService.Atualizar(contatoModel));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Contato>> Apagar(int item)
        {
            bool apagado = await _contatoService.Apagar(item);
            return Ok(apagado);
        }

        }
    }
