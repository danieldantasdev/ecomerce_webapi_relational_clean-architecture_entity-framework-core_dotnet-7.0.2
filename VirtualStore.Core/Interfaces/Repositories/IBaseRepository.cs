namespace VirtualStore.Core.Interfaces.Repositories;

public interface IBaseRepository<T> where T : class
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task Add(T entity);
    Task Update(T entity);
    Task Delete(T entity);
}