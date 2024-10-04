using System.Security.Principal;

namespace WhiteWebTech.API.Services.IServices
{
    public interface IGenericServices<T> where T : class
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task<T> Create(T entity);

        Task Update(int id, T entity);

        Task Delete(int id);
    }
}
