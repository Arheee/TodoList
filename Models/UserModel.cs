using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class UserModel
    {
        [Required(ErrorMessage ="Le nom d'utilisateur est obligatoire")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
       
        public string Password { get; set; }
    }
}
