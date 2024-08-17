using Parking.Domain;

namespace Parking.Infra.Data
{
    /// <summary>
    /// Responsável por definir os valores padrões das entidades que serão adicionados
    /// junto com a migração do banco de dados
    /// </summary>
    public static class DefaultData
    {
        /// <summary>
        /// Define e retorna o valor padrão da entidade <see cref="Pricing"/>
        /// </summary>
        /// <returns></returns>
        public static Pricing[] GetDefaultPricing()
        {
            return
            [
                new Pricing(1, new DateTime(2024, 1, 1), new DateTime(2024, 6, 30), 2, 1, 10),
                new Pricing(2, new DateTime(2024, 7, 1), new DateTime(2024, 12, 31), 2, 1, 10),
            ];
        }
    }
}
