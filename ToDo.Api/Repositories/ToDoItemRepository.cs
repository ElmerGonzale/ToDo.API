using Microsoft.EntityFrameworkCore;
using ToDo.Api.Data;
using ToDo.Api.Models;

namespace ToDo.Api.Repositories
{
    public class ToDoItemRepository : IRepository<ToDoItem>
    {
        //Asignación del contexto
        private readonly AppDbContext _dbContext;

        public ToDoItemRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Implementación de los métodos de la interfaz IRepository
        public async Task Add(ToDoItem item)
        {
            await _dbContext.ToDoItems.AddAsync(item);
        }

        public Task Delete(ToDoItem item)
        {
            _dbContext.ToDoItems.Remove(item);
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<ToDoItem>> GetAll()
        {
            return await _dbContext
                .ToDoItems
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ToDoItem?> GetById(int id)
        {
            return await _dbContext
                .ToDoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(item => id == item.Id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ToDoItem toDoItem)
        { 
            var item = await _dbContext.ToDoItems.FirstOrDefaultAsync(tdi => tdi.Id == toDoItem.Id);
            if (item != null)
            {
                item.Name = toDoItem.Name;
                item.IsCompleted = toDoItem.IsCompleted;
            }
        }
    }
}
