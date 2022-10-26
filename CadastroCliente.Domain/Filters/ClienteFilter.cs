using CadastroCliente.Domain.Enums;
using CadastroCliente.Domain.ValueObjects;

namespace CadastroCliente.Domain.Filters
{
    public class ClienteFilter
    {
        public string? Nome { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Cpf { get; set; }
        public string? State { get; set; }
        public string? City { get; set; }
        public ESexo? Sexo { get;  set; }
    }
}
