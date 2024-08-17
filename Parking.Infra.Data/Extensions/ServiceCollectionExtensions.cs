using Microsoft.Extensions.DependencyInjection;
using Parking.Infra.Data.Context;

namespace Parking.Infra.Data.Extensions
{
    /// <summary>
    /// Responsável por adicionar as injeções de dependência do <see cref="Data">Parking.Infra.Data</see>
    /// que será chamado no Program da aplicaçaõ
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adiciona o contexto do banco de dados na injeção de dependência do Program
        /// </summary>
        /// <param name="services">Service que vem do program da aplicação</param>
        /// <returns>O mesmo service do parâmetro <paramref name="services"/></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            services.AddDbContext<ParkingContext>();

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
    }
}
