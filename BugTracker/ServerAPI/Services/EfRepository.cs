using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bug_tracker_data;
using BugTracker.ServerAPI.Interfaces;
using BugTrackerData.Entities;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.ServerAPI.Services
{
    public class MemberRepository<T> : IEfRepository<T> where T : BaseEntity
    {
        private readonly DataContext _context;

        public MemberRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<T> Delete(T entity)
        {
            var result = _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            var result =  _context.Set<T>().FirstOrDefault(x => x.Id == id);
            if (result == null) return null;
            return result;
        }
    }
}
