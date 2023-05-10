using apiFuncional.Models.DTO;
using apiTestes.Models;
using apiTestes.Repositorios;
using apiTestes.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Text.Json;
using Refit;

namespace apiTestes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {

        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }
  
        [HttpGet]
      
        public async Task<ActionResult<List<Pessoa>>> BuscaTodasPessoas()
        {

            List<Pessoa> pessoas = await _pessoaService.BuscarTodasPessoas();
            return Ok(pessoas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> BuscarPorId(int id)
        {
            Pessoa pessoa = await _pessoaService.BuscarPorId(id);
            return Ok(pessoa);
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Cadastrar([FromBody] PessoaDTO pessoaModel)
        {
            Pessoa pessoa = await _pessoaService.Adicionar(pessoaModel);
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> Atualizar([FromBody] PessoaDTO pessoaModel)
        {
            return Ok(await _pessoaService.Atualizar(pessoaModel));
        }

        [HttpDelete("{id}")]
        
        public async Task<ActionResult<Pessoa>> Apagar(int id)
        {
            bool apagado = await _pessoaService.Apagar(id);
            return Ok(apagado);


        }

        }
    }
