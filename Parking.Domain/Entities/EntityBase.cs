namespace Parking.Domain
{
    /// <summary>
    /// Entidade base para todas as outras entidades
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public int Id { get; set; }
    }
}
