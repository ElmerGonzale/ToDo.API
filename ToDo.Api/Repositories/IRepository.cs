namespace ToDo.Api.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity?> GetById(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task Save();
    }
}
