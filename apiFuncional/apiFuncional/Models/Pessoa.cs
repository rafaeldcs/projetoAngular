using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ConstrainedExecution;

namespace apiTestes.Models
{
    public class Pessoa
    {
  
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Idade { get; set; }
        public int ContatoId { get; set; }
        public ICollection<Contato> TipoContato { get; set; }
   
    }
}