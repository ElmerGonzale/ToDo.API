using ToDo.Api.Data;
using ToDo.Api.DTOs;
using ToDo.Api.Models;
using ToDo.Api.Repositories;

namespace ToDo.Api.Services
{
    public class ToDoItemsService : IToDoItemsService
    {
        private readonly IRepository<ToDoItem> _repository;
        public ToDoItemsService(IRepository<ToDoItem> repository)
        {
            _repository = repository;
        }
        public async Task<ToDoItemDto?> AddAsync(CreateToDoItemDto createToDoItemDto)
        {
            var toDoItem = new ToDoItem
            {
                Name = createToDoItemDto.Name,
                IsCompleted = false
            };
            await _repository.Add(toDoItem);
            await _repository.Save();

            var toDoItemDto = new ToDoItemDto
            {
                Id = toDoItem.Id,
                Name = toDoItem.Name,
                IsCompleted = toDoItem.IsCompleted
            };
            return toDoItemDto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var toDoItem = await _repository.GetById(id);
            if (toDoItem == null)
                return false;

            await _repository.Delete(toDoItem);
            await _repository.Save();
            return true;
        }

        public async Task<IEnumerable<ToDoItemDto>> GetAllAsync()
        {
            var toDoItems = await _repository.GetAll();
            return toDoItems
                .Select(i => new ToDoItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    IsCompleted = i.IsCompleted
                });
        }

        public async Task<ToDoItemDto?> GetByIdAsync(int id)
        {
            var toDoItem = await _repository.GetById(id);
            if (toDoItem == null)
                return null;

            return new ToDoItemDto
            {
                Id = toDoItem.Id,
                Name = toDoItem.Name,
                IsCompleted = toDoItem.IsCompleted
            };
        }

        public async Task<bool> UpdateAsync(UpdateToDoItemDto updateToDoItemDto, int id)
        {
            var toDoItem = await _repository.GetById(id);
            if (toDoItem == null)
                return false;

            toDoItem.Name = updateToDoItemDto.Name;
            toDoItem.IsCompleted = updateToDoItemDto.IsCompleted;

            await _repository.Update(toDoItem);
            await _repository.Save();
            return true;
        }
    }
}
