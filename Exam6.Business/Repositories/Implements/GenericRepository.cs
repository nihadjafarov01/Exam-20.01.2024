using Exam6.Business.Repositories.Interfaces;
using Exam6.Core.Models.Common;
using Exam6.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Exam6.Business.Repositories.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseModel
    {
        Exam6DbContext _context { get; }

        public GenericRepository(Exam6DbContext context)
        {
            _context = context;
        }
        DbSet<T> Table => _context.Set<T>();
        public async Task CreateAsync(T model)
        {
            await Table.AddAsync(model);
            await SaveAsync();
        }

        public async Task DeleteAsync(T model)
        {
            model.IsDeleted = true;
            await SaveAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var data = await Table.ToListAsync();
            return data;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T model)
        {
            Table.Update(model);
            await SaveAsync();
        }
    }
}
