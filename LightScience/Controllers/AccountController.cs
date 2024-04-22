using LightScience.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LightScience.Controllers
{
    public class AccountController : Controller
    {
       private readonly UserManager<IdentityUser> _userManager;
       private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost] // Atributo para indicar que este método responde a requisições POST
        public async Task<IActionResult> Login(LoginViewModel signIn, string ReturnUrl) // Método para processar o login
        {
            IdentityUser user;
            if (signIn.UserName.Contains("@")) // Verifica se o usuário digitou um email
            {
                user = await _userManager.FindByEmailAsync(signIn.UserName); // Busca o usuário pelo email
            }
            else
            {
                user = await _userManager.FindByNameAsync(signIn.UserName); // Busca o usuário pelo nome de usuário
            }

            if (user == null) // Verifica se o usuário existe
            {
                ModelState.AddModelError("", "Credenciais Inválidas"); // Adiciona um erro ao ModelState
                return View(signIn); // Retorna a View de login com os dados preenchidos e a mensagem de erro
            }

            var result = await _signInManager.PasswordSignInAsync(user, signIn.Password, false, false); // Tenta fazer o login com os dados fornecidos
            if (!result.Succeeded) // Verifica se o login foi bem-sucedido
            {
                ModelState.AddModelError("", "Credenciais Inválidas"); // Adiciona um erro ao ModelState
                return View(signIn); // Retorna a View de login com os dados preenchidos e a mensagem de erro
            }

            TempData["SuccessMessage"] = "Bem vindo ao LightScence, " + user.UserName;

            if (ReturnUrl != null) // Verifica se existe uma URL de retorno
                return LocalRedirect(ReturnUrl); // Redireciona para a URL de retorno

            return RedirectToAction("Index", "Cuturas"); // Redireciona para a página inicial
        }

        public IActionResult Register() // Método para exibir a tela de registro
        {
            return View(); // Retorna a View correspondente
        }

        [HttpPost] // Atributo para indicar que este método responde a requisições POST
        public async Task<IActionResult> Register(RegisterViewModel register) // Método para processar o registro
        {
            if (!ModelState.IsValid) // Verifica se os dados do formulário são válidos
                return View(); // Retorna a View de registro com os dados preenchidos e as mensagens de erro

            var existingUser = await _userManager.FindByNameAsync(register.Username);
            if(existingUser != null)
            {
                ModelState.AddModelError("", "O nome do usuário já existe");
                return View(register);
            }

           IdentityUser newUser = new IdentityUser // Cria um novo usuário
           {
                Email = register.Email, // Define o email do usuário
                UserName = register.Username // Define o nome de usuário
           };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password); // Tenta criar o usuário
            if (!result.Succeeded) // Verifica se a criação do usuário foi bem-sucedida
            {
                foreach (var item in result.Errors) // Para cada erro retornado pelo Identity
                {
                    ModelState.AddModelError("", item.Description); // Adiciona o erro ao ModelState
                }
            }
            return RedirectToAction("Login"); // Redireciona para a tela de login
        }

        public async Task<IActionResult> SignOut() // Método para fazer logout
        {
            await _signInManager.SignOutAsync(); // Faz logout
            return RedirectToAction(nameof(Login)); // Redireciona para a tela de login
        }
    }
}
