using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebBookStore.ViewModel;

namespace WebBookStore.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController (UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            }
            );
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            //Aqui informamos que se o login não for valido, o usuario retorna a pagina de login
            if (!ModelState.IsValid)
                return View(loginVM);

            // busca o usuario
            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if (user != null)
            {
                // ve a combinação do usuario e a senha
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                // caso a verificação funcione
                if (result.Succeeded)
                {
                    // caso a Url que ele veio seja null, ou seja, entrou na pagina de login direto, ele vai ate o index do home
                    if (string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //caso ele tenha passado por algum pagina do site e clicado para fazer o login, ele retorna a mesma pagina que estava
                    return RedirectToAction(loginVM.ReturnUrl);
                }
            }
            //caso dê erro, essa mensagem aparecera 
            ModelState.AddModelError("", "Falha ao realizar o login");
            //e ele retorna a pagina de login
            return View(loginVM);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = registerVM.UserName };
                var result = await _userManager.CreateAsync(user, registerVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    this.ModelState.AddModelError("Registro", "Erro ao registrar");

                }
            }
            return View(registerVM);

        }
    }
}
