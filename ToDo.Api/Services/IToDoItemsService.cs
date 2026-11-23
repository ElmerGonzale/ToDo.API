using ToDo.Api.DTOs;

namespace ToDo.Api.Services
{
    public interface IToDoItemsService
    {
        Task<IEnumerable<ToDoItemDto>> GetAllAsync();
        Task<ToDoItemDto?> GetByIdAsync(int id);
        Task<ToDoItemDto?> AddAsync(CreateToDoItemDto createToDoItemDto);
        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(UpdateToDoItemDto updateToDoItemDto, int id);
    }
}
