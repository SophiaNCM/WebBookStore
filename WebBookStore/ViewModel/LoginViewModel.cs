using System.ComponentModel.DataAnnotations;

namespace WebBookStore.ViewModel
{
    public class LoginViewModel
    {
        // Essa viewModel é o login geral, ou seja, clientes e admins entram por aqui.


        //Nome do usuario
        [Required(ErrorMessage ="Informe o usuario")]
        [Display(Name ="Usuário")]
        public string UserName { get; set; }

        // senha do usuario
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
        

        //ao final vai retornar a pagina que ele estava quando ele clicou para fazer  o login
        public string ReturnUrl { get; set; }
    }
}
