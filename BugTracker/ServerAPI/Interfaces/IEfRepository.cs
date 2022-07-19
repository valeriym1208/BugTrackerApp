using BugTrackerData.Entities;

namespace BugTracker.ServerAPI.Interfaces
{
    public interface IEfRepository<T> where T: BaseEntity
    {
        List<T> GetAll();
        T GetById (long id);
        Task<T> Add(T entity);
        Task<T> Delete(T entity);
    }
}
