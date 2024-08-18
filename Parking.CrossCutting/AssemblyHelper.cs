using System.Reflection;

namespace Parking.CrossCutting
{
    /// <summary>
    /// Responsável por facilitar a busca reflexiva de itens no assembly
    /// </summary>
    public static class AssemblyHelper
    {
        /// <summary>
        /// Busca uma classe com sua interface no assembly a partir de um sufixo
        /// </summary>
        /// <param name="assembly">Assembly ao qual se está fazendo a busca</param>
        /// <param name="sufix">Sufixo da classe</param>
        /// <returns>Dicionario contendo a interface e a classe de implementação, respectivamente</returns>
        public static Dictionary<Type, Type> GetClassesAndInterface(Assembly assembly, string sufix)
        {
            var classesAndInterfaces = new Dictionary<Type, Type>();

            assembly.GetTypes()
                    .Where(where => where.Name.EndsWith(sufix) && where.IsClass)
                    .ToList()
                    .ForEach(type =>
                    {
                        Type @interface = type.GetInterfaces()
                                              .Where(where => !string.IsNullOrEmpty(where.Name) && where.Name[1..] == type.Name)
                                              .First();
                        classesAndInterfaces.Add(@interface, type);
                    });

            return classesAndInterfaces;
        }
    }
}
