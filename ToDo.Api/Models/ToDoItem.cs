using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.Models
{
    public class ToDoItem
    {
        public long id { get; set; }
        [MaxLength(150)]
        public string name { get; set; } =string.Empty;
        public bool IsCompleted { get; set; } = false;
    }
}
