using apiFuncional.Models.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiTestes.Models
{
    public class Contato
    {
        public int Id { get; set; }
        public string TipoContato { get; set; }
        public string Contact { get; set; }
    
    }
}
