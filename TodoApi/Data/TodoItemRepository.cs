using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly TodoContext db;

        public TodoItemRepository(TodoContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await db.TodoItems.ToListAsync();
        }

        public async Task<TodoItem> GetAsync(long id)
        {
            return await db.TodoItems.FindAsync(id);
        }

        public async Task AddAsync(TodoItem entity)
        {
            db.TodoItems.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task EditAsync(TodoItem entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task RemoveAsync(long id)
        {
            var item = await db.TodoItems.FindAsync(id);
            db.TodoItems.Remove(item);
            await db.SaveChangesAsync();
        }
    }
}
