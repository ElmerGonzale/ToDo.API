using System.ComponentModel.DataAnnotations;

namespace ToDo.Api.DTOs
{
    public class CreateToDoItemDto
    {
        [Required(ErrorMessage = "Se requiere un valor para el campo {0}")]
        [StringLength(10, ErrorMessage = "El campo {0} no puede superar los {1} caracteres")]
        public string Name { get; set; } = string.Empty;

    }
}
