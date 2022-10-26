using CadastroCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroCliente.Data.Map
{
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Sexo).IsRequired();
            builder.Property(x => x.BirthDate).IsRequired();

            builder.OwnsOne(x => x.Cpf,
                ba =>
                {
                    ba.Property(a => a.Number);
                }).Navigation(x => x.Cpf);

            builder.OwnsOne(x => x.Address,
                ba =>
                {
                    ba.Property(a => a.Street);

                    ba.Property(a => a.City);

                    ba.Property(a => a.State);
                }).Navigation(x => x.Address);
        }
    }
}
