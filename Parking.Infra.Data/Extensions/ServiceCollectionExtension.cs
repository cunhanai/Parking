using Microsoft.Extensions.DependencyInjection;
using Parking.Infra.Data.Context;
using Parking.CrossCutting;
using System.Reflection;

namespace Parking.Infra.Data.Extensions
{
    /// <summary>
    /// Responsável por adicionar as injeções de dependência do <see cref="Data">Parking.Infra.Data</see>
    /// que será chamado no Program da aplicação
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adiciona a camada de infraestrutura na injeção de dependência
        /// </summary>
        /// <param name="services">Service que vem do program da aplicação</param>
        /// <returns>O mesmo service do parâmetro <paramref name="services"/></returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<ParkingContext>();

            services.AddRepositories();

            return services;
        }

        /// <summary>
        /// Realiza a migração do banco de dados
        /// </summary>
        /// <param name="services">Service que vem do program da aplicação</param>
        /// <returns>O mesmo service do parâmetro <paramref name="services"/></returns>
        public static IServiceCollection MigrateDatabase(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            var database = provider.GetRequiredService<ParkingContext>();
            database.Migrate();

            return services;
        }

        /// <summary>
        /// Adiciona os repositórios na injeção de dependência
        /// </summary>
        /// <param name="services">Service que vem do program da aplicação</param>
        /// <returns>O mesmo service do parâmetro <paramref name="services"/></returns>
        private static void AddRepositories(this IServiceCollection services)
        {
            foreach (var @class in AssemblyHelper.GetClassesAndInterface(Assembly.GetExecutingAssembly(), "Repository"))
                services.AddTransient(@class.Key, @class.Value);
        }
    }
}
