namespace Parking.Domain.Repositories
{
    /// <summary>
    /// Repositório base para todos os outros repositórios
    /// </summary>
    /// <typeparam name="TEntity">Entidade a qual o respositório está vinculado</typeparam>
    public interface IRepository<TEntity> where TEntity : EntityBase
    {
        /// <summary>
        /// Busca todos os registros para a entidade
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Adiciona uma entidade ao banco de dados
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        /// <returns>Entidade no banco após ser adicionada</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Atualiza o registro de uma entidade
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        /// <returns>Entidade no banco após ser atualizada</returns>
        TEntity Update(TEntity entity);

        /// <summary>
        /// Salva as alterações no banco de dados
        /// </summary>
        void Commit();
    }
}
