using CadastroCliente.Data.Map;
using CadastroCliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CadastroCliente.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(typeof(ClienteMap).GetTypeInfo().Assembly);
        }
    }
}
