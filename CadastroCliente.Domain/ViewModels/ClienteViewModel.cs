using CadastroCliente.CrossCutting.Utils;
using CadastroCliente.Domain.Enums;
using CadastroCliente.Domain.ValueObjects;
using System.ComponentModel;

namespace CadastroCliente.Domain.ViewModels
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get;set; }
        public DateTime BirthDate { get; set; }
        public Cpf Cpf { get; set; }
        public Address Address { get; set; }
        public ESexo Sexo { get; set; }
        [DisplayName("Idade")]
        public int Idade => BirthDate.CalculaAge();

    }
}
