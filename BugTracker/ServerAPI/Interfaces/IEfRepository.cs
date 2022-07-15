using BugTrackerData.Entities;

namespace BugTracker.ServerAPI.Interfaces
{
    public interface IEfRepository<T> where T: BaseEntity
    {
        List<T> GetAll();
        T GetById (int id);
        Task<long> Add(T entity);
    }
}
