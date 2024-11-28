using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Infraestrutura.Db
{
    public class DbContextoFactory : IDesignTimeDbContextFactory<DbContexto>
    {
        public DbContexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContexto>();

            // Substitua pela string de conexão correta
            var connectionString = "Server=127.0.0.1;Port=3306;Database=minimal_api;Uid=root;Pwd=140892;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new DbContexto(optionsBuilder.Options);
        }
    }
}
