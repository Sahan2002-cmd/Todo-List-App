using TodoListAPI.Models;

namespace TodoListAPI.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        Task<IEnumerable<TodoItem>> GetAllAsync();
        Task<TodoItem?> GetByIdAsync(int id);
        Task<TodoItem> CreateAsync(TodoItem todoItem);
        Task<TodoItem?> UpdateAsync(int id, TodoItem todoItem);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<TodoItem>> GetByStatusAsync(bool isCompleted);
    }
}
