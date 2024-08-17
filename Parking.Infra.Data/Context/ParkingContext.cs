using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Parking.Infra.Data.Context
{
    public class ParkingContext : DbContext
    {
        private const string MAPPING_PATH = "Parking.Infra.Data.Mappings";

        public ParkingContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// Realiza a migração do banco de dados
        /// </summary>
        public void Migrate()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // todo: get it from appsettings
            var connectionString = "Host=localhost;Port=5432;Database=Parking;User Id=postgres;Password=postgres;";

            if (!string.IsNullOrWhiteSpace(connectionString) )
                optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var type in GetMappings())
            {
                dynamic instance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(instance);
            }

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Busca todas as classes de mapeamento das entidades para aplicar as configurações de migração
        /// </summary>
        /// <returns></returns>
        private List<Type> GetMappings()
        {
            return Assembly.GetExecutingAssembly()
                           .GetTypes()
                           .Where(where => where.Namespace != null && where.IsPublic && where.Namespace.StartsWith(MAPPING_PATH))
                           .ToList();
        }
    }
}
