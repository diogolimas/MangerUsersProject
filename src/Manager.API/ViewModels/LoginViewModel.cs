using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class LoginViewModel
    {
        //validação através de data notations
        [Required(ErrorMessage = "O longin não  pode estar vazio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazia.")]
      
        public string Password { get; set; }
    }
}