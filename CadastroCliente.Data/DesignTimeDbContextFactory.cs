using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CadastroCliente.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddUserSecrets<DataContext>()
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<DataContext>();
            var connectionString = "Server=DESKTOP-HCISEKU;Database=CadastroCliente;Trusted_Connection=True;MultipleActiveResultSets=true";//config.GetConnectionString("Default");
            builder.UseSqlServer(connectionString);
            Console.WriteLine(connectionString);
            return new DataContext(builder.Options);
        }
    }
}
