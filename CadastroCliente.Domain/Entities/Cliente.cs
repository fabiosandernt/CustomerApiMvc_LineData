using CadastroCliente.Domain.Entities.Base;
using CadastroCliente.Domain.Enums;
using CadastroCliente.Domain.ValueObjects;
using System;

namespace CadastroCliente.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        protected Cliente() {}

        public Cliente(
            Guid id,
            string nome,
            DateTime birthDate,
            Cpf cpf,
            Address address,
            ESexo sexo
        )
        {
            Id = id;
            Nome = nome;
            BirthDate = birthDate;
            Cpf = cpf;
            Address = address;
            Sexo = sexo;
        }

        public string Nome { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Cpf Cpf { get; private set; }
        public Address Address { get; private set; }
        public ESexo Sexo { get; private set; }

        public void Update(
            string nome,
            DateTime birthDate,
            Cpf cpf,
            Address address,
            ESexo sexo
        )
        {
            Nome = nome;
            BirthDate = birthDate;
            Cpf = cpf;
            Address = address;
            Sexo = sexo;
        }
    }
}
