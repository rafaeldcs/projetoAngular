using apiTestes.Models;

namespace apiFuncional.Models.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Idade { get; set; }
        public int ContatoId { get; set; }

    }
}
