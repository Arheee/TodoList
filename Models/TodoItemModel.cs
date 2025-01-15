

using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TodoItemModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Le titre est obligatoire")]
        [StringLength(50, ErrorMessage ="Le titre ne peut pas exceder 50 charactères")]
        public string? Title { get; set; }

      
        [StringLength(500)]
       public string? Description { get; set; }

        [Required(ErrorMessage = "Le statut est obligatoire")]
        public bool IsCompleted { get; set; }
    }
}
