using Parking.Application.Dtos;
using System.Globalization;

namespace Parking.Application.Extensions
{
    public static class GeneralExtensions
    {
        #region decimal

        /// <summary>
        /// Formata um valor monetário para a moeda padrão
        /// </summary>
        /// <param name="value">Valor para formatação</param>
        /// <returns>O valor formatado em real</returns>
        public static string GetCurrency(this decimal value)
        {
            return value.ToString("C", new CultureInfo("pt-BR"));
        }

        /// <summary>
        /// Converte um uma <see cref="string"/> para <see cref="decimal"/>
        /// </summary>
        /// <param name="value">String para ser convertida</param>
        /// <returns></returns>
        public static decimal GetDecimal(this string value)
        {
            return decimal.Parse(value.ToUpper());
        }

        #endregion

        #region DateTime

        /// <summary>
        /// Converte um <see cref="DateTime"/> para <see cref="string"/>, caso seja nulo, 
        /// informa um valor padrão
        /// </summary>
        /// <param name="value">Datetime que será convertido</param>
        /// <param name="def">Valor padrão caso o dateTime seja nulo</param>
        /// <returns>A data na formatação <i>dd/MM/yyyy HH:mm:ss</i></returns>
        public static string ToStringOrDefault(this DateTime? value, string def = "")
        {
            return value.HasValue ? value.Value.ToString() : def;
        }

        /// <summary>
        /// Converte um <see cref="DateTime"/> para <see cref="string"/>,
        /// </summary>
        /// <param name="value">Datetime que será convertido</param>
        /// <returns>A data na formatação <i>dd/MM/yyyy</i></returns>
        public static string ToStringOnlyDate(this DateTime value)
        {
            return value.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Converte uma <see cref="string"/> em um <see cref="DateTime"/> a partir de uma
        /// formatação
        /// </summary>
        /// <param name="value">data na formatação <i>dd/MM/yyyy HH:mm:ss</i></param>
        /// <returns>A data convertida</returns>
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.ParseExact(value, "dd/MM/yyyy HH:mm:ss", new CultureInfo("pt-br"));
        }

        /// <summary>
        /// Converte uma <see cref="string"/> em um <see cref="DateTime"/> a partir de uma
        /// formatação, levando em consideração apenas a data
        /// </summary>
        /// <param name="value">data na formatação <i>"yyyy-MM-dd"</i></param>
        /// <returns>A data convertida</returns>
        public static DateTime ToDate(this string value)
        {
            return DateTime.ParseExact(value, "yyyy-MM-dd", new CultureInfo("pt-br"));
        }

        #endregion

        #region TimeSpan

        /// <summary>
        /// Formata um <see cref="TimeSpan"/> para <see cref="string"/>
        /// </summary>
        /// <param name="timeSpan">Hora que será formatada</param>
        /// <returns>A hora na formatação <i>hh:mm:ss</i></returns>
        public static string ToStringHour(this TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        #endregion
    }
}
