using Microsoft.Extensions.DependencyInjection;
using Parking.CrossCutting;
using System.Reflection;

namespace Parking.Application.Extensions
{
    /// <summary>
    /// Responsável por adicionar as injeções de dependência do <see cref="Application">Parking.Application</see>
    /// que será chamado no Program da aplicação
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Insere as injeções de dependência dos Serviços da aplicação
        /// </summary>
        /// <param name="services">Service que vem do Program da aplicação</param>
        /// <returns>O mesmo service do parâmetro <paramref name="services"/></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            foreach (var @class in AssemblyHelper.GetClassesAndInterface(Assembly.GetExecutingAssembly(), "Service"))
                services.AddScoped(@class.Key, @class.Value);

            return services;
        }
    }
}
