using System.ComponentModel.DataAnnotations;

namespace LightScience.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(20)] // O campo é obrigatório e tem um comprimento máximo de 10 caracteres
        public string Username { get; set; } // Nome de usuário para registro

        [Required, DataType(DataType.EmailAddress)] // O campo é obrigatório e do tipo email
        public string Email { get; set; } // Email para registro

        [Required, DataType(DataType.Password)] // O campo é obrigatório e do tipo senha
        public string Password { get; set; } // Senha para registro

        [DataType(DataType.Password), Compare(nameof(Password))] // O campo é do tipo senha e deve ser igual ao campo Password
        public string ConfirmPassword { get; set; } // Confirmação de senha para registro
    }
}
